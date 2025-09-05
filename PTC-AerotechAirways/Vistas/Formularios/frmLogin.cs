using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas.Formularios
{
    public partial class frmLogin : UserControl
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string clave = txtpass.Text;

            Usuario user = new Usuario();
            if (user.VerificarLogin(correo, clave))
            {
                MessageBox.Show("✅ Bienvenido");
                frmHome f = new frmHome();
                f.ShowDialog();
                frmLogin L = new frmLogin();
                L.Visible = false;
                
            }
            else
            {
                MessageBox.Show("❌ Usuario o contraseña incorrectos");
            }
           Environment.Exit(0);
        }
    }
}
