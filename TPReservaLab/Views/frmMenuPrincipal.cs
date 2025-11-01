using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace TPReservaLab.Views
{
    public partial class frmMenuPrincipal : Form
    {
        private const int ANCHO_RESERVAS = 1100;
        private const int ANCHO_LABORATORIOS = 600;
        private readonly IServiceProvider _serviceProvider;
        public frmMenuPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void gestiónDeReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmRes = _serviceProvider.GetRequiredService<frmReservas>();
            AbrirFormEnPanel(frmRes, ANCHO_RESERVAS);
        }

        private void gestiónDeLaboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmLab = _serviceProvider.GetRequiredService<frmLaboratorios>();
            AbrirFormEnPanel(frmLab, ANCHO_LABORATORIOS);
        }


        // Metodo para abrir formularios dentro de un panel
        private void AbrirFormEnPanel(Form formHijo, int anchoDeseado)
        {
            // Elimino cualquier control que ya esté dentro del panel
            if (panelContenedor.Controls.Count > 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }

            // Ajusto el ancho del formulario principal si es necesario
            if (this.Width != anchoDeseado)
            {
                this.Width = anchoDeseado;
            }
            panelContenedor.Width = anchoDeseado;

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None; // Sin bordes ni barra de título
            formHijo.Dock = DockStyle.Fill; // Para que ocupe todo el panel

            // Agrego el form hijo al panel y lo muestro
            panelContenedor.Controls.Add(formHijo);
            panelContenedor.Tag = formHijo;
            formHijo.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void integrantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicación desarrollada por Diego Bianchi.", "Integrantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void generaciónDeReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Generación de Reportes pendiente de implementación.", "Próxima Implementación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            return;
        }
    }
}
