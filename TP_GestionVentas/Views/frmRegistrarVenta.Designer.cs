namespace TP_GestionVentas.Views
{
    partial class frmRegistrarVenta
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
            groupBox1 = new GroupBox();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            cbxMetodoPago = new ComboBox();
            cbxCliente = new ComboBox();
            cbxVendedor = new ComboBox();
            cbxSucursal = new ComboBox();
            label1 = new Label();
            lblDescripcion = new Label();
            lblNombre = new Label();
            lblCodigo = new Label();
            groupBox2 = new GroupBox();
            dgvBusquedaProductos = new DataGridView();
            btnAgregar = new Button();
            numCantidad = new NumericUpDown();
            txtBuscarProducto = new TextBox();
            lblCant = new Label();
            label5 = new Label();
            dgvDetalles = new DataGridView();
            lblTotal = new Label();
            btnFinalizar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBusquedaProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(cbxMetodoPago);
            groupBox1.Controls.Add(cbxCliente);
            groupBox1.Controls.Add(cbxVendedor);
            groupBox1.Controls.Add(cbxSucursal);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblDescripcion);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(lblCodigo);
            groupBox1.Location = new Point(28, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(339, 241);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la venta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 38);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 37;
            label2.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(98, 32);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(141, 23);
            dateTimePicker1.TabIndex = 36;
            // 
            // cbxMetodoPago
            // 
            cbxMetodoPago.FormattingEnabled = true;
            cbxMetodoPago.Items.AddRange(new object[] { "Minorista", "Mayorista" });
            cbxMetodoPago.Location = new Point(98, 107);
            cbxMetodoPago.Name = "cbxMetodoPago";
            cbxMetodoPago.Size = new Size(141, 23);
            cbxMetodoPago.TabIndex = 34;
            // 
            // cbxCliente
            // 
            cbxCliente.FormattingEnabled = true;
            cbxCliente.Items.AddRange(new object[] { "Minorista", "Mayorista" });
            cbxCliente.Location = new Point(98, 182);
            cbxCliente.Name = "cbxCliente";
            cbxCliente.Size = new Size(184, 23);
            cbxCliente.TabIndex = 33;
            // 
            // cbxVendedor
            // 
            cbxVendedor.FormattingEnabled = true;
            cbxVendedor.Items.AddRange(new object[] { "Minorista", "Mayorista" });
            cbxVendedor.Location = new Point(98, 146);
            cbxVendedor.Name = "cbxVendedor";
            cbxVendedor.Size = new Size(184, 23);
            cbxVendedor.TabIndex = 32;
            // 
            // cbxSucursal
            // 
            cbxSucursal.FormattingEnabled = true;
            cbxSucursal.Items.AddRange(new object[] { "Minorista", "Mayorista" });
            cbxSucursal.Location = new Point(98, 71);
            cbxSucursal.Name = "cbxSucursal";
            cbxSucursal.Size = new Size(141, 23);
            cbxSucursal.TabIndex = 31;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 110);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 28;
            label1.Text = "Método pago";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(48, 185);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(44, 15);
            lblDescripcion.TabIndex = 27;
            lblDescripcion.Text = "Cliente";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(35, 149);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(57, 15);
            lblNombre.TabIndex = 26;
            lblNombre.Text = "Vendedor";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(41, 74);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(51, 15);
            lblCodigo.TabIndex = 25;
            lblCodigo.Text = "Sucursal";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvBusquedaProductos);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(numCantidad);
            groupBox2.Controls.Add(txtBuscarProducto);
            groupBox2.Controls.Add(lblCant);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(407, 32);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(387, 230);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "Agregar Producto";
            // 
            // dgvBusquedaProductos
            // 
            dgvBusquedaProductos.AllowUserToAddRows = false;
            dgvBusquedaProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBusquedaProductos.BackgroundColor = SystemColors.ScrollBar;
            dgvBusquedaProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBusquedaProductos.Location = new Point(27, 60);
            dgvBusquedaProductos.MultiSelect = false;
            dgvBusquedaProductos.Name = "dgvBusquedaProductos";
            dgvBusquedaProductos.ReadOnly = true;
            dgvBusquedaProductos.RowHeadersVisible = false;
            dgvBusquedaProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBusquedaProductos.Size = new Size(328, 108);
            dgvBusquedaProductos.TabIndex = 44;
            dgvBusquedaProductos.CellContentClick += dgvBusquedaProductos_CellClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.Location = new Point(235, 177);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 33);
            btnAgregar.TabIndex = 43;
            btnAgregar.Text = "Agregar al Carrito";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(88, 184);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(44, 23);
            numCantidad.TabIndex = 42;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(138, 31);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(217, 23);
            txtBuscarProducto.TabIndex = 39;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // lblCant
            // 
            lblCant.AutoSize = true;
            lblCant.Location = new Point(27, 186);
            lblCant.Name = "lblCant";
            lblCant.Size = new Size(55, 15);
            lblCant.TabIndex = 38;
            lblCant.Text = "Cantidad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 34);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 36;
            label5.Text = "Código/Nombre";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(126, 280);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(569, 188);
            dgvDetalles.TabIndex = 38;
            dgvDetalles.CellClick += dgvDetalles_CellClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(126, 498);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(119, 25);
            lblTotal.TabIndex = 39;
            lblTotal.Text = "Total: $ 0.00";
            // 
            // btnFinalizar
            // 
            btnFinalizar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFinalizar.Location = new Point(514, 487);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(181, 48);
            btnFinalizar.TabIndex = 44;
            btnFinalizar.Text = "Confirmar Venta";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // frmRegistrarVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 625);
            Controls.Add(btnFinalizar);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalles);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmRegistrarVenta";
            Text = "Venta";
            Load += frmRegistrarVenta_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBusquedaProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbxVendedor;
        private ComboBox cbxSucursal;
        private Label label1;
        private Label lblDescripcion;
        private Label lblNombre;
        private Label lblCodigo;
        private DateTimePicker dateTimePicker1;
        private ComboBox cbxMetodoPago;
        private ComboBox cbxCliente;
        private GroupBox groupBox2;
        private Label lblCant;
        private Label label5;
        private TextBox txtBuscarProducto;
        private Button btnAgregar;
        private NumericUpDown numCantidad;
        private DataGridView dgvDetalles;
        private Label lblTotal;
        private Button btnFinalizar;
        private DataGridView dgvBusquedaProductos;
        private Label label2;
    }
}