namespace TP_GestionVentas.Views
{
    partial class frmEditCliente
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
            btnCancelar = new Button();
            btnGuardar = new Button();
            cbxTipo = new ComboBox();
            txtNombre = new TextBox();
            txtDNI = new TextBox();
            label1 = new Label();
            lblDescripcion = new Label();
            lblNombre = new Label();
            lblCodigo = new Label();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(115, 245);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 38);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(270, 245);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(97, 38);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cbxTipo
            // 
            cbxTipo.FormattingEnabled = true;
            cbxTipo.Items.AddRange(new object[] { "Minorista", "Mayorista" });
            cbxTipo.Location = new Point(115, 167);
            cbxTipo.Name = "cbxTipo";
            cbxTipo.Size = new Size(147, 23);
            cbxTipo.TabIndex = 20;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(115, 90);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(252, 23);
            txtNombre.TabIndex = 18;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(115, 56);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(128, 23);
            txtDNI.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 170);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 15;
            label1.Text = "Tipo Cliente";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(73, 129);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(36, 15);
            lblDescripcion.TabIndex = 14;
            lblDescripcion.Text = "Email";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(58, 93);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 13;
            lblNombre.Text = "Nombre";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(82, 59);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(27, 15);
            lblCodigo.TabIndex = 12;
            lblCodigo.Text = "DNI";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(115, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(252, 23);
            txtEmail.TabIndex = 24;
            // 
            // frmEditCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 349);
            Controls.Add(txtEmail);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cbxTipo);
            Controls.Add(txtNombre);
            Controls.Add(txtDNI);
            Controls.Add(label1);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(lblCodigo);
            Name = "frmEditCliente";
            Text = "Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGuardar;
        private ComboBox cbxTipo;
        private TextBox txtNombre;
        private TextBox txtDNI;
        private Label label1;
        private Label lblDescripcion;
        private Label lblNombre;
        private Label lblCodigo;
        private TextBox txtEmail;
    }
}