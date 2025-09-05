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
    public class Pasajeros
    {
        
        private string nombres;
        private string apellidos;
        private DateTime fechaNacimiento;
        private int paisNacionalidadID;
        private string numeroPasaporte;

      
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int PaisNacionalidadID { get => paisNacionalidadID; set => paisNacionalidadID = value; }
        public string NumeroPasaporte { get => numeroPasaporte; set => numeroPasaporte = value; }

        public bool RegistrarPasajeros()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string query = "INSERT INTO  Pasajeros(nombres,apellidos,fechaNacimiento,paisNacionalidadID,numeroPasaporte)" +
                    "VALUES (@nombres,@apellidos,@fechaNacimiento,@paisNacionalidadID,@numeroPasaporte)";
                SqlCommand inst = new SqlCommand(query, con);
                inst.Parameters.AddWithValue("@nombres", nombres);
                inst.Parameters.AddWithValue("@apellidos", apellidos);
                inst.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                inst.Parameters.AddWithValue("@paisNacionalidadID", paisNacionalidadID);
                inst.Parameters.AddWithValue("@numeroPasaporte", numeroPasaporte);
                inst.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error porfavor verifique los campos" + ex);
                return false;
            }


        }

        public bool ActualizarPasajero()
        {
            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string consultaUpdate = "UPDATE Pasajeros SET " +
                        "Nombres = @Nombres, " +
                        "Apellidos = @Apellidos, " +
                        "FechaNacimiento = @FechaNacimiento, " +
                        "NumeroPasaporte = @NumeroPasaporte " +
                        "PaisNacionalidadID = @PaisNacionalidadID"+
                        "WHERE PasajeroID = @PasajeroID";

                    using (SqlCommand update = new SqlCommand(consultaUpdate, conectar))
                    {
                        update.Parameters.AddWithValue("@ReservaID", Nombres);
                        update.Parameters.AddWithValue("@Apellidos", Apellidos);
                        update.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                        update.Parameters.AddWithValue("@NumeroPasaporte", NumeroPasaporte );
                        update.Parameters.AddWithValue("@PaisNacionalidadID", PaisNacionalidadID);
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






        public static DataTable cargarPasajeros()
        {
            try
            {
                SqlConnection conexion = Conexion.Conectar();
                string consultaQuery = "select*from Pasajeros;";
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

    }
}
