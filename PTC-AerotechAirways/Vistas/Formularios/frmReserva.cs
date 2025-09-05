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

                MessageBox.Show("Pasajero registrado existosamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error por favor verifique este bien los campos" + ex);

            }
        }

        private void Mostrar()
        {
            dvgReserva.DataSource = null;
            dvgReserva.DataSource = Pasajeros.cargarPasajeros();
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
            cbReserva.DataSource = Reservas.cargarReservasCB();
            cbReserva.DisplayMember = "PasajeroID";
            cbReserva.ValueMember = "ReservaID";
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

            if (rvs.EliminarReservas(idr) == true)
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
                if (dvgReserva.CurrentRow == null)
                {
                    MessageBox.Show("Por favor selecciona una reserva para actualizar.");
                    return;
                }

                Pasajeros P = new Pasajeros();

                if (!int.TryParse(dvgReserva.CurrentRow.Cells[0].Value?.ToString(), out int PasajeroID))
                {
                    MessageBox.Show("Error al obtener el ID del Pasajero.");
                    return;
                }

                if (txtNombre.Text == null )
                {
                    MessageBox.Show("Debe seleccionar un vuelo válido.");
                    txtNombre.Focus();
                    return;
                }

                if (txtApellido.Text == null)
                {
                    MessageBox.Show("Debe seleccionar una clase de viaje válida.");
                    txtApellido.Focus();
                    return;
                }

                if (txtPasaporte.Text == null)
                {
                    MessageBox.Show("Debe seleccionar una clase de viaje válida.");
                    txtPasaporte.Focus();
                    return;
                }

                if (cbPais.SelectedValue == null || !int.TryParse(cbPais.Text.ToString(), out int PaisNacionalidadID))
                {
                    MessageBox.Show("Debe seleccionar una clase de viaje válida.");
                    cbPais.Focus();
                    return;
                }

             

               P.Nombres = txtNombre.Text;
               P.Apellidos = txtApellido.Text;
               P.FechaNacimiento = dtpNacimiento.Value;
               P.PaisNacionalidadID = Convert.ToInt32(cbPais.SelectedValue);
                P.NumeroPasaporte = txtPasaporte.Text;
                P.NumeroPasaporte = txtPasaporte.Text;

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
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dvgReserva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = dvgReserva.Rows[e.RowIndex];

                  
                    txtPrecioTotal.Text = fila.Cells[9].Value?.ToString() ?? "";  

                 
                    if (DateTime.TryParse(fila.Cells[4].Value?.ToString(), out DateTime fechaReserva))
                    {
                        dtpReserva.Value = fechaReserva;
                    }

                  
                    string numeroVuelo = fila.Cells[5].Value?.ToString() ?? "";  
                    SeleccionarEnComboBox(cbVuelo, "NumeroVuelo", numeroVuelo);

                   
                    string claseViaje = fila.Cells[8].Value?.ToString() ?? "";  
                    SeleccionarEnComboBox(cbClase, "Descripcion", claseViaje);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message}");
                }

            }
        }
        private void SeleccionarEnComboBox(ComboBox cmb, string columnName, string valueToFind)
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
            Mostrar();
        }
    }
}
