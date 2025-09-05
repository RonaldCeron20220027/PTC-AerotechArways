using ConexionDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Entidades
{
    public class TipoAeronave
    {
        private int tipoAeronaveID;
        private string modelo;
        private string fabricante;
        private int capacidadPasajeros;
        private double capacidadCargaKG;

        public int TipoAeronaveID { get => tipoAeronaveID; set => tipoAeronaveID = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Fabricante { get => fabricante; set => fabricante = value; }
        public int CapacidadPasajeros { get => capacidadPasajeros; set => capacidadPasajeros = value; }
        public double CapacidadCargaKG { get => capacidadCargaKG; set => capacidadCargaKG = value; }

        public bool RegistrarTipoAeronave()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string queryhas = "INSERT INTO TipoAeronave (modelo, Fabricante,capacidadPasajeros,capacidadCargaKG) VALUES (@modelo, @Fabricante, @capacidadPasajeros,@capacidadCargaKG)";
                SqlCommand insertar = new SqlCommand(queryhas, con);
                insertar.Parameters.AddWithValue("@modelo", Modelo);
                insertar.Parameters.AddWithValue("@Fabricante", Fabricante);
                insertar.Parameters.AddWithValue("@capacidadPasajeros", CapacidadPasajeros);
                insertar.Parameters.AddWithValue("@capacidadCargaKG", CapacidadCargaKG);
                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error por favor verifique este bien los campos" + ex);
                return false;
            }
        }

        public bool EliminarRegistrarTipoAeronave(int idB)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.Conectar();
                string consultaDelete = "DELETE FROM RegistrarTipoAeronave WHERE tipoAeronaveID = @id";
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

    }
}
