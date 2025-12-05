namespace TP_GestionVentas.Views
{
    partial class frmEditProducto
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
            lblCodigo = new Label();
            lblNombre = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            label2 = new Label();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            cbxCategoria = new ComboBox();
            numPrecio = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            SuspendLayout();
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(49, 50);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(79, 15);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Código único";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(77, 84);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(59, 118);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(69, 15);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 244);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 3;
            label1.Text = "Categoría";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 282);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 4;
            label2.Text = "Precio";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(134, 47);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(128, 23);
            txtCodigo.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(134, 81);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(252, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(134, 115);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(252, 111);
            txtDescripcion.TabIndex = 7;
            // 
            // cbxCategoria
            // 
            cbxCategoria.FormattingEnabled = true;
            cbxCategoria.Location = new Point(134, 241);
            cbxCategoria.Name = "cbxCategoria";
            cbxCategoria.Size = new Size(252, 23);
            cbxCategoria.TabIndex = 8;
            // 
            // numPrecio
            // 
            numPrecio.Location = new Point(134, 280);
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(128, 23);
            numPrecio.TabIndex = 9;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(289, 339);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(97, 38);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(134, 339);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 38);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmEditProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 434);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(numPrecio);
            Controls.Add(cbxCategoria);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(lblCodigo);
            Name = "frmEditProducto";
            Text = "Producto";
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigo;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label label1;
        private Label label2;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private ComboBox cbxCategoria;
        private NumericUpDown numPrecio;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}