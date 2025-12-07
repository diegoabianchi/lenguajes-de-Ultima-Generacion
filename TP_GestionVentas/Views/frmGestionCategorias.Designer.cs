namespace TP_GestionVentas.Views
{
    partial class frmGestionCategorias
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
            btnEliminar = new Button();
            btnGuardar = new Button();
            txtNombre = new TextBox();
            label1 = new Label();
            dgvCategorias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(616, 11);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(92, 23);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(504, 11);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(91, 23);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(128, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(179, 23);
            txtNombre.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 15);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 18;
            label1.Text = "Nombre categoría";
            // 
            // dgvCategorias
            // 
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(12, 52);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(699, 391);
            dgvCategorias.TabIndex = 17;
            // 
            // frmGestionCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 465);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(dgvCategorias);
            Name = "frmGestionCategorias";
            Text = "frmGestionCategorias";
            Load += frmGestionCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnGuardar;
        private TextBox txtNombre;
        private Label label1;
        private DataGridView dgvCategorias;
    }
}