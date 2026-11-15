using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioControlLab.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace BioControlLab.frmR.frmr
{
    public partial class frmReportes : Form
    {
        private RepoReportes repo = new RepoReportes();
        private System.Windows.Forms.Timer timerAnimar = new System.Windows.Forms.Timer();
        private int[] _valoresMax;
        private int[] _valoresActuales;
        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            CargarKPIs();
            CargarGraficaExamenes();
            CargarGraficaCitas();
           
        }
        private void CargarKPIs()
        {
            lblTotalPacientes.Text = repo.ContarPacientes().ToString();
            lblTotalCitas.Text = repo.ContarCitasHoy().ToString();
            lblTotalExamenes.Text = repo.ContarExamenesPendientes().ToString();
            lblTotalInsumos.Text = repo.ContarInsumosBajoStock().ToString();
        }

        private void CargarGraficaExamenes()
        {
            chartExamenes.Series.Clear();
            chartExamenes.Titles.Clear();
            chartExamenes.Titles.Add("Exámenes por Estado");

            Series serie = new Series("Exámenes");
            serie.ChartType = SeriesChartType.Bar;
            serie.Color = Color.FromArgb(52, 152, 219);

            DataTable dt = repo.ExamenesPorEstado();
            int n = dt.Rows.Count;
            _valoresMax = new int[n];
            _valoresActuales = new int[n];

            for (int i = 0; i < n; i++)
            {
                _valoresMax[i] = Convert.ToInt32(dt.Rows[i]["total"]);
                serie.Points.AddXY(dt.Rows[i]["estado"].ToString(), 0);
            }

            chartExamenes.Series.Add(serie);
            chartExamenes.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9f);

            for (int i = 0; i < n; i++)
            {
                _valoresMax[i] = Convert.ToInt32(dt.Rows[i]["total"]);
                serie.Points.AddXY(dt.Rows[i]["estado"].ToString(), _valoresMax[i]);
            }
        }

        private void AnimarBarras(object sender, EventArgs e)
        {
            bool terminado = true;
            for (int i = 0; i < _valoresMax.Length; i++)
            {
                if (_valoresActuales[i] < _valoresMax[i])
                {
                    _valoresActuales[i] = Math.Min(
                        _valoresActuales[i] + Math.Max(1, _valoresMax[i] / 20),
                        _valoresMax[i]);
                    chartExamenes.Series[0].Points[i].YValues[0] = _valoresActuales[i];
                    terminado = false;
                }
            }
            chartExamenes.Refresh();
            if (terminado) timerAnimar.Stop();
        }

        private void CargarGraficaCitas()
        {
            chartCitas.Series.Clear();
            chartCitas.Titles.Clear();
            chartCitas.Titles.Add("Citas por Servicio");

            Series serie = new Series("Citas");
            serie.ChartType = SeriesChartType.Pie;

            DataTable dt = repo.CitasPorServicio();
            foreach (DataRow row in dt.Rows)
                serie.Points.AddXY(row["nombreServicio"].ToString(), Convert.ToInt32(row["total"]));

            serie["PieLabelStyle"] = "Outside";
            serie["PieLineColor"] = "Black";
            chartCitas.Series.Add(serie);
        }

        private void lblTotalPacientes_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarKPIs();
            CargarGraficaExamenes();
            CargarGraficaCitas();
        }

        private void lblTotalCitas_Click(object sender, EventArgs e)
        {

        }

        private void pnlPacientes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chartExamenes_Click(object sender, EventArgs e)
        {

        }
    }
}
