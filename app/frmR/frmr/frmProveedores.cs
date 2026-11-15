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
    public partial class frmProveedores : Form
    {
        private RepoProveedores repo = new RepoProveedores();
        private int idSeleccionado = 0;
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarPDF(dvgProveedores, "Pacientes.pdf", "Listado de Pacientes");
        }
        private void CargarEstados()
        {
            cbmEstadoP.Items.Clear();
            cbmEstadoP.Items.Add("Activo");
            cbmEstadoP.Items.Add("Inactivo");
            cbmEstadoP.SelectedIndex = 0;
        }

        private void CargarGrid()
        {
            dvgProveedores.DataSource = repo.Listar();

            if (dvgProveedores.Columns["idProveedor"] != null)
                dvgProveedores.Columns["idProveedor"].Visible = false;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un proveedor de la lista para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmar = MessageBox.Show(
                "¿Seguro que deseas eliminar este proveedor?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            int resultado = repo.Eliminar(idSeleccionado);

            if (resultado > 0)
            {
                MessageBox.Show("Proveedor eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el proveedor.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            CargarEstados();
            CargarGrid();
            Limpiar();
        }

        private void dvgProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dvgProveedores.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["idProveedor"].Value);
            txtNombreProveedor.Text = fila.Cells["nombreProveedor"].Value?.ToString();
            txtTelefonoP.Text = fila.Cells["telefono"].Value?.ToString();
            txtCorreoP.Text = fila.Cells["correo"].Value?.ToString();
            txtDireccionP.Text = fila.Cells["direccion"].Value?.ToString();
            cbmEstadoP.SelectedItem = "Activo";
        }
        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombreProveedor.Text))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProveedor.Focus();
                return false;
            }
            return true;
        }

        private Proveedor ObtenerDatosForm()
        {
            return new Proveedor
            {
                Id = idSeleccionado,
                NombreProveedor = txtNombreProveedor.Text.Trim(),
                Telefono = txtTelefonoP.Text.Trim(),
                Correo = txtCorreoP.Text.Trim(),
                Direccion = txtDireccionP.Text.Trim(),
                Ruc = null 
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Proveedor p = ObtenerDatosForm();
            int resultado = repo.Insertar(p);

            if (resultado > 0)
            {
                MessageBox.Show("Proveedor guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el proveedor.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            idSeleccionado = 0;
            txtNombreProveedor.Clear();
            txtTelefonoP.Clear();
            txtCorreoP.Clear();
            txtDireccionP.Clear();
            cbmEstadoP.SelectedIndex = 0;
            txtNombreProveedor.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbmEstadoP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccionP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCorreoP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefonoP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidosP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
