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
    public partial class frmRegistrarUsuario : UserControl
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();
     
        }


        private void cargarRoles()
        {
            cbRol.DataSource = null;
            cbRol.DataSource = Usuario.cargarRol();
            cbRol.DisplayMember = "Nombre";
            cbRol.ValueMember = "IdRoles";
            cbRol.SelectedIndex = -1;
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.Nombre = txtNombre.Text;
            user.Email = txtCorreo.Text;
            user.Clave = BCrypt.Net.BCrypt.HashPassword(txtpass.Text);
            user.RolId = Convert.ToInt32(cbRol.SelectedValue);
            if (user.RegistrarUsuario() == true)
            {
                MessageBox.Show("Usuario registrado:Bienvenido " + user.Nombre);
            }
        }

        private void frmRegistrarUsuario_Load(object sender, EventArgs e)
        {
            cargarRoles();
        }

        public void SoloTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
