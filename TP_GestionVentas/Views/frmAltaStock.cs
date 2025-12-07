using System;
using System.Drawing;
using System.Windows.Forms;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmAltaStock : Form
    {
        private readonly ProductoController _controller;
        private Producto? _productoSeleccionado;

        public frmAltaStock(ProductoController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void frmAltaStock_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            ConfigurarGrilla();
            CargarProductosInicial();
        }

        private void ConfigurarGrilla()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Cód", Width = 80 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Producto", Width = 250 });

            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
        }

        private void CargarSucursales()
        {
            try
            {
                cbxSucursal.DisplayMember = "Nombre";
                cbxSucursal.ValueMember = "SucursalId";
                cbxSucursal.DataSource = _controller.ObtenerSucursales();
                cbxSucursal.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando sucursales: " + ex.Message);
            }
        }

        private void CargarProductosInicial()
        {
            try
            {
                dgvProductos.DataSource = _controller.BuscarProductos("");
                dgvProductos.ClearSelection();
            }
            catch { }
        }

        // Búsqueda dinámica al escribir
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscar.Text;
                dgvProductos.DataSource = _controller.BuscarProductos(busqueda);

                if (dgvProductos.Rows.Count == 0)
                    dgvProductos.DataSource = null;
            }
            catch { }
        }

        // Selección del producto
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _productoSeleccionado = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                lblProductoSeleccionado.Text = _productoSeleccionado.Nombre;
                lblProductoSeleccionado.ForeColor = Color.Blue;
                numCantidad.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (cbxSucursal.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una sucursal.");
                    return;
                }

                if (_productoSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un producto de la grilla.");
                    return;
                }

                int cantidad = (int)numCantidad.Value;
                int sucursalId = (int)cbxSucursal.SelectedValue;
                int productoId = _productoSeleccionado.ProductoId;

                // Llamada al controlador
                _controller.SumarStock(productoId, sucursalId, cantidad);

                MessageBox.Show($"Se agregaron {cantidad} unidades correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Resetear campos para seguir cargando
                numCantidad.Value = 0;
                _productoSeleccionado = null;
                lblProductoSeleccionado.Text = "-";
                lblProductoSeleccionado.ForeColor = Color.Black;
                txtBuscar.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
    }
}