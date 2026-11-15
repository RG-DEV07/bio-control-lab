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

namespace BioControlLab.frmR.frmr
{
    public partial class frmMedicos : Form
    {
        private RepoEmpleados repo = new RepoEmpleados();
        private int idSeleccionado = 0;
        public frmMedicos()
        {
            InitializeComponent();
        }

        private void txtTelefonoM_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMedicos_Load(object sender, EventArgs e)
        {
            CargarCargos();
            CargarEstados();
            CargarGrid();
            Limpiar();
        }
        private void CargarCargos()
        {
            cmbCargo.Items.Clear();
            cmbCargo.Items.Add("Médico");
            cmbCargo.Items.Add("Enfermero");
            cmbCargo.Items.Add("Técnico de Laboratorio");
            cmbCargo.Items.Add("Recepcionista");
            cmbCargo.Items.Add("Administrador");
            cmbCargo.SelectedIndex = 0;
        }

        private void CargarEstados()
        {
            cbmEstadoM.Items.Clear();
            cbmEstadoM.Items.Add("Activo");
            cbmEstadoM.Items.Add("Inactivo");
            cbmEstadoM.SelectedIndex = 0;
        }

        private void CargarGrid()
        {
            dvgMedicos.DataSource = repo.Listar();

            if (dvgMedicos.Columns["idEmpleado"] != null)
                dvgMedicos.Columns["idEmpleado"].Visible = false;
        }

        private void dvgMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dvgMedicos.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["idEmpleado"].Value);
            txtNombre.Text = fila.Cells["nombres"].Value?.ToString();
            txtApellidoM.Text = fila.Cells["apellidos"].Value?.ToString();
            txtTelefonoM.Text = fila.Cells["telefono"].Value?.ToString();
            txtCorreoM.Text = fila.Cells["correo"].Value?.ToString();

            string cargo = fila.Cells["cargo"].Value?.ToString();
            if (cmbCargo.Items.Contains(cargo))
                cmbCargo.SelectedItem = cargo;
            else
                cmbCargo.Text = cargo; 

            cbmEstadoM.SelectedItem = "Activo";
        }
        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidoM.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidoM.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbCargo.Text))
            {
                MessageBox.Show("Debes seleccionar o escribir un cargo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCargo.Focus();
                return false;
            }

            return true;
        }
        private Medicos ObtenerDatosForm()
        {
            return new Medicos
            {
                Id = idSeleccionado,
                Nombres = txtNombre.Text.Trim(),
                Apellidos = txtApellidoM.Text.Trim(),
                Cargo = cmbCargo.Text.Trim(),
                Telefono = txtTelefonoM.Text.Trim(),
                Correo = txtCorreoM.Text.Trim()
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Medicos emp = ObtenerDatosForm();
            int resultado = repo.Insertar(emp);

            if (resultado > 0)
            {
                MessageBox.Show("Trabajador guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el trabajador.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un trabajador de la lista para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmar = MessageBox.Show(
                "¿Seguro que deseas eliminar este trabajador?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            int resultado = repo.Eliminar(idSeleccionado);

            if (resultado > 0)
            {
                MessageBox.Show("Trabajador eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el trabajador.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un trabajador de la lista para actualizar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Validar()) return;

            Medicos emp = ObtenerDatosForm();
            int resultado = repo.Actualizar(emp);

            if (resultado > 0)
            {
                MessageBox.Show("Trabajador actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el trabajador.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtApellidoM.Clear();
            txtTelefonoM.Clear();
            txtCorreoM.Clear();
            cmbCargo.SelectedIndex = 0;
            cbmEstadoM.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarPDF(dvgMedicos, "Pacientes.pdf", "Listado de Pacientes");
        }
    }
}
