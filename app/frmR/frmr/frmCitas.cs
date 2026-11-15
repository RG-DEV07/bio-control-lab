using BioControlLab.Data;
using BioControlLab.Models;
using BioControlLab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioControlLab.frmR
{
    public partial class frmCitas : Form
    {
        RepoCitas repoCitas = new RepoCitas();
        RepoClientes repoClientes = new RepoClientes();
        public frmCitas()
        {
            InitializeComponent();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarServicios();
            CargarEstados();
            MostrarDatos();
        }
        private void CargarClientes()
        {
            DataTable dt = repoClientes.Listar();
            dt.Columns.Add("NombreCompleto", typeof(string), "nombres + ' ' + apellidos");

            cmbCliente.DataSource = dt;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "idCliente";
        }

        private void CargarServicios()
        {
            DataTable dt = repoCitas.GetServicios();
            cmbServicio.DataSource = dt;
            cmbServicio.DisplayMember = "nombreServicio";
            cmbServicio.ValueMember = "idServicio";
        }

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Programada");
            cmbEstado.Items.Add("Confirmada");
            cmbEstado.Items.Add("Completada");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.SelectedIndex = 0;
        }

        private void MostrarDatos()
        {
            dvgCitas.DataSource = repoCitas.Listar();
            dvgCitas.Columns["idCita"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Cita c = new Cita
            {
                IdCliente = Convert.ToInt32(cmbCliente.SelectedValue),
                IdServicio = Convert.ToInt32(cmbServicio.SelectedValue),
                FechaCita = dtpFecha.Value.Date,
                HoraCita = dtphora.Value.TimeOfDay,
                Estado = cmbEstado.Text,
                Observacion = txtObservacion.Text
            };

            if (repoCitas.Insertar(c) > 0)
            {
                MessageBox.Show("Cita guardada correctamente.");
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
            if (dvgCitas.CurrentRow == null) { MessageBox.Show("Seleccione una cita."); return; }
            if (!ValidarCampos()) return;

            Cita c = new Cita
            {
                Id = Convert.ToInt32(dvgCitas.CurrentRow.Cells["idCita"].Value),
                IdServicio = Convert.ToInt32(cmbServicio.SelectedValue),
                FechaCita = dtpFecha.Value.Date,
                HoraCita = dtphora.Value.TimeOfDay,
                Estado = cmbEstado.Text,
                Observacion = txtObservacion.Text
            };

            if (repoCitas.Actualizar(c) > 0)
            {
                MessageBox.Show("Cita actualizada.");
                MostrarDatos();
                Limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dvgCitas.CurrentRow == null) { MessageBox.Show("Seleccione una cita."); return; }

            int id = Convert.ToInt32(dvgCitas.CurrentRow.Cells["idCita"].Value);

            if (MessageBox.Show("¿Cancelar esta cita?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (repoCitas.Eliminar(id) > 0)
                {
                    MessageBox.Show("Cita cancelada.");
                    MostrarDatos();
                    Limpiar();
                }
            }
        }
        private void Limpiar()
        {
            cmbCliente.SelectedIndex = 0;
            cmbServicio.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            dtphora.Value = DateTime.Now;
            txtObservacion.Text = "";
        }

        private bool ValidarCampos()
        {
            if (cmbCliente.SelectedValue == null) { MessageBox.Show("Seleccione un cliente."); return false; }
            if (cmbServicio.SelectedValue == null) { MessageBox.Show("Seleccione un servicio."); return false; }
            if (cmbEstado.Text == "") { MessageBox.Show("Seleccione el estado."); return false; }
            return true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarPDF(dvgCitas, "Citas.pdf", "Listado de Citas");
        }
    }
}
