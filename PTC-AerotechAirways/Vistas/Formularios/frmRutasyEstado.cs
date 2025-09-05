using Entidades;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas.Formularios
{
    public partial class frmRutasyEstado : Form
    {
        public frmRutasyEstado()
        {
            InitializeComponent();
        }
        private void cargarDestinoPais()
        {
            cbDestino.DataSource = null;
            cbDestino.DataSource = Paises.cargarPais();
            cbDestino.DisplayMember = "NombrePais";
            cbDestino.ValueMember = "PaisID";
            cbDestino.SelectedIndex = -1;
        }
        private void cargarOrigenPais ()
        {
            cbOrigen.DataSource = null;
            cbOrigen.DataSource = Paises.cargarPais();
            cbOrigen.DisplayMember = "NombrePais";
            cbOrigen.ValueMember = "PaisID";
            cbOrigen.SelectedIndex = -1;
        }
        private void cargarEstado()
        {
            cbEstado.DataSource = null;
            cbEstado.DataSource = EstadoVuelo.cargarEstados();
            cbEstado.DisplayMember = "Descripcion";
            cbEstado.ValueMember = "EstadoVueloID";
            cbEstado.SelectedIndex = -1;
        }
      

        private void frmRutasyEstado_Load(object sender, EventArgs e)
        {
            cargarEstado();
            cargarOrigenPais();
            cargarDestinoPais();
            Mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try { 
            EstadoVuelo Ev=new EstadoVuelo();
            Ev.FechaHoraLlegadaProgramada = dtpHoraLlegada.Value;
            Ev.FechaHoraSalidaProgramada =dtpHorasalida.Value;
            Ev.NumeroVuelo=txtNumeroVuelo.Text;
            Ev.IdEstadoVuelo = Convert.ToInt32(cbEstado.SelectedValue);
            Ev.AeronaveID = int.Parse(txtAeronave.Text);
            Ev.RutaID = int.Parse(txtRuta.Text);
            Ev.RegistrarEstado  ();
            
            Rutas Rt = new Rutas();
            Rt.OrigenPaisID = Convert.ToInt32(cbOrigen.SelectedValue);
            Rt.DestinoPaisID=Convert.ToInt32(cbDestino.SelectedValue);
            Rt.RegistrarRuta();
                MessageBox.Show("Datos registrado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Mostrar()
        {
            dvgInfoVuelos.DataSource = null;
            dvgInfoVuelos.DataSource = EstadoVuelo.cargarInfoVuelos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idv = int.Parse(dvgInfoVuelos.CurrentRow.Cells[0].Value.ToString());
            EstadoVuelo b = new EstadoVuelo();
            if (b.EliminarVuelo(idv) == true)
            {
                MessageBox.Show("Registro eliminado exitosamente");
                limpiar();
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
                dvgInfoVuelos.DataSource = null;
                dvgInfoVuelos.DataSource =EstadoVuelo.buscarVuelo(txtBuscar.Text);
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
                if (dvgInfoVuelos.CurrentRow == null)
                {
                    MessageBox.Show("Por favor selecciona un vuelo para actualizar.");
                    return;
                }

                EstadoVuelo v = new EstadoVuelo();

                if (!int.TryParse(dvgInfoVuelos.CurrentRow.Cells[0].Value?.ToString(), out int vueloID))
                {
                    MessageBox.Show("Error al obtener el ID del vuelo.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNumeroVuelo.Text))
                {
                    MessageBox.Show("El número de vuelo no puede estar vacío.");
                    txtNumeroVuelo.Focus();
                    return;
                }

                if (txtNumeroVuelo.Text.Trim().Length > 10)
                {
                    MessageBox.Show("El número de vuelo no puede tener más de 10 caracteres.");
                    txtNumeroVuelo.Focus();
                    return;
                }

                if (int.Parse(txtRuta.Text) == null || !int.TryParse(txtRuta.Text.ToString(), out int rutaID))
                {
                    MessageBox.Show("Debe seleccionar una ruta válida.");
                    txtRuta.Focus();
                    return;
                }

                if (cbEstado.SelectedValue == null || !int.TryParse(cbEstado.SelectedValue.ToString(), out int estadoVueloID))
                {
                    MessageBox.Show("Debe seleccionar un estado de vuelo válido.");
                    cbEstado.Focus();
                    return;
                }

                if (int.Parse(txtAeronave.Text) == null || !int.TryParse(txtAeronave.Text.ToString(), out int aeronaveID))
                {
                    MessageBox.Show("Debe seleccionar una aeronave válida.");
                    txtAeronave.Focus();
                    return;
                }

                if (dtpHorasalida.Value >= dtpHoraLlegada.Value)
                {
                    MessageBox.Show("La fecha de salida debe ser anterior a la fecha de llegada.");
                    dtpHorasalida.Focus();
                    return;
                }

                if (dtpHorasalida.Value < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de salida no puede ser anterior a hoy.");
                    dtpHorasalida.Focus();
                    return;
                }

                v.VueloID = vueloID;
                v.NumeroVuelo = txtNumeroVuelo.Text.Trim();
                v.RutaID = rutaID;
                v.IdEstadoVuelo = estadoVueloID;
                v.AeronaveID = aeronaveID;
                v.FechaHoraSalidaProgramada = dtpHorasalida.Value;
                v.FechaHoraLlegadaProgramada = dtpHoraLlegada.Value;

                if (v.ActualizarVuelo())
                {
                    MessageBox.Show("Vuelo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mostrar(); 
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el vuelo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dvgInfoVuelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = dvgInfoVuelos.Rows[e.RowIndex];
                    txtNumeroVuelo.Text = fila.Cells["NumeroVuelo"].Value?.ToString() ?? "";
                    if (DateTime.TryParse(fila.Cells["FechaHoraSalidaProgramada"].Value?.ToString(), out DateTime fechaSalida))
                    {
                        dtpHorasalida.Value = fechaSalida;
                    }
                    if (DateTime.TryParse(fila.Cells["FechaHoraLlegadaProgramada"].Value?.ToString(), out DateTime fechaLlegada))
                    {
                        dtpHoraLlegada.Value = fechaLlegada;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message}");
                }
            }

        }

        private void limpiar()
        {
            cbEstado.SelectedIndex = -1;
            cbDestino.SelectedIndex = -1;
            cbOrigen.SelectedIndex = -1;
            txtBuscar.Clear();
            txtNumeroVuelo.Clear();
            txtAeronave.Clear();
            txtRuta.Clear();
            dtpHoraLlegada.Value=DateTime.Now;
            dtpHorasalida.Value=DateTime.Now;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void SoloTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
