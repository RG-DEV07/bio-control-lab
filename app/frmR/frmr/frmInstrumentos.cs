using BioControlLab.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioControlLab
{
    public partial class frmInstrumentos : Form
    {
        RepoInstrumento funBio = new RepoInstrumento();
        int idInstrumento = 0;

        public frmInstrumentos()
        {
            InitializeComponent();
            
        }

        private void frmInstrumentos_Load(object sender, EventArgs e)
        {
            cargarCombos();
            mostrarDatos();
           

        }

        private void cargarCombos()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Medicion");
            cmbCategoria.Items.Add("Analisis");
            cmbCategoria.Items.Add("Preparacion");
            cmbCategoria.Items.Add("Almacenamiento");
            cmbCategoria.Items.Add("Bioseguridad");

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Asignado");
            cmbEstado.Items.Add("En revision");
            cmbEstado.Items.Add("Mantenimiento");
            cmbEstado.Items.Add("Vencido");

            cmbCategoria.Text = "Medicion";
            cmbEstado.Text = "Disponible";
        }

        private void mostrarDatos()
        {
            dgvInstrumentos.DataSource = funBio.Listar();
        }

        private void limpiar()
        {
            idInstrumento = 0;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtObservacion.Clear();
            cmbCategoria.Text = "Medicion";
            cmbEstado.Text = "Disponible";
            dtpRevision.Value = DateTime.Now;
            txtCodigo.Focus();
        }

        private bool validarCampos()
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del instrumento");
                txtCodigo.Focus();
                return false;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del instrumento");
                txtNombre.Focus();
                return false;
            }

            if (cmbCategoria.Text == "")
            {
                MessageBox.Show("Seleccione la categoria");
                cmbCategoria.Focus();
                return false;
            }

            if (cmbEstado.Text == "")
            {
                MessageBox.Show("Seleccione el estado");
                cmbEstado.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int pok = 0;

            if (validarCampos() == true)
            {
                pok = funBio.Insertar(txtCodigo.Text, txtNombre.Text, cmbCategoria.Text, txtMarca.Text, txtModelo.Text, cmbEstado.Text, dtpRevision.Value, txtObservacion.Text);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int pokv=0;

            pokv = funBio.Actualizar(idInstrumento, txtCodigo.Text, txtNombre.Text, cmbCategoria.Text, txtMarca.Text, txtModelo.Text, cmbEstado.Text, dtpRevision.Value, txtObservacion.Text);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int pok =0;
            pok = funBio.Eliminar(idInstrumento);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void dgvInstrumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idInstrumento = Convert.ToInt32(dgvInstrumentos.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                txtCodigo.Text = dgvInstrumentos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                txtNombre.Text = dgvInstrumentos.Rows[e.RowIndex].Cells["Instrumento"].Value.ToString();
                cmbCategoria.Text = dgvInstrumentos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                txtMarca.Text = dgvInstrumentos.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
                txtModelo.Text = dgvInstrumentos.Rows[e.RowIndex].Cells["Modelo"].Value.ToString();
                cmbEstado.Text = dgvInstrumentos.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                dtpRevision.Value = Convert.ToDateTime(dgvInstrumentos.Rows[e.RowIndex].Cells["Revision"].Value.ToString());
                txtObservacion.Text = dgvInstrumentos.Rows[e.RowIndex].Cells["Observacion"].Value.ToString();
            }
        }
    }
}
