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
    public class Aeronaves
    {
        private int aeronaveID;
        private string matricula;
        private DateTime fechaAdquisicion;
        private int tipoAeronaveID;
        private int aerolineaID;

        public int AeronaveID { get => aeronaveID; set => aeronaveID = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public DateTime FechaAdquisicion { get => fechaAdquisicion; set => fechaAdquisicion = value; }
        public int TipoAeronaveID { get => tipoAeronaveID; set => tipoAeronaveID = value; }
        public int AerolineaID { get => aerolineaID; set => aerolineaID = value; }

        public bool RegistrarAeronave()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string queryhas = "INSERT INTO Aeronaves (Matricula, FechaAdquisicion,TipoAeronaveID,AerolineaID) VALUES (@Matricula, @FechaAdquisicion,@TipoAeronaveID,@AerolineaID)";
                SqlCommand insertar = new SqlCommand(queryhas, con);
                insertar.Parameters.AddWithValue("@Matricula", Matricula);
                insertar.Parameters.AddWithValue("@FechaAdquisicion", FechaAdquisicion);
                insertar.Parameters.AddWithValue("@TipoAeronaveID", TipoAeronaveID);
                insertar.Parameters.AddWithValue("@AerolineaID", AerolineaID);
                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error porfavor verifique los campos" + ex);
                return false;
            }


        }

        public bool EliminarAerolinea(int idB)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.Conectar();
                string consultaDelete = "DELETE FROM Aeronaves WHERE aeronaveID = @id";
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
