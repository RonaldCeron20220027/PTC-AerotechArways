using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionDB;

namespace Modelo.Entidades
{
    public class Boleto
    {
        private int idBoleto;
        private int reservaID;
        private double peso;
        private double sobrecargoPeso;
        private string asiento;
        private DateTime fechaHoraSalida;
        private DateTime fechaHoraLlegada;
        private string numeroAvion;

        public int IdBoleto { get => idBoleto; set => idBoleto = value; }
        public int ReservaID { get => reservaID; set => reservaID = value; }
        public double Peso { get => peso; set => peso = value; }
        public double SobrecargoPeso { get => sobrecargoPeso; set => sobrecargoPeso = value; }
        public string Asiento { get => asiento; set => asiento = value; }
        public DateTime FechaHoraSalida { get => fechaHoraSalida; set => fechaHoraSalida = value; }
        public DateTime FechaHoraLlegada { get => fechaHoraLlegada; set => fechaHoraLlegada = value; }
        public string NumeroAvion { get => numeroAvion; set => numeroAvion = value; }


        public static DataTable cargarBoleto()
        {
            try
            {
                SqlConnection conexion = Conexion.Conectar();
                string consultaQuery = "select * from ActualizacionBoleto;";
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

        public  bool InsertarBoleto()
        {
            try
            {
                SqlConnection conexion = Conexion.Conectar();
                string consultaQueryInsert = "INSERT INTO Boletos (ReservaID,Peso, SobrecargoPorPeso, Asiento, FechaHoraSalida, FechaHoraLlegada, NumeroAvion) " +
                "VALUES (@ReservaID,@Peso,@SobrecargoPorPeso, @Asiento, @FechaHoraSalida, @FechaHoraLlegada, @NumeroAvion)";
                SqlCommand insertar = new SqlCommand(consultaQueryInsert, conexion);
                insertar.Parameters.AddWithValue("@idBoleto", idBoleto);
                insertar.Parameters.AddWithValue("ReservaID", ReservaID);
                insertar.Parameters.AddWithValue("@Peso", Peso);
                insertar.Parameters.AddWithValue("@SobrecargoPorPeso", SobrecargoPeso);
                insertar.Parameters.AddWithValue("@Asiento", Asiento);
                insertar.Parameters.AddWithValue("@FechaHoraSalida", FechaHoraSalida);
                insertar.Parameters.AddWithValue("@FechaHoraLlegada", FechaHoraLlegada);
                insertar.Parameters.AddWithValue("@NumeroAvion", NumeroAvion);
                insertar.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public bool EliminarBoleto(int idB)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.Conectar();
                string consultaDelete = "DELETE FROM Boletos WHERE idBoleto = @id";
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

    
        public bool ActualizarBoleto()
        {
            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string consultaUpdate = "UPDATE Boletos SET " +"ReservaID = @ReservaID, " +"Peso = @Peso, " +"SobrecargoPorPeso = @SobrecargoPorPeso, " +"Asiento = @Asiento, " +"NumeroAvion = @NumeroAvion, " +
                    "FechaHoraSalida = @FechaHoraSalida, " + "FechaHoraLlegada = @FechaHoraLlegada " + "WHERE idBoleto = @idBoleto";

                    using (SqlCommand update = new SqlCommand(consultaUpdate, conectar))
                    {
                        update.Parameters.AddWithValue("@idBoleto", IdBoleto);
                        update.Parameters.AddWithValue("@ReservaID", ReservaID);        
                        update.Parameters.AddWithValue("@Peso", Peso);
                        update.Parameters.AddWithValue("@SobrecargoPorPeso", SobrecargoPeso);
                        update.Parameters.AddWithValue("@Asiento", Asiento);
                        update.Parameters.AddWithValue("@NumeroAvion", NumeroAvion);
                        update.Parameters.AddWithValue("@FechaHoraSalida", FechaHoraSalida);    
                        update.Parameters.AddWithValue("@FechaHoraLlegada", FechaHoraLlegada);  

                        update.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
                return false;
            }
        }

        public static DataTable BuscarBoletos(string termino)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                string query = @"
            SELECT IdBoleto, SobrecargoPorPeso, Peso, Asiento, FechaHoraSalida, FechaHoraLlegada, NumeroAvion FROM Boletos
            WHERE CAST(IdBoleto AS NVARCHAR) LIKE @Termino OR Asiento LIKE @Termino OR NumeroAvion LIKE @Termino OR FORMAT(FechaHoraSalida, 'yyyy-MM-dd HH:mm') LIKE @Termino";

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
