namespace TP_GestionVentas.Views
{
    partial class frmHistorialVentas
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
            panel1 = new Panel();
            label3 = new Label();
            cbxCliente = new ComboBox();
            btnBuscar = new Button();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            dgvVentas = new DataGridView();
            dgvDetallesVenta = new DataGridView();
            lblDetalle = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesVenta).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbxCliente);
            panel1.Controls.Add(btnBuscar);
            panel1.Controls.Add(dtpHasta);
            panel1.Controls.Add(dtpDesde);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 78);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(327, 18);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 6;
            label3.Text = "Cliente";
            // 
            // cbxCliente
            // 
            cbxCliente.FormattingEnabled = true;
            cbxCliente.Location = new Point(377, 15);
            cbxCliente.Name = "cbxCliente";
            cbxCliente.Size = new Size(178, 23);
            cbxCliente.TabIndex = 5;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(575, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(81, 50);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(73, 44);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(234, 23);
            dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(73, 12);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(234, 23);
            dtpDesde.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 50);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Hasta";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 18);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Desde";
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToResizeRows = false;
            dgvVentas.BackgroundColor = SystemColors.ScrollBar;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(0, 78);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.Size = new Size(800, 201);
            dgvVentas.TabIndex = 2;
            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
            // 
            // dgvDetallesVenta
            // 
            dgvDetallesVenta.AllowUserToResizeRows = false;
            dgvDetallesVenta.BackgroundColor = SystemColors.ScrollBar;
            dgvDetallesVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallesVenta.Location = new Point(0, 321);
            dgvDetallesVenta.MultiSelect = false;
            dgvDetallesVenta.Name = "dgvDetallesVenta";
            dgvDetallesVenta.ReadOnly = true;
            dgvDetallesVenta.Size = new Size(800, 170);
            dgvDetallesVenta.TabIndex = 3;
            // 
            // lblDetalle
            // 
            lblDetalle.AutoSize = true;
            lblDetalle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalle.Location = new Point(0, 297);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(144, 21);
            lblDetalle.TabIndex = 4;
            lblDetalle.Text = "Detalle de la venta: ";
            // 
            // frmHistorialVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 503);
            Controls.Add(lblDetalle);
            Controls.Add(dgvDetallesVenta);
            Controls.Add(dgvVentas);
            Controls.Add(panel1);
            Name = "frmHistorialVentas";
            Text = "frmHistorialVentas";
            Load += frmHistorialVentas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnBuscar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox cbxCliente;
        private DataGridView dgvVentas;
        private DataGridView dgvDetallesVenta;
        private Label lblDetalle;
    }
}