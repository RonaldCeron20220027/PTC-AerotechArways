using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionDB;

namespace Entidades
{
    public class Usuario
    {
        private int usuariosId;
        private string nombre;
        private string email;
        private string clave;
        private int rolId;

        public int UsuariosId { get => usuariosId; set => usuariosId = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Clave { get => clave; set => clave = value; }
        public int RolId { get => rolId; set => rolId = value; }

        public bool RegistrarUsuario()
        {
            try
            {
                SqlConnection conn = Conexion.Conectar();
                string queryhas = "INSERT INTO Usuarios (Nombre,Email,clave,RolId) VALUES (@Nombre,@Email,@clave,@RolId)";
                SqlCommand insertar = new SqlCommand(queryhas, conn);
                insertar.Parameters.AddWithValue("@Nombre", nombre);
                insertar.Parameters.AddWithValue("@Email", email);
                insertar.Parameters.AddWithValue("@clave", clave);
                insertar.Parameters.AddWithValue("@RolId", rolId);
                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Este Usuario ya existe, ulitiliza otro correo electronico" + ex);
                return false;
            }
        }

        public bool VerificarLogin(string correo, string clave)
        {
            string hashEnBaseDeDatos = "";
            SqlConnection conn = Conexion.Conectar();
            string query = "SELECT clave FROM Usuarios WHERE Email=@Email";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", correo);

            if (cmd.ExecuteScalar() == null)
            {
                return false;
            }
            else
            {
                hashEnBaseDeDatos = cmd.ExecuteScalar().ToString();
                return BCrypt.Net.BCrypt.Verify(clave, hashEnBaseDeDatos);
            }
        }

        public static DataTable cargarRol()
        {
            SqlConnection conn = Conexion.Conectar();
            string querycargar = "select IdRoles,Nombre from Roles;";
            SqlDataAdapter dt = new SqlDataAdapter(querycargar, conn);
            DataTable tabla = new DataTable();
            dt.Fill(tabla);
            return tabla;
        }
    }
}
