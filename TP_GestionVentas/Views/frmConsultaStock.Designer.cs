namespace TP_GestionVentas.Views
{
    partial class frmConsultaStock
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
            cbxSucursal = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtBuscar = new TextBox();
            dgvStock = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // cbxSucursal
            // 
            cbxSucursal.FormattingEnabled = true;
            cbxSucursal.Location = new Point(154, 36);
            cbxSucursal.Name = "cbxSucursal";
            cbxSucursal.Size = new Size(167, 23);
            cbxSucursal.TabIndex = 10;
            cbxSucursal.SelectedIndexChanged += cbxSucursal_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 39);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 9;
            label1.Text = "Filtrar por sucursal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 75);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 11;
            label2.Text = "Buscar Producto";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(154, 72);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(167, 23);
            txtBuscar.TabIndex = 12;
            txtBuscar.TextChanged += txtBuscar_KeyUp;
            // 
            // dgvStock
            // 
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(44, 115);
            dgvStock.Name = "dgvStock";
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(602, 266);
            dgvStock.TabIndex = 13;
            // 
            // frmConsultaStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 448);
            Controls.Add(dgvStock);
            Controls.Add(txtBuscar);
            Controls.Add(label2);
            Controls.Add(cbxSucursal);
            Controls.Add(label1);
            Name = "frmConsultaStock";
            Text = "frmConsultaStock";
            Load += frmConsultaStock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxSucursal;
        private Label label1;
        private Label label2;
        private TextBox txtBuscar;
        private DataGridView dgvStock;
    }
}