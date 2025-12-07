namespace TP_GestionVentas.Views
{
    partial class frmReportes
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
            btnGenerar = new Button();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvProductosTop = new DataGridView();
            tabPage2 = new TabPage();
            dgvSucursales = new DataGridView();
            tabPage3 = new TabPage();
            dgvVendedores = new DataGridView();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosTop).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSucursales).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVendedores).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnGenerar);
            panel1.Controls.Add(dtpHasta);
            panel1.Controls.Add(dtpDesde);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 78);
            panel1.TabIndex = 0;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(340, 18);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(83, 47);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 78);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 372);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvProductosTop);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 344);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Productos Más Vendidos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvProductosTop
            // 
            dgvProductosTop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosTop.Dock = DockStyle.Fill;
            dgvProductosTop.Location = new Point(3, 3);
            dgvProductosTop.Name = "dgvProductosTop";
            dgvProductosTop.Size = new Size(786, 338);
            dgvProductosTop.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvSucursales);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 344);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ventas por Sucursal";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvSucursales
            // 
            dgvSucursales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSucursales.Dock = DockStyle.Fill;
            dgvSucursales.Location = new Point(3, 3);
            dgvSucursales.Name = "dgvSucursales";
            dgvSucursales.Size = new Size(786, 338);
            dgvSucursales.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvVendedores);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 344);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Ventas por Vendedor";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvVendedores
            // 
            dgvVendedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendedores.Dock = DockStyle.Fill;
            dgvVendedores.Location = new Point(3, 3);
            dgvVendedores.Name = "dgvVendedores";
            dgvVendedores.Size = new Size(786, 338);
            dgvVendedores.TabIndex = 0;
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "frmReportes";
            Text = "frmReportes";
            Load += frmReportes_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductosTop).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSucursales).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVendedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnGenerar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private Label label2;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dgvProductosTop;
        private DataGridView dgvSucursales;
        private DataGridView dgvVendedores;
    }
}