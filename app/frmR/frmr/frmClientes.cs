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
    public partial class frmClientes : Form
    {
        RepoClientes repo = new RepoClientes();
        int idSeleccionado = 0;
        public frmClientes()
        {
            InitializeComponent();
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void brnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Cliente c = new Cliente
            {
                
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Cedula = txtCedula.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text
            };

            if (repo.Insertar(c) > 0)
            {
                MessageBox.Show("Cliente guardado correctamente.");
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
            if (dgvClientes.CurrentRow == null) { MessageBox.Show("Seleccione un cliente."); return; }
            if (!ValidarCampos()) return;

            Cliente c = new Cliente
            {
                Id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["idCliente"].Value),
              
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Cedula = txtCedula.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text
            };

            if (repo.Actualizar(c) > 0)
            {
                MessageBox.Show("Cliente actualizado.");
                MostrarDatos();
                Limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) { MessageBox.Show("Seleccione un cliente."); return; }

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["idCliente"].Value);

            if (MessageBox.Show("¿Eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (repo.Eliminar(id) > 0)
                {
                    MessageBox.Show("Cliente eliminado.");
                    MostrarDatos();
                    Limpiar();
                }
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dgvClientes.DataSource = repo.Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
        private void Limpiar()
        {
            idSeleccionado = 0;
        
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
          
        }

        private bool ValidarCampos()
        {
            if (txtNombres.Text == "") { MessageBox.Show("Ingrese los nombres."); return false; }
            if (txtApellidos.Text == "") { MessageBox.Show("Ingrese los apellidos."); return false; }
            return true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarPDF(dgvClientes, "Pacientes.pdf", "Listado de Pacientes");
        }
    }
}