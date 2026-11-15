using BioControlLab.frmR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using BioControlLab.frmR.frmr;

namespace BioControlLab
{
    public partial class frmPrincipal : Form
    {

        private string usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public frmPrincipal(string usuario,int rol)
        {
            InitializeComponent();
            usuarioActual = usuario;
            string nombreRol = ObtenerNombreRol(rol);
            lblUsuario.Text = "Usuario: " + usuario ;

            ConfigurarAcceso(rol);
        }
        private void ConfigurarAcceso(int rol)
        {
            if (rol == 1) return;

            Medicos.Visible = false;
            iconMenuItem2.Visible = false;
           // iconMenuItem8.Visible = false;
            iconMenuItem5.Visible = false;
            Proveedores.Visible = false;
        }

        //xcodigo = consecutivo.ToString().PadLeft(3, '0');


        private string ObtenerNombreRol(int rol)
        {
            switch (rol)
            {
                case 1: return "Administrador";
                case 2: return "Usuario";
                default: return "";
            }
        }


        private void instrumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmInstrumentos());
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void verDetallesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmExamenes frm = new frmExamenes();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCitas frm = new frmCitas();  
            frm.ShowDialog();
        }
        private void AbrirFormulario(IconMenuItem menu,Form formulario )
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;

            }

            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            

            Contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void AbrirFormulario(Form formulario)
        {
            if (FormularioActivo != null) FormularioActivo.Close();
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            Contenedor.Controls.Add(formulario);
            formulario.Show();
        }



        private void iconMenuItem11_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void iconMenuItem6_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmExamenes());
        }

        private void CITAS_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCitas());
        }

        private void iconMenuItem5_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmInstrumentos());
        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmInsumos());
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }

        private void Proveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void Medicos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmMedicos());
        }
    }
}
