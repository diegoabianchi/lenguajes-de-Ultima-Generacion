namespace TPReservaLab.Views
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            gestiónDeReservasToolStripMenuItem = new ToolStripMenuItem();
            gestiónDeLaboratoriosToolStripMenuItem = new ToolStripMenuItem();
            generaciónDeReportesToolStripMenuItem = new ToolStripMenuItem();
            integrantesToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            panelContenedor = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gestiónDeReservasToolStripMenuItem, gestiónDeLaboratoriosToolStripMenuItem, generaciónDeReportesToolStripMenuItem, integrantesToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(699, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // gestiónDeReservasToolStripMenuItem
            // 
            gestiónDeReservasToolStripMenuItem.Name = "gestiónDeReservasToolStripMenuItem";
            gestiónDeReservasToolStripMenuItem.Size = new Size(123, 20);
            gestiónDeReservasToolStripMenuItem.Text = "Gestión de Reservas";
            gestiónDeReservasToolStripMenuItem.Click += gestiónDeReservasToolStripMenuItem_Click;
            // 
            // gestiónDeLaboratoriosToolStripMenuItem
            // 
            gestiónDeLaboratoriosToolStripMenuItem.Name = "gestiónDeLaboratoriosToolStripMenuItem";
            gestiónDeLaboratoriosToolStripMenuItem.Size = new Size(144, 20);
            gestiónDeLaboratoriosToolStripMenuItem.Text = "Gestión de Laboratorios";
            gestiónDeLaboratoriosToolStripMenuItem.Click += gestiónDeLaboratoriosToolStripMenuItem_Click;
            // 
            // generaciónDeReportesToolStripMenuItem
            // 
            generaciónDeReportesToolStripMenuItem.Name = "generaciónDeReportesToolStripMenuItem";
            generaciónDeReportesToolStripMenuItem.Size = new Size(144, 20);
            generaciónDeReportesToolStripMenuItem.Text = "Generación de Reportes";
            generaciónDeReportesToolStripMenuItem.Click += generaciónDeReportesToolStripMenuItem_Click;
            // 
            // integrantesToolStripMenuItem
            // 
            integrantesToolStripMenuItem.Name = "integrantesToolStripMenuItem";
            integrantesToolStripMenuItem.Size = new Size(78, 20);
            integrantesToolStripMenuItem.Text = "Integrantes";
            integrantesToolStripMenuItem.Click += integrantesToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Location = new Point(12, 27);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(662, 424);
            panelContenedor.TabIndex = 2;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 471);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Reservas de Laboratorios";
            Load += frmMenuPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gestiónDeReservasToolStripMenuItem;
        private ToolStripMenuItem gestiónDeLaboratoriosToolStripMenuItem;
        private ToolStripMenuItem generaciónDeReportesToolStripMenuItem;
        private ToolStripMenuItem integrantesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Panel panelContenedor;
    }
}