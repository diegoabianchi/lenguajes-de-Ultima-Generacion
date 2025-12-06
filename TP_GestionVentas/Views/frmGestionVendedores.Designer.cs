namespace TP_GestionVentas.Views
{
    partial class frmGestionVendedores
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
            btnModificar = new Button();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            label1 = new Label();
            dgvVendedores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVendedores).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(625, 18);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(92, 23);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(514, 18);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(92, 23);
            btnModificar.TabIndex = 15;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(396, 19);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(103, 23);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Nuevo Vendedor";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(137, 19);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(179, 23);
            txtBuscar.TabIndex = 13;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 22);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 12;
            label1.Text = "Filtrar por nombre";
            // 
            // dgvVendedores
            // 
            dgvVendedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvVendedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendedores.Location = new Point(21, 59);
            dgvVendedores.Name = "dgvVendedores";
            dgvVendedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendedores.Size = new Size(699, 386);
            dgvVendedores.TabIndex = 11;
            // 
            // frmGestionVendedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 461);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            Controls.Add(dgvVendedores);
            Name = "frmGestionVendedores";
            Text = "Gestion Vendedores";
            Load += frmGestionVendedores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVendedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private Label label1;
        private DataGridView dgvVendedores;
    }
}