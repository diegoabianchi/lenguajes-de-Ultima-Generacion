using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using TP_GestionVentas.Views;

namespace TP_GestionVentas.Views
{
    public partial class frmMenuPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public frmMenuPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            // Configuraciones visuales extras
            this.IsMdiContainer = false;
            this.Text = "Sistema de Gestión - TechStore S.A.";
            //this.WindowState = FormWindowState.Maximized;
        }

        private void AbrirFormEnPanel(Form formHijo)
        {
            // 1. Si ya hay un control en el panel, lo quitamos (cerramos el anterior)
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }

            // 2. Configuramos el formulario hijo para que se comporte como un control
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            // 3. Lo agregamos al panel y lo mostramos
            this.panelContenedor.Controls.Add(formHijo);
            this.panelContenedor.Tag = formHijo;
            formHijo.Show();
        }

        // ================================================
        // EVENTOS DEL MENÚ
        // ================================================
        private void mnuProductos_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmGestionProductos>();
            AbrirFormEnPanel(frm);
        }
        private void mnuClientes_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmGestionClientes>();
            AbrirFormEnPanel(frm);
        }
        private void mnuVendedores_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmGestionVendedores>();
            AbrirFormEnPanel(frm);
        }

        private void mnuNuevaVenta_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmRegistrarVenta>();
            AbrirFormEnPanel(frm);
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema desarrollado por Diego Bianchi.\n'Lenguajes de Ultima Generación' - UAI");
        }

        private void mnuStock_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmConsultaStock>();
            AbrirFormEnPanel(frm);
        }

    }
}