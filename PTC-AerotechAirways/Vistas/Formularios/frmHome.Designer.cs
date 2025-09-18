namespace Vistas.Formularios
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.pnlAdministracionAeronave = new System.Windows.Forms.Panel();
            this.btnGestionAerolinea = new System.Windows.Forms.Button();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.pnlSubmenuEq = new System.Windows.Forms.Panel();
            this.btnEstadoVuelo = new System.Windows.Forms.Button();
            this.btnVuelos = new System.Windows.Forms.Button();
            this.pnlSubmenusRserva = new System.Windows.Forms.Panel();
            this.btnBoleto = new System.Windows.Forms.Button();
            this.btnReserva = new System.Windows.Forms.Button();
            this.btnReservasPa = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlprincipal = new System.Windows.Forms.Panel();
            this.pnlLateral.SuspendLayout();
            this.pnlAdministracionAeronave.SuspendLayout();
            this.pnlSubmenuEq.SuspendLayout();
            this.pnlSubmenusRserva.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLateral
            // 
            this.pnlLateral.AutoScroll = true;
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(202)))));
            this.pnlLateral.Controls.Add(this.pnlAdministracionAeronave);
            this.pnlLateral.Controls.Add(this.btnRegistro);
            this.pnlLateral.Controls.Add(this.pnlSubmenuEq);
            this.pnlLateral.Controls.Add(this.btnVuelos);
            this.pnlLateral.Controls.Add(this.pnlSubmenusRserva);
            this.pnlLateral.Controls.Add(this.btnReservasPa);
            this.pnlLateral.Controls.Add(this.panelLogo);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(250, 450);
            this.pnlLateral.TabIndex = 6;
            // 
            // pnlAdministracionAeronave
            // 
            this.pnlAdministracionAeronave.Controls.Add(this.btnGestionAerolinea);
            this.pnlAdministracionAeronave.Location = new System.Drawing.Point(3, 320);
            this.pnlAdministracionAeronave.Name = "pnlAdministracionAeronave";
            this.pnlAdministracionAeronave.Size = new System.Drawing.Size(247, 42);
            this.pnlAdministracionAeronave.TabIndex = 0;
            // 
            // btnGestionAerolinea
            // 
            this.btnGestionAerolinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(200)))), ((int)(((byte)(214)))));
            this.btnGestionAerolinea.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionAerolinea.FlatAppearance.BorderSize = 0;
            this.btnGestionAerolinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionAerolinea.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGestionAerolinea.Location = new System.Drawing.Point(0, 0);
            this.btnGestionAerolinea.Name = "btnGestionAerolinea";
            this.btnGestionAerolinea.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnGestionAerolinea.Size = new System.Drawing.Size(247, 47);
            this.btnGestionAerolinea.TabIndex = 6;
            this.btnGestionAerolinea.Text = "Gestion de Aerolineas";
            this.btnGestionAerolinea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionAerolinea.UseVisualStyleBackColor = false;
            this.btnGestionAerolinea.Click += new System.EventHandler(this.btnGestionAerolinea_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(202)))));
            this.btnRegistro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegistro.FlatAppearance.BorderSize = 0;
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistro.Image = global::Vistas.Properties.Resources.icons8_aerolíneas_50;
            this.btnRegistro.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistro.Location = new System.Drawing.Point(0, 260);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRegistro.Size = new System.Drawing.Size(250, 54);
            this.btnRegistro.TabIndex = 5;
            this.btnRegistro.Text = "Administracion de Aeronaves";
            this.btnRegistro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // pnlSubmenuEq
            // 
            this.pnlSubmenuEq.Controls.Add(this.btnEstadoVuelo);
            this.pnlSubmenuEq.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubmenuEq.Location = new System.Drawing.Point(0, 241);
            this.pnlSubmenuEq.Name = "pnlSubmenuEq";
            this.pnlSubmenuEq.Size = new System.Drawing.Size(250, 19);
            this.pnlSubmenuEq.TabIndex = 4;
            // 
            // btnEstadoVuelo
            // 
            this.btnEstadoVuelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(200)))), ((int)(((byte)(214)))));
            this.btnEstadoVuelo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstadoVuelo.FlatAppearance.BorderSize = 0;
            this.btnEstadoVuelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoVuelo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEstadoVuelo.Location = new System.Drawing.Point(0, 0);
            this.btnEstadoVuelo.Name = "btnEstadoVuelo";
            this.btnEstadoVuelo.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnEstadoVuelo.Size = new System.Drawing.Size(250, 19);
            this.btnEstadoVuelo.TabIndex = 0;
            this.btnEstadoVuelo.Text = "Rutas y Estados de Aviones";
            this.btnEstadoVuelo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadoVuelo.UseVisualStyleBackColor = false;
            this.btnEstadoVuelo.Click += new System.EventHandler(this.btnEstadoVuelo_Click);
            // 
            // btnVuelos
            // 
            this.btnVuelos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(202)))));
            this.btnVuelos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVuelos.FlatAppearance.BorderSize = 0;
            this.btnVuelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVuelos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVuelos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVuelos.Image = global::Vistas.Properties.Resources.icons8_aerolíneas_finnair_50;
            this.btnVuelos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVuelos.Location = new System.Drawing.Point(0, 202);
            this.btnVuelos.Name = "btnVuelos";
            this.btnVuelos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVuelos.Size = new System.Drawing.Size(250, 39);
            this.btnVuelos.TabIndex = 3;
            this.btnVuelos.Text = "Administracion de Rutas";
            this.btnVuelos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVuelos.UseVisualStyleBackColor = false;
            this.btnVuelos.Click += new System.EventHandler(this.btnVuelos_Click);
            // 
            // pnlSubmenusRserva
            // 
            this.pnlSubmenusRserva.Controls.Add(this.btnBoleto);
            this.pnlSubmenusRserva.Controls.Add(this.btnReserva);
            this.pnlSubmenusRserva.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubmenusRserva.Location = new System.Drawing.Point(0, 157);
            this.pnlSubmenusRserva.Name = "pnlSubmenusRserva";
            this.pnlSubmenusRserva.Size = new System.Drawing.Size(250, 45);
            this.pnlSubmenusRserva.TabIndex = 2;
            // 
            // btnBoleto
            // 
            this.btnBoleto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(200)))), ((int)(((byte)(214)))));
            this.btnBoleto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBoleto.FlatAppearance.BorderSize = 0;
            this.btnBoleto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoleto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBoleto.Location = new System.Drawing.Point(0, 23);
            this.btnBoleto.Name = "btnBoleto";
            this.btnBoleto.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBoleto.Size = new System.Drawing.Size(250, 22);
            this.btnBoleto.TabIndex = 1;
            this.btnBoleto.Text = "Boleto";
            this.btnBoleto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoleto.UseVisualStyleBackColor = false;
            this.btnBoleto.Click += new System.EventHandler(this.btnBoleto_Click);
            // 
            // btnReserva
            // 
            this.btnReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(200)))), ((int)(((byte)(214)))));
            this.btnReserva.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReserva.FlatAppearance.BorderSize = 0;
            this.btnReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserva.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReserva.Location = new System.Drawing.Point(0, 0);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnReserva.Size = new System.Drawing.Size(250, 23);
            this.btnReserva.TabIndex = 0;
            this.btnReserva.Text = "Reserva";
            this.btnReserva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReserva.UseVisualStyleBackColor = false;
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // btnReservasPa
            // 
            this.btnReservasPa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(202)))));
            this.btnReservasPa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReservasPa.FlatAppearance.BorderSize = 0;
            this.btnReservasPa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservasPa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservasPa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReservasPa.Image = global::Vistas.Properties.Resources.icons8_entradas_50;
            this.btnReservasPa.Location = new System.Drawing.Point(0, 100);
            this.btnReservasPa.Name = "btnReservasPa";
            this.btnReservasPa.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReservasPa.Size = new System.Drawing.Size(250, 57);
            this.btnReservasPa.TabIndex = 1;
            this.btnReservasPa.Text = "Reserva";
            this.btnReservasPa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservasPa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReservasPa.UseVisualStyleBackColor = false;
            this.btnReservasPa.Click += new System.EventHandler(this.btnReservasPa_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Black;
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vistas.Properties.Resources.WhatsApp_Image_2025_09_01_at_2_32_44_PM__1_;
            this.pictureBox1.Location = new System.Drawing.Point(55, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlprincipal
            // 
            this.pnlprincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlprincipal.Location = new System.Drawing.Point(250, 0);
            this.pnlprincipal.Name = "pnlprincipal";
            this.pnlprincipal.Size = new System.Drawing.Size(744, 450);
            this.pnlprincipal.TabIndex = 7;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 450);
            this.Controls.Add(this.pnlprincipal);
            this.Controls.Add(this.pnlLateral);
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.pnlLateral.ResumeLayout(false);
            this.pnlAdministracionAeronave.ResumeLayout(false);
            this.pnlSubmenuEq.ResumeLayout(false);
            this.pnlSubmenusRserva.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.Button btnGestionAerolinea;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Panel pnlSubmenuEq;
        private System.Windows.Forms.Button btnEstadoVuelo;
        private System.Windows.Forms.Button btnVuelos;
        private System.Windows.Forms.Panel pnlSubmenusRserva;
        private System.Windows.Forms.Button btnReserva;
        private System.Windows.Forms.Button btnReservasPa;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBoleto;
        private System.Windows.Forms.Panel pnlAdministracionAeronave;
        private System.Windows.Forms.Panel pnlprincipal;
    }
}