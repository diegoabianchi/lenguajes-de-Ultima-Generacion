using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmGestionVendedores : Form
    {
        private readonly VendedorController _controller;
        private readonly IServiceProvider _serviceProvider;

        public frmGestionVendedores(VendedorController controller, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _controller = controller;
            _serviceProvider = serviceProvider;
        }

        private void frmGestionVendedores_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                dgvVendedores.DataSource = null;
                dgvVendedores.DataSource = _controller.ObtenerTodos();
                OcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void OcultarColumnas()
        {
            if (dgvVendedores.Columns["VendedorId"] != null) dgvVendedores.Columns["VendedorId"].Visible = false;
            if (dgvVendedores.Columns["Ventas"] != null) dgvVendedores.Columns["Ventas"].Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            if (string.IsNullOrWhiteSpace(busqueda))
                CargarGrilla();
            else
            {
                dgvVendedores.DataSource = _controller.BuscarVendedores(busqueda);
                OcultarColumnas();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmEditVendedor>();
            frm.Configurar(null);
            if (frm.ShowDialog() == DialogResult.OK) CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvVendedores.CurrentRow == null) return;
            var vendedor = (Vendedor)dgvVendedores.CurrentRow.DataBoundItem;

            var frm = _serviceProvider.GetRequiredService<frmEditVendedor>();
            frm.Configurar(vendedor.VendedorId);
            if (frm.ShowDialog() == DialogResult.OK) CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVendedores.CurrentRow == null) return;
            var vendedor = (Vendedor)dgvVendedores.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar a {vendedor.NombreCompleto}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _controller.EliminarVendedor(vendedor.VendedorId);
                    CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar (posiblemente tenga ventas).\n" + ex.Message);
                }
            }
        }
    }
}