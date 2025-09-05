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
    public partial class frmGestionAerolineas : Form
    {
        public frmGestionAerolineas()
        {
            InitializeComponent();
            InicializarLayout();
        }

        private void InicializarLayout()
        {
           
            this.Text = "Gestión de Aerolíneas";
            this.Size = new Size(1000, 600);
            this.AutoScaleMode = AutoScaleMode.Font;

          
            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                AutoSize = true
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));

            

            this.Controls.Add(mainLayout);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try {

                Paises p = new Paises();
                p.CodigoISO = txtCodigoIso.Text;
                p.NombrePais = txtPais.Text;
                p.PrefijoTelefonico = txtPrefijo.Text;
                p.Continente = cbContinente.Text;
                p.RegistrarPais();


                Aerolineas Aero = new Aerolineas();
                Aero.PaisID = Convert.ToInt32(cbPais.SelectedValue);
            Aero.Nombre=txtNombreAerolinea.Text;
            Aero.RegistrarAeroline();                                   
                
           

            TipoAeronave TPA = new TipoAeronave();
            TPA.CapacidadCargaKG = double.Parse(txtCargaKG.Text);
            TPA.CapacidadPasajeros = int.Parse(txtCapacidad.Text);
            TPA.Modelo=txtmodelo.Text;
            TPA.Fabricante=txtFabricante.Text;
            TPA.RegistrarTipoAeronave();


            Aeronaves ARN = new Aeronaves();
            ARN.Matricula =txtmatricula.Text;
            ARN.FechaAdquisicion = dtpFechaAdquision.Value;
            ARN.TipoAeronaveID = int.Parse(txtTipoAeronave.Text);
            ARN.AerolineaID = int.Parse(txtAerolinea.Text);
            ARN.RegistrarAeronave();
                Mostrar();
                limpiar();

            MessageBox.Show("Registro del boleto exitoso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error porfavor revise que lleno todos los campos correctamente");
            }

        }
        private void Mostrar()
        {
            dvgGestioAeronaves.DataSource = null;
            dvgGestioAeronaves.DataSource = Aerolineas.cargarAeronaves();
        }

        private void frmGestionAerolineas_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idV= int.Parse(dvgGestioAeronaves.CurrentRow.Cells[0].Value.ToString());       
            Aeronaves aero= new Aeronaves();
          
            if ( aero.EliminarAerolinea(idV)==true)
            {
                MessageBox.Show("Registro eliminado exitosamente");
                Mostrar();
                limpiar();
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
                dvgGestioAeronaves.DataSource = null;
                dvgGestioAeronaves.DataSource = Aerolineas.BuscarEnGestioAeronaves(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void limpiar()
        {
            txtAerolinea.Clear();
            txtBuscar.Clear();
            txtCapacidad.Clear();
            txtCargaKG.Clear();
            txtCodigoIso.Clear();
            txtFabricante.Clear();
            cbPais.SelectedIndex=-1;
            txtmatricula.Clear();
            txtPrefijo.Clear();
            txtTipoAeronave.Clear();
            cbContinente.SelectedIndex = -1;
            dtpFechaAdquision.Value=DateTime.Now;
        }

    }
}
