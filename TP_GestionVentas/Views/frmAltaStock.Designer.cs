namespace TP_GestionVentas.Views
{
    partial class frmAltaStock
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
            btnGuardar = new Button();
            txtBuscar = new TextBox();
            label1 = new Label();
            dgvProductos = new DataGridView();
            cbxSucursal = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            numCantidad = new NumericUpDown();
            lblProductoSeleccionado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(136, 408);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(121, 44);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Confirmar ingreso";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(163, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(137, 23);
            txtBuscar.TabIndex = 8;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(145, 15);
            label1.TabIndex = 7;
            label1.Text = "Filtrar por nombre/código";
            // 
            // dgvProductos
            // 
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 52);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(394, 222);
            dgvProductos.TabIndex = 6;
            dgvProductos.CellContentClick += dgvProductos_CellClick;
            // 
            // cbxSucursal
            // 
            cbxSucursal.FormattingEnabled = true;
            cbxSucursal.Location = new Point(136, 333);
            cbxSucursal.Name = "cbxSucursal";
            cbxSucursal.Size = new Size(168, 23);
            cbxSucursal.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 336);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 13;
            label2.Text = "Sucursal destino:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 371);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 14;
            label3.Text = "Cantidad a ingresar: ";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(136, 367);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(58, 23);
            numCantidad.TabIndex = 15;
            // 
            // lblProductoSeleccionado
            // 
            lblProductoSeleccionado.AutoSize = true;
            lblProductoSeleccionado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductoSeleccionado.Location = new Point(34, 294);
            lblProductoSeleccionado.Name = "lblProductoSeleccionado";
            lblProductoSeleccionado.Size = new Size(13, 17);
            lblProductoSeleccionado.TabIndex = 16;
            lblProductoSeleccionado.Text = "-";
            // 
            // frmAltaStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 513);
            Controls.Add(lblProductoSeleccionado);
            Controls.Add(numCantidad);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbxSucursal);
            Controls.Add(btnGuardar);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            Controls.Add(dgvProductos);
            Name = "frmAltaStock";
            Text = "Alta de Stock";
            Load += frmAltaStock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private TextBox txtBuscar;
        private Label label1;
        private DataGridView dgvProductos;
        private ComboBox cbxSucursal;
        private Label label2;
        private Label label3;
        private NumericUpDown numCantidad;
        private Label lblProductoSeleccionado;
    }
}