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
    public partial class Login : Form
    {
        
        public Login()
        {
            
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
          


        }
            private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtclave.Text == "")
            {
                MessageBox.Show("Ingrese usuario y contraseña.");
                return;
            }

            Usuario us = new Usuario();
            int rol = us.ObtenerRol(txtUsuario.Text, txtclave.Text);

            if (rol == 0)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }

            string nombre = us.ObtenerNombre(txtUsuario.Text, txtclave.Text);
            frmPrincipal form = new frmPrincipal(nombre, rol);
            form.Show();
            this.Hide();
            form.FormClosing += frm_closing;
        }

        

        private void frm_closing(object sender,FormClosingEventArgs e)
        {
            txtUsuario.Text = "";
            txtclave.Text = "";
           this.Show();
        }
    }

       
    }

