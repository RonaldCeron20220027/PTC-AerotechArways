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
    public class EstadoVuelo
    {
        //EstadoVuelo
        private int claseViajeID;
        private string descripcion;

        //Vuelos
        private int vueloID;
        private string numeroVuelo;
        private int rutaID;
        private DateTime fechaHoraSalidaProgramada;
        private DateTime fechaHoraLlegadaProgramada;
        private int idEstadoVuelo;
        private int aeronaveID;

      
        public string Descripcion { get => descripcion; set => descripcion = value; }
      
        public string NumeroVuelo { get => numeroVuelo; set => numeroVuelo = value; }
        public int RutaID { get => rutaID; set => rutaID = value; }
        public DateTime FechaHoraSalidaProgramada { get => fechaHoraSalidaProgramada; set => fechaHoraSalidaProgramada = value; }
        public DateTime FechaHoraLlegadaProgramada { get => fechaHoraLlegadaProgramada; set => fechaHoraLlegadaProgramada = value; }
        public int IdEstadoVuelo { get => idEstadoVuelo; set => idEstadoVuelo = value; }
        public int AeronaveID { get => aeronaveID; set => aeronaveID = value; }
        public int ClaseViajeID { get => claseViajeID; set => claseViajeID = value; }
        public int VueloID { get => vueloID; set => vueloID = value; }

        public bool RegistrarEstado()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string query = "INSERT INTO Vuelos(NumeroVuelo,RutaID,FechaHoraSalidaProgramada,FechaHoraLlegadaProgramada,IDEstadoVuelo,AeronaveID)" +
                    "VALUES (@NumeroVuelo,@RutaID,@FechaHoraSalidaProgramada,@FechaHoraLlegadaProgramada,@IdEstadoVuelo,@AeronaveID)";
                SqlCommand inst = new SqlCommand(query, con);
                inst.Parameters.AddWithValue("@NumeroVuelo", NumeroVuelo);
                inst.Parameters.AddWithValue("@RutaID", RutaID);
                inst.Parameters.AddWithValue("@FechaHoraSalidaProgramada", FechaHoraSalidaProgramada);
                inst.Parameters.AddWithValue("@FechaHoraLlegadaProgramada", FechaHoraLlegadaProgramada);
                inst.Parameters.AddWithValue("@IdEstadoVuelo", IdEstadoVuelo); 
                inst.Parameters.AddWithValue("@AeronaveID", AeronaveID);
                inst.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error porfavor verifique los campos" + ex);
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

        public static DataTable cargarEstados()
        {
            SqlConnection conn = Conexion.Conectar();
            string querycargar = "select estadoVueloID,descripcion from EstadoVuelo;";
            SqlDataAdapter dt = new SqlDataAdapter(querycargar, conn);
            DataTable tabla = new DataTable();
            dt.Fill(tabla);
            return tabla;
        }
        public static DataTable cargarVuelos()
        {
            SqlConnection conn = Conexion.Conectar();
            string querycargar = "select VueloID,NumeroVuelo from Vuelos;";
            SqlDataAdapter dt = new SqlDataAdapter(querycargar, conn);
            DataTable tabla = new DataTable();
            dt.Fill(tabla);
            return tabla;
        }
        public static DataTable cargarInfoVuelos()
        {
            try
            {
                SqlConnection conexion = Conexion.Conectar();
                string consultaQuery = "select * from InfoVuelos;";
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

        public bool EliminarVuelo(int idV)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.Conectar();
                string consultaDelete = "DELETE FROM Vuelos WHERE VueloID = @id";
                SqlCommand delete = new SqlCommand(consultaDelete, conexion);
                delete.Parameters.AddWithValue("@id", idV);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public static DataTable buscarVuelo(string criterio)
        {
            SqlConnection conn = Conexion.Conectar();
            string query = @"SELECT * FROM InfoVuelos 
                     WHERE NumeroVuelo LIKE '%' + @criterio + '%'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@criterio", criterio);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public bool ActualizarVuelo()
        {
            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string consultaUpdate = @"UPDATE Vuelos SET RutaID = @RutaID,FechaHoraSalidaProgramada = @FechaHoraSalidaProgramada,FechaHoraLlegadaProgramada = @FechaHoraLlegadaProgramada,
                    IDEstadoVuelo = @IdEstadoVuelo,AeronaveID = @AeronaveID WHERE VueloID = @VueloID";

                    using (SqlCommand update = new SqlCommand(consultaUpdate, conectar))
                    {
                        update.Parameters.Add("@VueloID", SqlDbType.Int).Value = VueloID;
                        update.Parameters.Add("@NumeroVuelo", SqlDbType.NVarChar, 10).Value = NumeroVuelo;
                        update.Parameters.Add("@RutaID", SqlDbType.Int).Value = RutaID;
                        update.Parameters.Add("@FechaHoraSalidaProgramada", SqlDbType.DateTime2).Value = FechaHoraSalidaProgramada;
                        update.Parameters.Add("@FechaHoraLlegadaProgramada", SqlDbType.DateTime2).Value = FechaHoraLlegadaProgramada;
                        update.Parameters.Add("@IdEstadoVuelo", SqlDbType.Int).Value = IdEstadoVuelo;
                        update.Parameters.Add("@AeronaveID", SqlDbType.Int).Value = AeronaveID;

                        int filasAfectadas = update.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el vuelo: " + ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
