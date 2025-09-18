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
    public partial class frmHome : Form
    {
        

        public frmHome()
        {
            InitializeComponent();
            ConstruirFormularioResponsive();
        }

        private void ConstruirFormularioResponsive()
        {
            this.Text = "Gestión de Aerolíneas";
            this.Size = new Size(1600, 900);
            this.StartPosition = FormStartPosition.CenterScreen;
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

        
            mainLayout.Controls.Add(SeccionPaises(), 0, 0);
            mainLayout.Controls.Add(SeccionTipoAeronave(), 1, 0);
            mainLayout.Controls.Add(SeccionAerolineas(), 2, 0);

            this.Controls.Add(mainLayout);
        }
        private Panel SeccionAerolineas()
        {
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, ColumnCount = 2 };
            layout.RowCount = 5;

            layout.Controls.Add(new Label { Text = "Nombre Aerolínea:", Anchor = AnchorStyles.Right }, 0, 0);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 0);

            layout.Controls.Add(new Label { Text = "ID del País:", Anchor = AnchorStyles.Right }, 0, 1);
            layout.Controls.Add(new ComboBox { Dock = DockStyle.Fill }, 1, 1);

            layout.Controls.Add(new Label { Text = "Aeronave:", Anchor = AnchorStyles.Right }, 0, 2);
            layout.Controls.Add(new ComboBox { Dock = DockStyle.Fill }, 1, 2);

            layout.Controls.Add(new Label { Text = "Matrícula:", Anchor = AnchorStyles.Right }, 0, 3);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 3);

            layout.Controls.Add(new Label { Text = "Fecha Adquisición:", Anchor = AnchorStyles.Right }, 0, 4);
            layout.Controls.Add(new DateTimePicker { Dock = DockStyle.Fill }, 1, 4);

            return new Panel { Dock = DockStyle.Fill, Controls = { layout } };
        }

        private Panel SeccionTipoAeronave()
        {
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, ColumnCount = 2 };
            layout.RowCount = 5;

            layout.Controls.Add(new Label { Text = "Modelo:", Anchor = AnchorStyles.Right }, 0, 0);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 0);

            layout.Controls.Add(new Label { Text = "Fabricante:", Anchor = AnchorStyles.Right }, 0, 1);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 1);

            layout.Controls.Add(new Label { Text = "Capacidad Pasajeros:", Anchor = AnchorStyles.Right }, 0, 2);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 2);

            layout.Controls.Add(new Label { Text = "Capacidad Carga (KG):", Anchor = AnchorStyles.Right }, 0, 3);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 3);

            var botones = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };
            botones.Controls.Add(new Button { Text = "Agregar" });
            botones.Controls.Add(new Button { Text = "Eliminar" });
            botones.Controls.Add(new Button { Text = "Buscar" });

            layout.Controls.Add(botones, 0, 4);
            layout.SetColumnSpan(botones, 2);

            return new Panel { Dock = DockStyle.Fill, Controls = { layout } };
        }

        private Panel SeccionPaises()
        {
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, ColumnCount = 2 };
            layout.RowStyles.Clear();
            layout.RowCount = 4;

            layout.Controls.Add(new Label { Text = "País:", Anchor = AnchorStyles.Right }, 0, 0);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 0);

            layout.Controls.Add(new Label { Text = "Código ISO:", Anchor = AnchorStyles.Right }, 0, 1);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 1);

            layout.Controls.Add(new Label { Text = "Prefijo TLF:", Anchor = AnchorStyles.Right }, 0, 2);
            layout.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 2);

            layout.Controls.Add(new Label { Text = "Continente:", Anchor = AnchorStyles.Right }, 0, 3);
            layout.Controls.Add(new ComboBox { Dock = DockStyle.Fill }, 1, 3);

            return new Panel { Dock = DockStyle.Fill, Controls = { layout } };
        }

        public void loadformR()
        {

            if (this.pnlprincipal.Controls.Count > 0) ;
           
            frmReserva frmReserva = new frmReserva();
            frmReserva.TopLevel = false;
            frmReserva.Dock= DockStyle.Fill;
            this.pnlprincipal.Controls.Add(frmReserva);
            this.pnlprincipal.Tag = frmReserva;
             frmReserva.Show();
        }

        public void loadformG()
        {
            if (this.pnlprincipal.Controls.Count > 0) ;
                
            frmGestionAerolineas G = new frmGestionAerolineas();
            G.TopLevel = false;
            G.Dock = DockStyle.Fill;
            this.pnlprincipal.Controls.Add(G);
            this.pnlprincipal.Tag = G;
            G.Show();
        }

        private void btnGestionAerolinea_Click(object sender, EventArgs e)
        {
            loadformG();
        }

        public void loadformRE()
        {
            if (this.pnlprincipal.Controls.Count > 0) ;
            frmRutasyEstado RE = new frmRutasyEstado();
            RE.TopLevel = false;
            RE.Dock = DockStyle.Fill;
            this.pnlprincipal.Controls.Add(RE);
            this.pnlprincipal.Tag = RE;
            RE.Show();
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            loadformR();
        }

        private void btnEstadoVuelo_Click(object sender, EventArgs e)
        {
            loadformRE();
        }

        private void btnBoleto_Click(object sender, EventArgs e)
        {
            loadformBO();
        }

        public void loadformBO()
        {
            if (this.pnlprincipal.Controls.Count > 0) ;
            frmBoleto BO = new frmBoleto();
            BO.TopLevel = false;
            BO.Dock = DockStyle.Fill;
            this.pnlprincipal.Controls.Add(BO);
            this.pnlprincipal.Tag = BO;
            BO.Show();
        }

        private void btnVuelos_Click(object sender, EventArgs e)
        {
            pnlSubmenuEq.Visible = !pnlSubmenuEq.Visible;
            pnlSubmenuEq.Text = pnlSubmenuEq.Visible ? "Ocultar opciones" : "Mostrar opciones";
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            pnlSubmenuEq.Visible = false;
            pnlSubmenusRserva.Visible= false;
            pnlAdministracionAeronave.Visible = false;
        }

        private void btnReservasPa_Click(object sender, EventArgs e)
        {
            pnlSubmenusRserva.Visible = !pnlSubmenusRserva.Visible;
            pnlSubmenusRserva.Text = pnlSubmenusRserva.Visible ? "Ocultar opciones" : "Mostrar opciones";
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            pnlAdministracionAeronave.Visible = !pnlAdministracionAeronave.Visible;
            pnlAdministracionAeronave.Text = pnlAdministracionAeronave.Visible ? "Ocultar opciones" : "Mostrar opciones";
        }
    }
}

