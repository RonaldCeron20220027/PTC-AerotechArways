using ConexionDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Entidades
{
    public class Rutas
    {
        private int rutaID;
        private int origenPaisID;
        private int destinoPaisID;

        public int RutaID { get => rutaID; set => rutaID = value; }
        public int OrigenPaisID { get => origenPaisID; set => origenPaisID = value; }
        public int DestinoPaisID { get => destinoPaisID; set => destinoPaisID = value; }

        public bool RegistrarRuta()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string queryhas = "INSERT INTO Aerolineas (origenPaisID, destinoPaisID) VALUES (@origenPaisID, @destinoPaisID)";
                SqlCommand insertar = new SqlCommand(queryhas, con);
                insertar.Parameters.AddWithValue("@origenPaisID", origenPaisID);
                insertar.Parameters.AddWithValue("@destinoPaisID", destinoPaisID);
                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error porfavor verifique los campos" + ex);
                return false;
            }
        }

        
    }
}
