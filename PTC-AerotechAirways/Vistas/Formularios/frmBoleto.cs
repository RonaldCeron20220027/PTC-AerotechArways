using Entidades;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas.Formularios
{
    public partial class frmBoleto : Form
    {
        public frmBoleto()
        {
            InitializeComponent();
        
        }
        private void Mostrar()
        {
            dvgBoletos.DataSource = null;
            dvgBoletos.DataSource = Boleto.cargarBoleto();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try { 
            Boleto b = new Boleto();
            b.ReservaID = int.Parse(txtReserva.Text);
            b.Peso=int.Parse(txtPeso.Text);
            b.NumeroAvion=txtnumeroAvion.Text;
            b.Asiento = txtAsiento.Text;
            b.SobrecargoPeso = int.Parse(txtSobrepeso.Text);
            b.FechaHoraSalida=dtpSalida.Value;
            b.FechaHoraLlegada=dtpLlegada.Value;
            b.InsertarBoleto();
                Limpear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error, porfavor compruebe los datos ");
            }



        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dvgBoletos.DataSource = null;
                dvgBoletos.DataSource = Boleto.BuscarBoletos(txtBuscar.Text);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idB = int.Parse(dvgBoletos.CurrentRow.Cells[0].Value.ToString());
            Boleto b=new Boleto();
            if (b.EliminarBoleto(idB)==true){
                MessageBox.Show("Registro eliminado exitosamente");
                Mostrar();
            }
            else
            {
                MessageBox.Show("Error al eliminar ");
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvgBoletos.CurrentRow == null)
                {
                    MessageBox.Show("Por favor selecciona una fila para actualizar.");
                    return;
                }

                Boleto b = new Boleto();

                // Obtener ID
                if (!int.TryParse(dvgBoletos.CurrentRow.Cells[0].Value?.ToString(), out int idBoleto))
                {
                    MessageBox.Show("Error al obtener el ID del boleto.");
                    return;
                }

                // Validar ReservaID
                if (!int.TryParse(txtReserva.Text.Trim(), out int reservaID) || reservaID <= 0)
                {
                    MessageBox.Show("La Reserva debe ser un número válido.");
                    txtReserva.Focus();
                    return;
                }

                // Validar peso
                if (!decimal.TryParse(txtPeso.Text.Trim(), out decimal pesoDecimal) || pesoDecimal <= 0)
                {
                    MessageBox.Show("El peso debe ser un número positivo.");
                    txtPeso.Focus();
                    return;
                }
                int peso = (int)Math.Round(pesoDecimal);

                // Validar sobrepeso
                if (!int.TryParse(txtSobrepeso.Text.Trim(), out int sobrepeso) || sobrepeso < 0)
                {
                    MessageBox.Show("El sobrepeso debe ser un número mayor o igual a 0.");
                    txtSobrepeso.Focus();
                    return;
                }

                // Validar asiento
                if (string.IsNullOrWhiteSpace(txtAsiento.Text))
                {
                    MessageBox.Show("El asiento no puede estar vacío.");
                    txtAsiento.Focus();
                    return;
                }

                // Validar número de avión
                if (string.IsNullOrWhiteSpace(txtnumeroAvion.Text))
                {
                    MessageBox.Show("El número de avión no puede estar vacío.");
                    txtnumeroAvion.Focus();
                    return;
                }

                // Validar fechas
                if (dtpSalida.Value >= dtpLlegada.Value)
                {
                    MessageBox.Show("La fecha de salida debe ser anterior a la fecha de llegada.");
                    dtpSalida.Focus();
                    return;
                }

                b.IdBoleto = idBoleto;
                b.ReservaID = reservaID;                    
                b.Peso = peso;
                b.SobrecargoPeso = sobrepeso;
                b.Asiento = txtAsiento.Text.Trim();
                b.NumeroAvion = txtnumeroAvion.Text.Trim();
                b.FechaHoraSalida = dtpSalida.Value;       
                b.FechaHoraLlegada = dtpLlegada.Value;     

                if (b.ActualizarBoleto())
                {
                    MessageBox.Show("Boleto actualizado correctamente (todos los campos).", "Éxito");
                    Mostrar();
                    Limpear();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el boleto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void ConfigurarCamposNoEditables()
        {
           
            txtReserva.ReadOnly = true;
            txtReserva.BackColor = SystemColors.Control;
            txtReserva.TabStop = false; 

        }

        private void frmBoleto_Load(object sender, EventArgs e)
        {
            Mostrar();
            ConfigurarCamposNoEditables();
        }

        private void dvgBoletos_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dvgBoletos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = dvgBoletos.Rows[e.RowIndex];
                    MessageBox.Show($"Fila seleccionada: {e.RowIndex}. Cargando datos...");
                    txtReserva.Text = fila.Cells[1].Value?.ToString() ?? "";
                    txtPeso.Text = fila.Cells[2].Value?.ToString() ?? "";
                    txtSobrepeso.Text = fila.Cells[3].Value?.ToString() ?? "";
                    txtAsiento.Text = fila.Cells[4].Value?.ToString() ?? "";
                    txtnumeroAvion.Text = fila.Cells[7].Value?.ToString() ?? "";
                    if (DateTime.TryParse(fila.Cells[5].Value?.ToString(), out DateTime fechaSalida))
                    {
                        dtpSalida.Value = fechaSalida;  
                    }

                    if (DateTime.TryParse(fila.Cells[6].Value?.ToString(), out DateTime fechaLlegada))
                    {
                        dtpLlegada.Value = fechaLlegada; 
                    }
                    string verificacion = $"Datos cargados:\n" +
                                        $"Reserva: {txtReserva.Text}\n" +
                                        $"Peso: {txtPeso.Text}\n" +
                                        $"Sobrepeso: {txtSobrepeso.Text}\n" +
                                        $"Asiento: {txtAsiento.Text}\n" +
                                        $"NumeroAvion: {txtnumeroAvion.Text}";

                    MessageBox.Show(verificacion, "Verificación de carga");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error");
                }
            }
        }
        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea cualquier otro carácter
            }
        }

        private void SoloTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Limpear()
        {
            txtAsiento.Clear();
            txtnumeroAvion.Clear();
            txtPeso.Clear();
            txtReserva.Clear();
            txtSobrepeso.Clear();
            txtBuscar.Clear();
            dtpLlegada.Value=DateTime.Now;
            dtpSalida.Value=DateTime.Now;
        }

        private void txtReserva_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

