using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmGestionClientes : Form
    {
        private readonly ClienteController _controller;
        private readonly IServiceProvider _serviceProvider;

        public frmGestionClientes(ClienteController controller, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _controller = controller;
            _serviceProvider = serviceProvider;
        }

        private void frmGestionClientes_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                var lista = _controller.ObtenerTodos();
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = lista;
                OcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void OcultarColumnas()
        {
            if (dgvClientes.Columns["ClienteId"] != null) dgvClientes.Columns["ClienteId"].Visible = false;
            // Ocultar la propiedad de navegación "Ventas" para que no rompa la grilla
            if (dgvClientes.Columns["Ventas"] != null) dgvClientes.Columns["Ventas"].Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscar.Text;
                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    CargarGrilla();
                }
                else
                {
                    dgvClientes.DataSource = _controller.BuscarClientes(busqueda);
                    OcultarColumnas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
                return;
            }

            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar a {cliente.NombreCompleto}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _controller.EliminarCliente(cliente.ClienteId);
                    CargarGrilla();
                    MessageBox.Show("Cliente eliminado.");
                }
                catch (Exception ex)
                {
                    // Aquí capturamos si tiene ventas asociadas (DeleteBehavior.Restrict)
                    MessageBox.Show("No se pudo eliminar (probablemente tenga ventas asociadas).\nDetalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmEditCliente>();
            frm.Configurar(null);
            if (frm.ShowDialog() == DialogResult.OK) CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;
            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            var frm = _serviceProvider.GetRequiredService<frmEditCliente>();
            frm.Configurar(cliente.ClienteId);
            if (frm.ShowDialog() == DialogResult.OK) CargarGrilla();
        }
    }
}