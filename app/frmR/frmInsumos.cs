using BioControlLab.Data;
using BioControlLab.Models;
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
    public partial class frmInsumos : Form
    {
        RepoInsumos repo = new RepoInsumos();
        public frmInsumos()
        {
            InitializeComponent();
        }

        private void frmInsumos_Load(object sender, EventArgs e)
        {
            
            CargarCombos();
            MostrarDatos();

        }
        private void CargarCombos()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Bioseguridad");
            cmbCategoria.Items.Add("Laboratorio");
            cmbCategoria.Items.Add("Limpieza");
            cmbCategoria.Items.Add("Oficina");
            cmbCategoria.Items.Add("Quirúrgico");
            cmbCategoria.SelectedIndex = 0;

            cmbUnidad.Items.Clear();
            cmbUnidad.Items.Add("Unidad");
            cmbUnidad.Items.Add("Caja");
            cmbUnidad.Items.Add("Paquete");
            cmbUnidad.Items.Add("Litro");
            cmbUnidad.Items.Add("Mililitro");
            cmbUnidad.Items.Add("Gramo");
            cmbUnidad.SelectedIndex = 0;
        }

        private void dgvInsumos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtcodigo.Text = dgvInsumos.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
            txtNombre.Text = dgvInsumos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
            cmbCategoria.Text = dgvInsumos.Rows[e.RowIndex].Cells["categoria"].Value.ToString();
            cmbUnidad.Text = dgvInsumos.Rows[e.RowIndex].Cells["unidadMedida"].Value.ToString();
            txtStock.Text = dgvInsumos.Rows[e.RowIndex].Cells["stockActual"].Value.ToString();
            txtStockMinimo.Text = dgvInsumos.Rows[e.RowIndex].Cells["stockMinimo"].Value.ToString();
        }
        private void Limpiar()
        {
            txtcodigo.Text = "";
            txtNombre.Text = "";
            txtStock.Text = "0";
            txtStockMinimo.Text = "5";
            cmbCategoria.SelectedIndex = 0;
            cmbUnidad.SelectedIndex = 0;
            txtcodigo.Focus();
        }

        private bool ValidarCampos()
        {
            if (txtcodigo.Text == "") { MessageBox.Show("Ingrese el código."); return false; }
            if (txtNombre.Text == "") { MessageBox.Show("Ingrese el nombre."); return false; }
            if (txtStock.Text == "") { MessageBox.Show("Ingrese el stock."); return false; }
            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInsumos.CurrentRow == null) { MessageBox.Show("Seleccione un insumo."); return; }

            int id = Convert.ToInt32(dgvInsumos.CurrentRow.Cells["idInsumo"].Value);

            if (MessageBox.Show("¿Eliminar este insumo?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (repo.Eliminar(id) > 0)
                {
                    MessageBox.Show("Insumo eliminado.");
                    MostrarDatos();
                    Limpiar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvInsumos.CurrentRow == null) { MessageBox.Show("Seleccione un insumo."); return; }
            if (!ValidarCampos()) return;

            Insumo i = new Insumo
            {
                Id = Convert.ToInt32(dgvInsumos.CurrentRow.Cells["idInsumo"].Value),
                Codigo = txtcodigo.Text,
                Nombre = txtNombre.Text,
                Categoria = cmbCategoria.Text,
                UnidadMedida = cmbUnidad.Text,
                StockActual = Convert.ToInt32(txtStock.Text),
                StockMinimo = Convert.ToInt32(txtStockMinimo.Text)
            };

            if (repo.Actualizar(i) > 0)
            {
                MessageBox.Show("Insumo actualizado.");
                MostrarDatos();
                Limpiar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Insumo i = new Insumo
            {
                Codigo = txtcodigo.Text,
                Nombre = txtNombre.Text,
                Categoria = cmbCategoria.Text,
                UnidadMedida = cmbUnidad.Text,
                StockActual = Convert.ToInt32(txtStock.Text),
                StockMinimo = Convert.ToInt32(txtStockMinimo.Text)
            };

            if (repo.Insertar(i) > 0)
            {
                MessageBox.Show("Insumo guardado correctamente.");
                MostrarDatos();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo guardar.");
            }
        }
        private void VerificarStockBajo()
        {
            DataTable dt = repo.ListarBajoStock();
            if (dt.Rows.Count > 0)
            {
                lblAlerta.Text = "⚠ " + dt.Rows.Count + " insumo(s) con stock bajo";
                lblAlerta.ForeColor = Color.Red;
                lblAlerta.Visible = true;
            }
            else
            {
                lblAlerta.Visible = false;
            }
        }
        private void MostrarDatos()
        {
            dgvInsumos.DataSource = repo.Listar();
            VerificarStockBajo();
        }
    }
    }
    

