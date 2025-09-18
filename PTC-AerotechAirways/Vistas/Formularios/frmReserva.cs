using ConexionDB;
using Entidades;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas.Formularios
{
    public partial class frmReserva : Form
    {
        private int pasajeroIDSeleccionado = -1;
        private int reservaID = -1;
        public frmReserva()
        {
            InitializeComponent();
        }

        private void cargarPais()
        {
            cbPais.DataSource = null;
            cbPais.DataSource = Paises.cargarPais();
            cbPais.DisplayMember = "NombrePais";
            cbPais.ValueMember = "PaisID";
            cbPais.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Pasajeros pj = new Pasajeros();
                pj.Nombres = txtNombre.Text;
                pj.Apellidos = txtApellido.Text;
                pj.FechaNacimiento = dtpNacimiento.Value;
                pj.NumeroPasaporte = txtPasaporte.Text;
                pj.PaisNacionalidadID = Convert.ToInt32(cbPais.SelectedValue);
                pj.RegistrarPasajeros();
                Mostrar();
                Limpiar();
                MessageBox.Show("Pasajero registrado existosamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error por favor verifique este bien los campos" + ex);

            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtPasaporte.Clear();
            dtpNacimiento.Value=DateTime.Now;
            cbPais.SelectedIndex=-1;


            cbClase.SelectedIndex=-1;
            cbReserva.SelectedIndex=1;
            cbVuelo.SelectedIndex=1;
            dtpReserva.Value=DateTime.Now;

        }

        private void Mostrar()
        {
            dvgReserva.DataSource = null;
            dvgReserva.DataSource = Pasajeros.cargarPasajeros();

            dvgReservas.DataSource = null;
            dvgReservas.DataSource=Reservas.cargarReservas();

            dvgListaPasajero.DataSource = null;
            dvgListaPasajero.DataSource = Reservas.ListaPasajeros();
        }

        private void frmReserva_Load(object sender, EventArgs e)
        {

            Mostrar();
            cargarClase();
            cargarPais();
            cargarVuelos();
            cargarReserva();
        }
        private void cargarReserva()
        {
            cbReserva.DataSource = null;
            cbReserva.DataSource = Reservas.cargarPasajeros();
            cbReserva.DisplayMember = "PasajeroID";
            cbReserva.ValueMember = "PasajeroID";
            cbReserva.SelectedIndex = -1;

        }

        private void cargarClase()
        {
            cbClase.DataSource = null;
            cbClase.DataSource = Reservas.cargarClase();
            cbClase.DisplayMember = "Descripcion";
            cbClase.ValueMember = "ClaseViajeID";
            cbClase.SelectedIndex = -1;
        }

        private void cargarVuelos()
        {
            cbVuelo.DataSource = null;
            cbVuelo.DataSource = Reservas.cargarVuelos();
            cbVuelo.DisplayMember = "NumeroVuelo";
            cbVuelo.ValueMember = "VueloID";
            cbVuelo.SelectedIndex = -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idr = int.Parse(dvgReserva.CurrentRow.Cells[0].Value.ToString());
            Reservas rvs = new Reservas();

            if (rvs.EliminarPasajero(idr) == true)
            {
                MessageBox.Show("Registro eliminado exitosamente");
                Mostrar();
            }
            else
            {
                MessageBox.Show("Error al eliminar ");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dvgReserva.DataSource = null;
                dvgReserva.DataSource = Reservas.BuscarEnGestioPasajeros(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                if (dvgReserva.CurrentRow == null || dvgReserva.CurrentRow.IsNewRow || dvgReserva.CurrentRow.Cells.Count == 0)
                {
                    MessageBox.Show("Por favor selecciona una reserva válida para actualizar.");
                    return;
                }

                if (!int.TryParse(dvgReserva.CurrentRow.Cells[0].Value?.ToString(), out int PasajeroID))
                {
                    MessageBox.Show("Error al obtener el ID del Pasajero.");
                    return;
                }

                
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre válido.");
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Debe ingresar un apellido válido.");
                    txtApellido.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPasaporte.Text))
                {
                    MessageBox.Show("Debe ingresar un número de pasaporte válido.");
                    txtPasaporte.Focus();
                    return;
                }

                if (cbPais.SelectedValue == null || !int.TryParse(cbPais.SelectedValue.ToString(), out int PaisNacionalidadID))
                {
                    MessageBox.Show("Debe seleccionar un país válido.");
                    cbPais.Focus();
                    return;
                }

                Pasajeros P = new Pasajeros
                {
                    PasajeroID= PasajeroID,
                    Nombres = txtNombre.Text.Trim(),
                    Apellidos = txtApellido.Text.Trim(),
                    FechaNacimiento = dtpNacimiento.Value,
                    PaisNacionalidadID = PaisNacionalidadID,
                    NumeroPasaporte = txtPasaporte.Text.Trim()
                };

                if (P.ActualizarPasajero())
                {
                    MessageBox.Show("Reserva actualizada correctamente.", "Éxito");
                    Mostrar(); 
                }
                else
                {
                    MessageBox.Show("Error: No se pudo actualizar la reserva.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        private void dvgReserva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dvgReserva.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow fila = dvgReserva.Rows[e.RowIndex];

                if (int.TryParse(fila.Cells["PasajeroID"].Value?.ToString(), out int id))
                {
                    pasajeroIDSeleccionado = id;
                }
                else
                {
                    pasajeroIDSeleccionado = -1;
                }

                txtNombre.Text = fila.Cells["Nombres"].Value?.ToString() ?? "";
                txtApellido.Text = fila.Cells["Apellidos"].Value?.ToString() ?? "";
                txtPasaporte.Text = fila.Cells["NumeroPasaporte"].Value?.ToString() ?? "";

                if (DateTime.TryParse(fila.Cells["FechaNacimiento"].Value?.ToString(), out DateTime fechaNacimiento))
                {
                    dtpNacimiento.Value = fechaNacimiento;
                }
                string paisDescripcion = fila.Cells["Pais"].Value?.ToString() ?? "";
                SeleccionarPais(cbPais, "NombrePais", paisDescripcion);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }
        private void SeleccionarPais(ComboBox cmb, string columnName, string valueToFind)
        {
            try
            {
                if (cmb.DataSource is DataTable dt && !string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(valueToFind))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row.Table.Columns.Contains(columnName) && row[columnName].ToString() == valueToFind)
                        {
                            cmb.SelectedValue = row[cmb.ValueMember];
                            return;
                        }
                    }

                    MessageBox.Show($"No se encontró el país con {columnName} = '{valueToFind}'");
                }
                else
                {
                    MessageBox.Show("El ComboBox no tiene un DataSource válido o los parámetros están vacíos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar país: " + ex.Message);
            }
        }
        private void SeleccionarPasajero(ComboBox cmb, string columnName, string valueToFind)
        {
            try
            {
                DataTable dt = cmb.DataSource as DataTable;
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[columnName].ToString() == valueToFind)
                        {
                            cmb.SelectedValue = row[cmb.ValueMember];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
        }
        private void SeleccionarVuelo(ComboBox cmb, string columnName, string valueToFind)
        {
            try
            {
                DataTable dt = cmb.DataSource as DataTable;
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[columnName].ToString() == valueToFind)
                        {
                            cmb.SelectedValue = row[cmb.ValueMember];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        private void SeleccionarClase(ComboBox cmb, string columnName, string valueToFind)
        {
            try
            {
                DataTable dt = cmb.DataSource as DataTable;
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[columnName].ToString() == valueToFind)
                        {
                            cmb.SelectedValue = row[cmb.ValueMember];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }


        private void SoloTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Reservas rsv = new Reservas();
            rsv.IDClaseViaje = Convert.ToInt32(cbClase.SelectedValue);
            rsv.FechaReserva = dtpReserva.Value;
            rsv.PasajeroID = Convert.ToInt32(cbReserva.SelectedValue);
            rsv.VueloID = Convert.ToInt32(cbVuelo.SelectedValue);
            rsv.PrecioTotal = double.Parse(txtPrecioTotal.Text);
            rsv.RegistrarReserva();
            Limpiar();
            Mostrar();
        }

        private void btnRefrescarPasajeros_Click(object sender, EventArgs e)
        {
            cargarReserva();
        }


        private void cbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClase.SelectedIndex > -1 && cbClase.SelectedItem is DataRowView drv)
            {
                int claseID = Convert.ToInt32(drv["ClaseViajeID"]);

                Dictionary<int, decimal> preciosPorClase = new Dictionary<int, decimal>()
        {
            { 3, 350 },   // Económica
            { 2, 420 },   // Ejecutiva
            { 1, 1200 }   // Primera Clase
        };

                if (preciosPorClase.ContainsKey(claseID))
                {
                    txtPrecioTotal.Text = preciosPorClase[claseID].ToString("F2");
                }
                else
                {
                    txtPrecioTotal.Text = "0.00";
                }
            }
            else
            {
                txtPrecioTotal.Text = "";
            }
        }

        private void btnEliminarRV_Click(object sender, EventArgs e)
        {
            int idr = int.Parse(dvgReservas.CurrentRow.Cells[0].Value.ToString());
            Reservas rvs = new Reservas();

            if (rvs.EliminarReserva(idr) == true)
            {
                MessageBox.Show("Registro eliminado exitosamente");
                Mostrar();
            }
            else
            {
                MessageBox.Show("Error al eliminar ");
            }
        }

        private void btnActualizarReserva_Click(object sender, EventArgs e)
        {

        }

        private void dvgReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = dvgReserva.Rows[e.RowIndex];

                    string Pasajero = fila.Cells["PasajeroID"].Value?.ToString() ?? "";
                    SeleccionarPasajero(cbReserva, "PasajeroID", Pasajero);


                    //if (DateTime.TryParse(fila.Cells["FechaReserva"].Value?.ToString(), out DateTime fechaReserva))
                    //{
                    //    dtpReserva.Value = fechaReserva;
                    //}


                    //string numeroVuelo = fila.Cells["VueloID"].Value?.ToString() ?? "";
                    //SeleccionarVuelo(cbVuelo, "NumeroVuelo", numeroVuelo);

                    //string claseViaje = fila.Cells["IDClaseViaje"].Value?.ToString() ?? "";
                    //SeleccionarClase(cbClase, "Descripcion", claseViaje);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message}");
                }
            }
        }
    }
}
