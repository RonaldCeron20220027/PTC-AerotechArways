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
    public class Aerolineas
    {
        private int aerolineaID;
        private string nombre;
        private int paisID;

        public int AerolineaID { get => aerolineaID; set => aerolineaID = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int PaisID { get => paisID; set => paisID = value; }

        public bool RegistrarAeroline()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string queryhas = "INSERT INTO Aerolineas (Nombre, PaisID) VALUES (@Nombre, @PaisID)";
                SqlCommand insertar = new SqlCommand(queryhas, con);
                insertar.Parameters.AddWithValue("@Nombre", Nombre);
                insertar.Parameters.AddWithValue("@PaisID", PaisID);
                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error porfavor verifique los campos"+ex);
                return false;
            }
        }
        public static DataTable cargarAeronaves()
        {
            try
            {
                SqlConnection conexion = Conexion.Conectar();
                string consultaQuery = "select * from GestioAeronaves;";
                SqlDataAdapter add = new SqlDataAdapter(consultaQuery, conexion);
                DataTable tableCargar = new DataTable();
                add.Fill(tableCargar);
                return tableCargar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos" + ex);
                return null;
            }
        }
        public bool EliminarAerolinea(int idB)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.Conectar();
                string consultaDelete = "DELETE FROM Aerolineas WHERE aerolineaID = @id";
                SqlCommand delete = new SqlCommand(consultaDelete, conexion);
                delete.Parameters.AddWithValue("@id", idB);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public static DataTable BuscarEnGestioAeronaves(string termino)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                string query = @"SELECT * FROM GestioAeronaves WHERE Matricula LIKE @Termino OR Modelo LIKE @Termino OR Fabricante LIKE @Termino OR NombreAerolinea LIKE @Termino";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Termino", "%" + termino + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable resultados = new DataTable();
                    adapter.Fill(resultados);
                    return resultados;
                }
            }
        }

    }
}
