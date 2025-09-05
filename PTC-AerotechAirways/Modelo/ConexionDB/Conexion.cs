﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionDB
{
    public class Conexion
    {
        private static string servidor = "LAB03-DS-EQ09\\SQLEXPRESS";
        private static string basedeDatos = "AirTechAirways";


        public static SqlConnection Conectar()
        {
            try
            {
                string cadena = $"Data Source= {servidor}; Initial Catalog={basedeDatos}; Integrated Security=true;";
                SqlConnection conexion = new SqlConnection(cadena);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar al servidor" + ex, "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }    
}
