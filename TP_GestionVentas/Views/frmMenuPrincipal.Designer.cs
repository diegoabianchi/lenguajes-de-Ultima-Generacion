namespace TP_GestionVentas.Views
{
    partial class frmMenuPrincipal
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
            menuStrip1 = new MenuStrip();
            gestiónToolStripMenuItem = new ToolStripMenuItem();
            mnuClientes = new ToolStripMenuItem();
            mnuVendedores = new ToolStripMenuItem();
            mnuProductosPadre = new ToolStripMenuItem();
            mnuProductos = new ToolStripMenuItem();
            mnuStock = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            mnuNuevaVenta = new ToolStripMenuItem();
            mnuHistorialVentas = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            mnuReportes = new ToolStripMenuItem();
            sistemaToolStripMenuItem = new ToolStripMenuItem();
            mnuAcercaDe = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            panelContenedor = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gestiónToolStripMenuItem, ventasToolStripMenuItem, reportesToolStripMenuItem, sistemaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(977, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuClientes, mnuVendedores, mnuProductosPadre });
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(59, 20);
            gestiónToolStripMenuItem.Text = "Gestión";
            // 
            // mnuClientes
            // 
            mnuClientes.Name = "mnuClientes";
            mnuClientes.Size = new Size(135, 22);
            mnuClientes.Text = "Clientes";
            mnuClientes.Click += mnuClientes_Click;
            // 
            // mnuVendedores
            // 
            mnuVendedores.Name = "mnuVendedores";
            mnuVendedores.Size = new Size(135, 22);
            mnuVendedores.Text = "Vendedores";
            mnuVendedores.Click += mnuVendedores_Click;
            // 
            // mnuProductosPadre
            // 
            mnuProductosPadre.DropDownItems.AddRange(new ToolStripItem[] { mnuProductos, mnuStock });
            mnuProductosPadre.Name = "mnuProductosPadre";
            mnuProductosPadre.Size = new Size(135, 22);
            mnuProductosPadre.Text = "Productos";
            // 
            // mnuProductos
            // 
            mnuProductos.Name = "mnuProductos";
            mnuProductos.Size = new Size(184, 22);
            mnuProductos.Text = "Productos";
            mnuProductos.Click += mnuProductos_Click;
            // 
            // mnuStock
            // 
            mnuStock.Name = "mnuStock";
            mnuStock.Size = new Size(184, 22);
            mnuStock.Text = "Disponibilidad/Stock";
            mnuStock.Click += mnuStock_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuNuevaVenta, mnuHistorialVentas });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // mnuNuevaVenta
            // 
            mnuNuevaVenta.Name = "mnuNuevaVenta";
            mnuNuevaVenta.Size = new Size(199, 22);
            mnuNuevaVenta.Text = "Nueva Venta";
            mnuNuevaVenta.Click += mnuNuevaVenta_Click;
            // 
            // mnuHistorialVentas
            // 
            mnuHistorialVentas.Name = "mnuHistorialVentas";
            mnuHistorialVentas.Size = new Size(199, 22);
            mnuHistorialVentas.Text = "Historial de Facturación";
            mnuHistorialVentas.Click += mnuHistorialVentas_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuReportes });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // mnuReportes
            // 
            mnuReportes.Name = "mnuReportes";
            mnuReportes.Size = new Size(180, 22);
            mnuReportes.Text = "Generar Reportes";
            mnuReportes.Click += mnuReportes_Click;
            // 
            // sistemaToolStripMenuItem
            // 
            sistemaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuAcercaDe, mnuSalir });
            sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            sistemaToolStripMenuItem.Size = new Size(60, 20);
            sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // mnuAcercaDe
            // 
            mnuAcercaDe.Name = "mnuAcercaDe";
            mnuAcercaDe.Size = new Size(135, 22);
            mnuAcercaDe.Text = "Acerca de...";
            mnuAcercaDe.Click += mnuAcercaDe_Click;
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(135, 22);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = SystemColors.ControlLight;
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 24);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(977, 551);
            panelContenedor.TabIndex = 1;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 575);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMenuPrincipal";
            Text = "Sistema de Gestión - TechStore S.A.";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem mnuProductosPadre;
        private ToolStripMenuItem mnuClientes;
        private ToolStripMenuItem mnuVendedores;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem mnuNuevaVenta;
        private ToolStripMenuItem mnuHistorialVentas;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem mnuReportes;
        private ToolStripMenuItem sistemaToolStripMenuItem;
        private ToolStripMenuItem mnuSalir;
        private ToolStripMenuItem mnuAcercaDe;
        private Panel panelContenedor;
        private ToolStripMenuItem mnuProductos;
        private ToolStripMenuItem mnuStock;
    }
}