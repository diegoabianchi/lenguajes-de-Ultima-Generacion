using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPReservaLab.Views
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void gestiónDeReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmReservas());
        }

        private void gestiónDeLaboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmLaboratorios());
        }


        // Metodo para abrir formularios dentro de un panel
        private void AbrirFormEnPanel(Form formHijo)
        {
            // Elimino cualquier control que ya esté dentro del panel
            if (panelContenedor.Controls.Count > 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }

            // Configuro el formulario hijo
            formHijo.TopLevel = false; // Muy importante: lo hace un "control"
            formHijo.FormBorderStyle = FormBorderStyle.None; // Sin bordes ni barra de título
            formHijo.Dock = DockStyle.Fill; // Para que ocupe todo el panel

            // Agrego el form al panel y lo muestro
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
            MessageBox.Show("Aplicación desarrollada por Diego Bianchi", "Desarrollador", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void generaciónDeReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return;
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            return;
        }
    }
}
