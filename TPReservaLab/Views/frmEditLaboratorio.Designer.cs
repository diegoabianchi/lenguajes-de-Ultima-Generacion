namespace TPReservaLab.Views
{
    partial class frmEditLaboratorio
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNumero = new TextBox();
            txtUbicacion = new TextBox();
            txtCapacidad = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 71);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Número";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 112);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "Ubicación (piso)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 156);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 2;
            label3.Text = "Capacidad (puestos)";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(160, 68);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(100, 23);
            txtNumero.TabIndex = 3;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(160, 109);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(100, 23);
            txtUbicacion.TabIndex = 4;
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(160, 153);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(100, 23);
            txtCapacidad.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(168, 220);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(92, 32);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // frmEditLaboratorio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 318);
            Controls.Add(btnGuardar);
            Controls.Add(txtCapacidad);
            Controls.Add(txtUbicacion);
            Controls.Add(txtNumero);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmEditLaboratorio";
            Text = "Laboratorio";
            Load += frmEditLaboratorio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNumero;
        private TextBox txtUbicacion;
        private TextBox txtCapacidad;
        private Button btnGuardar;
    }
}