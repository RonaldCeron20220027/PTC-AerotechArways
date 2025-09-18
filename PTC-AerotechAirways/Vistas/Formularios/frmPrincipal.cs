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
    public partial class frmPrincipal : Form
    {
        frmRegistrarUsuario frmRegistrarUsuario = new frmRegistrarUsuario();
        frmLogin frmLogin = new frmLogin();

        public frmPrincipal()
        {
            InitializeComponent();
            ConstruirFormularioResponsive();
            frmRegistrarUsuario.Anchor = AnchorStyles.None;
            frmLogin.Anchor = AnchorStyles.None;
        }

        private void ConstruirFormularioResponsive()
        {
            this.Text = "Gestión de Aerolíneas";
            this.Size = new Size(1600, 900);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Font;

            // Layout principal
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

            // Secciones
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


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            pnlprincipal.Controls.Clear();
            pnlprincipal.Controls.Add(frmLogin);
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            pnlprincipal.Controls.Clear();
            pnlprincipal.Controls.Add(frmRegistrarUsuario);
        }

    }
}
