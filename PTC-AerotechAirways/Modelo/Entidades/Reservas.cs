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
    public class Reservas
    {
        //ClaseViaje
        private int claseViajeID;
        private string descripcion;
        //Reservas
        private int reservaID;
        private int pasajeroID;
        private int vueloID;
        private DateTime fechaReserva;
        private int iDClaseViaje;
        private double precioTotal;

        public int ClaseViajeID { get => claseViajeID; set => claseViajeID = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int PasajeroID { get => pasajeroID; set => pasajeroID = value; }
        public int VueloID { get => vueloID; set => vueloID = value; }
        public DateTime FechaReserva { get => fechaReserva; set => fechaReserva = value; }
        public int IDClaseViaje { get => iDClaseViaje; set => iDClaseViaje = value; }
        public double PrecioTotal { get => precioTotal; set => precioTotal = value; }
        public int ReservaID { get => reservaID; set => reservaID = value; }

        public bool RegistrarReserva()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string queryhas = "INSERT INTO Reservas (PasajeroID,VueloID,FechaReserva,IDClaseViaje,PrecioTotal)" +
                    " VALUES (@PasajeroID,@VueloID,@FechaReserva,@IDClaseViaje,@PrecioTotal)";
                SqlCommand insertar = new SqlCommand(queryhas, con);
                insertar.Parameters.AddWithValue("@PasajeroID", PasajeroID);
                insertar.Parameters.AddWithValue("@VueloID", VueloID);
                insertar.Parameters.AddWithValue("@FechaReserva", FechaReserva);
                insertar.Parameters.AddWithValue("@IDClaseViaje", IDClaseViaje);
                insertar.Parameters.AddWithValue("@PrecioTotal", PrecioTotal);

                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {   
                MessageBox.Show("error porfavor verifique los campos" + ex);
                return false;
            }
        }
        public static DataTable cargarReservasCB()
        {
            SqlConnection conn = Conexion.Conectar();
            string querycargar = "select ReservaID,PasajeroID from Reservas;";
            SqlDataAdapter dt = new SqlDataAdapter(querycargar, conn);
            DataTable tabla = new DataTable();
            dt.Fill(tabla);
            return tabla;
        }



        public static DataTable cargarClase()
        {
            SqlConnection conn = Conexion.Conectar();
            string querycargar = "select ClaseViajeID,Descripcion from ClaseViaje;";
            SqlDataAdapter dt = new SqlDataAdapter(querycargar, conn);
            DataTable tabla = new DataTable();
            dt.Fill(tabla);
            return tabla;
        }
        public static DataTable cargarVuelos()
        {
            SqlConnection con = Conexion.Conectar();
            string querycargar = "select VueloID,NumeroVuelo from Vuelos;";
            SqlDataAdapter dtV = new SqlDataAdapter(querycargar, con);
            DataTable tabla = new DataTable();
            dtV.Fill(tabla);
            return tabla;
        }

        public static DataTable cargarReservas()
        {
            try
            {
                SqlConnection conexion = Conexion.Conectar();
                string consultaQuery = "select * from ReservaPasajero;";
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

        public bool EliminarReservas(int idR)
        {        
            try
            {
                SqlConnection conexion = null;
                conexion = Conexion.Conectar();
                string consultaDelete = "DELETE FROM Pasajeros WHERE PasajeroID = @id";
                SqlCommand delete = new SqlCommand(consultaDelete, conexion);
                delete.Parameters.AddWithValue("@id", idR);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public static DataTable BuscarEnGestioPasajeros(string termino)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                string query = @"select *from Pasajeros WHERE Nombres LIKE @Termino OR Apellidos LIKE @Termino ;";

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

        public bool ActualizarReserva()
        {
            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string consultaUpdate = "UPDATE Reservas SET " +
                        "VueloID = @VueloID, " +
                        "FechaReserva = @FechaReserva, " +
                        "IDClaseViaje = @IDClaseViaje, " +
                        "PrecioTotal = @PrecioTotal " +
                        "WHERE ReservaID = @ReservaID";

                    using (SqlCommand update = new SqlCommand(consultaUpdate, conectar))
                    {
                        update.Parameters.AddWithValue("@ReservaID", ReservaID);
                        update.Parameters.AddWithValue("@VueloID", VueloID);
                        update.Parameters.AddWithValue("@FechaReserva", FechaReserva);
                        update.Parameters.AddWithValue("@IDClaseViaje", IDClaseViaje);
                        update.Parameters.AddWithValue("@PrecioTotal", PrecioTotal);
                        int filasAfectadas = update.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la reserva: " + ex.Message, "Error de Base de Datos");
                return false;
            }
        }


    }
}
