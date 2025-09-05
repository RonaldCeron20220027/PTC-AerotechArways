using ConexionDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Modelo.Entidades
{
    public class Paises
    {
        private int paisID;
        private string nombrePais;
        private string codigoISO;
        private string prefijoTelefonico;
        private string continente;

        public int PaisID { get => paisID; set => paisID = value; }
        public string NombrePais { get => nombrePais; set => nombrePais = value; }
        public string CodigoISO { get => codigoISO; set => codigoISO = value; }
        public string PrefijoTelefonico { get => prefijoTelefonico; set => prefijoTelefonico = value; }
        public string Continente { get => continente; set => continente = value; }

        public bool RegistrarPais()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string queryhas = "INSERT INTO Paises (NombrePais, CodigoISO,PrefijoTelefonico,Continente) VALUES (@NombrePais, @CodigoISO, @PrefijoTelefonico,@Continente)";
                SqlCommand insertar = new SqlCommand(queryhas, con);
                insertar.Parameters.AddWithValue("@NombrePais", NombrePais);
                insertar.Parameters.AddWithValue("@CodigoISO", CodigoISO);
                insertar.Parameters.AddWithValue("@PrefijoTelefonico", PrefijoTelefonico);
                insertar.Parameters.AddWithValue("@Continente", Continente);
                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error por favor verifique este bien los campos"+ex);
                return false;
            }
        }

        public static DataTable cargarPais()
        {
            SqlConnection conn = Conexion.Conectar();
            string querycargar = "select PaisID,NombrePais from Paises;";
            SqlDataAdapter dt = new SqlDataAdapter(querycargar, conn);
            DataTable tabla = new DataTable();
            dt.Fill(tabla);
            return tabla;
        }


    }
}
