using BioControlLab.Data;
using BioControlLab.Models;
using BioControlLab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioControlLab.frmR
{
    public partial class frmExamenes : Form

    {
        RepoExamenes repo = new RepoExamenes();
        int idSeleccionado = 0;
        public frmExamenes()
        {
            InitializeComponent();
        }

        private void frmExamenes_Load(object sender, EventArgs e)
        {
            CargarTiposExamen();
            CargarEstados();
            MostrarDatos();
        }
        private void CargarTiposExamen()
        {
            DataTable dt = repo.GetTiposExamen();
            cmbTipoExamen.DataSource = dt;
            cmbTipoExamen.DisplayMember = "nombreExamen";
            cmbTipoExamen.ValueMember = "idTipoExamen";
        }
        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("En proceso");
            cmbEstado.Items.Add("Completado");
            cmbEstado.Items.Add("Cancelado");
            cmbEstado.SelectedIndex = 0;
        }
        private void MostrarDatos()
        {
            dgvExamenes.DataSource = repo.Listar();
            dgvExamenes.Columns["idExamen"].Visible = false;
        }
        private void dvgExamenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Examen ex = new Examen
            {
                IdCliente = 1, 
                IdTipoExamen = Convert.ToInt32(cmbTipoExamen.SelectedValue),
                FechaSolicitud = dtpFechaSolicitud.Value,
                Estado = cmbEstado.Text,
                Observacion = txtObservacion.Text
            };

            if (repo.Insertar(ex) > 0)
            {
                MessageBox.Show("Examen guardado correctamente.");
                MostrarDatos();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo guardar.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (dgvExamenes.CurrentRow == null) { MessageBox.Show("Seleccione un examen."); return; }
            if (!ValidarCampos()) return;

            Examen ex = new Examen
            {
                Id = Convert.ToInt32(dgvExamenes.CurrentRow.Cells["idExamen"].Value),
                IdTipoExamen = Convert.ToInt32(cmbTipoExamen.SelectedValue),
                FechaSolicitud = dtpFechaSolicitud.Value,
                Estado = cmbEstado.Text,
                Observacion = txtObservacion.Text
            };

            if (repo.Actualizar(ex) > 0)
            {
                MessageBox.Show("Examen actualizado.");
                MostrarDatos();
                Limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvExamenes.CurrentRow == null) { MessageBox.Show("Seleccione un examen."); return; }

            int id = Convert.ToInt32(dgvExamenes.CurrentRow.Cells["idExamen"].Value);

            if (MessageBox.Show("¿Cancelar este examen?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (repo.Eliminar(id) > 0)
                {
                    MessageBox.Show("Examen cancelado.");
                    MostrarDatos();
                    Limpiar();
                }
            }
        }
        private void Limpiar()
        {
            idSeleccionado = 0;
            cmbTipoExamen.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            dtpFechaSolicitud.Value = DateTime.Now;
            txtObservacion.Text = "";
        }

        private bool ValidarCampos()
        {
            if (cmbTipoExamen.SelectedValue == null) { MessageBox.Show("Seleccione el tipo de examen."); return false; }
            if (cmbEstado.Text == "") { MessageBox.Show("Seleccione el estado."); return false; }
            return true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarPDF(dgvExamenes, "Examenes.pdf", "Listado de Exámenes");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

