namespace TP_GestionVentas.Views
{
    partial class frmEditVendedor
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
            txtEmail = new TextBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            lblNombre = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(105, 99);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(252, 23);
            txtEmail.TabIndex = 34;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(105, 168);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 38);
            btnCancelar.TabIndex = 33;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(260, 168);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(97, 38);
            btnGuardar.TabIndex = 32;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(105, 63);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(252, 23);
            txtNombre.TabIndex = 30;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(63, 102);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(36, 15);
            lblDescripcion.TabIndex = 27;
            lblDescripcion.Text = "Email";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(48, 66);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 26;
            lblNombre.Text = "Nombre";
            // 
            // frmEditVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 276);
            Controls.Add(txtEmail);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Name = "frmEditVendedor";
            Text = "Vendedor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private Button btnCancelar;
        private Button btnGuardar;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private Label lblNombre;
    }
}