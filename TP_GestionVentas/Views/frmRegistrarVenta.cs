using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmRegistrarVenta : Form
    {
        private readonly VentaController _controller;
        private List<DetalleVenta> _carrito;
        private Producto? _productoSeleccionado;

        public frmRegistrarVenta(VentaController controller)
        {
            InitializeComponent();
            _controller = controller;
            _carrito = new List<DetalleVenta>();
        }

        private void frmRegistrarVenta_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ConfigurarGrillas();
            CargarProductosParaBusqueda(); // Carga inicial
            LimpiarPanelProducto();
        }

        private void ConfigurarGrillas()
        {
            // --- 1. Grilla de Búsqueda (Sin cambios) ---
            dgvBusquedaProductos.AutoGenerateColumns = false;
            dgvBusquedaProductos.Columns.Clear();
            dgvBusquedaProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Cód", Width = 80 });
            dgvBusquedaProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Producto", Width = 200 });
            dgvBusquedaProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio", Width = 80 });
            dgvBusquedaProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBusquedaProductos.MultiSelect = false;
            dgvBusquedaProductos.ReadOnly = true;

            // --- 2. Grilla del Carrito
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Clear();

            // Columnas de datos
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Producto", HeaderText = "Producto", Width = 200, ReadOnly = true });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant", Width = 60, ReadOnly = true });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioUnitario", HeaderText = "Unitario", Width = 80, ReadOnly = true });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Subtotal", HeaderText = "Subtotal", Width = 80, ReadOnly = true });

            // --- Columna de Botón Eliminar ---
            var btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "btnEliminar";
            btnEliminar.HeaderText = "";
            btnEliminar.Text = "X";
            btnEliminar.UseColumnTextForButtonValue = true;
            btnEliminar.Width = 25;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.DefaultCellStyle.BackColor = Color.Firebrick;
            btnEliminar.DefaultCellStyle.ForeColor = Color.White;
            btnEliminar.CellTemplate.Style.BackColor = Color.Firebrick;
            btnEliminar.CellTemplate.Style.ForeColor = Color.White;
            btnEliminar.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            btnEliminar.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDetalles.Columns.Add(btnEliminar);
        }

        private void CargarCombos()
        {
            try
            {
                // Sucursales
                var sucursales = _controller.ObtenerSucursales();
                cbxSucursal.ValueMember = "SucursalId";
                cbxSucursal.DisplayMember = "Nombre";
                cbxSucursal.DataSource = sucursales;
                cbxSucursal.SelectedIndex = -1;

                // Vendedores
                var vendedores = _controller.ObtenerVendedores();
                cbxVendedor.ValueMember = "VendedorId";
                cbxVendedor.DisplayMember = "NombreCompleto";
                cbxVendedor.DataSource = vendedores;
                cbxVendedor.SelectedIndex = -1;

                // Clientes
                var clientes = _controller.ObtenerClientes();
                cbxCliente.ValueMember = "ClienteId";
                cbxCliente.DisplayMember = "NombreCompleto";
                cbxCliente.DataSource = clientes;
                cbxCliente.SelectedIndex = -1;

                // Métodos de Pago
                var metodos = _controller.ObtenerMetodosPago();
                cbxMetodoPago.ValueMember = "MetodoPagoId";
                cbxMetodoPago.DisplayMember = "Nombre";
                cbxMetodoPago.DataSource = metodos;
                cbxMetodoPago.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando listas: " + ex.Message);
            }
        }

        // =======================================================
        // LÓGICA DE BÚSQUEDA
        // =======================================================

        private void CargarProductosParaBusqueda()
        {
            try
            {
                // Carga inicial con cadena vacía para traer todo
                var listaProductos = _controller.BuscarProductosLista("");
                dgvBusquedaProductos.DataSource = listaProductos;
                OcultarColumnasBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error catálogo: " + ex.Message);
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscarProducto.Text;

                // Llamamos al controlador
                var resultados = _controller.BuscarProductosLista(busqueda);
                dgvBusquedaProductos.DataSource = resultados;

                if (resultados.Count == 0)
                {
                    dgvBusquedaProductos.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error búsqueda: " + ex.Message);
            }
        }

        private void dgvBusquedaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Seleccionar producto de la grilla
            _productoSeleccionado = (Producto)dgvBusquedaProductos.Rows[e.RowIndex].DataBoundItem;

            if (_productoSeleccionado != null)
            {
                numCantidad.Value = 1;
                numCantidad.Focus();
            }
        }

        private void OcultarColumnasBusqueda()
        {
            if (dgvBusquedaProductos.Columns["ProductoId"] != null) dgvBusquedaProductos.Columns["ProductoId"].Visible = false;
            if (dgvBusquedaProductos.Columns["CategoriaId"] != null) dgvBusquedaProductos.Columns["CategoriaId"].Visible = false;
            if (dgvBusquedaProductos.Columns["Categoria"] != null) dgvBusquedaProductos.Columns["Categoria"].Visible = false;
            if (dgvBusquedaProductos.Columns["Stocks"] != null) dgvBusquedaProductos.Columns["Stocks"].Visible = false;
            if (dgvBusquedaProductos.Columns["DetallesVenta"] != null) dgvBusquedaProductos.Columns["DetallesVenta"].Visible = false;
        }

        // =======================================================
        // CARRITO Y FINALIZACIÓN
        // =======================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Si la variable es nula, intentamos tomar la selección actual de la grilla
            if (_productoSeleccionado == null && dgvBusquedaProductos.CurrentRow != null)
            {
                _productoSeleccionado = (Producto)dgvBusquedaProductos.CurrentRow.DataBoundItem;
            }

            // Validación
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto de la lista.");
                return;
            }

            // Crear el detalle
            int cantidad = (int)numCantidad.Value;
            var detalle = new DetalleVenta
            {
                ProductoId = _productoSeleccionado.ProductoId,
                Producto = _productoSeleccionado,
                Cantidad = cantidad,
                PrecioUnitario = _productoSeleccionado.Precio,
                Subtotal = _productoSeleccionado.Precio * cantidad
            };

            _carrito.Add(detalle);
            RefrescarGrillaCarrito();

            // Limpiamos todo para el siguiente producto
            LimpiarPanelProducto();
        }

        private void RefrescarGrillaCarrito()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _carrito;
            lblTotal.Text = $"Total: {_carrito.Sum(x => x.Subtotal).ToString("C")}";
        }

        private void LimpiarPanelProducto()
        {
            _productoSeleccionado = null;
            txtBuscarProducto.Clear();
            numCantidad.Value = 1;
            CargarProductosParaBusqueda();
            txtBuscarProducto.Focus();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (_carrito.Count == 0) { MessageBox.Show("Carrito vacío."); return; }
            if (cbxSucursal.SelectedIndex == -1) { MessageBox.Show("Falta Sucursal."); return; }
            if (cbxVendedor.SelectedIndex == -1) { MessageBox.Show("Falta Vendedor."); return; }
            if (cbxMetodoPago.SelectedIndex == -1) { MessageBox.Show("Falta Pago."); return; }

            try
            {
                var venta = new Venta
                {
                    FechaVenta = DateTime.Now,
                    SucursalId = (int)cbxSucursal.SelectedValue,
                    VendedorId = (int)cbxVendedor.SelectedValue,
                    MetodoPagoId = (int)cbxMetodoPago.SelectedValue,
                    ClienteId = cbxCliente.SelectedIndex != -1 ? (int?)cbxCliente.SelectedValue : null,
                    TotalFinal = _carrito.Sum(x => x.Subtotal),
                    Detalles = _carrito
                };

                _controller.ProcesarVenta(venta);

                MessageBox.Show("¡Venta Guardada Correctamente!");

                // Reset Total
                _carrito.Clear();
                RefrescarGrillaCarrito();
                LimpiarPanelProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void dgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no sea el encabezado y que la fila sea válida
            if (e.RowIndex < 0) return;

            // Verificar si el clic fue en la columna del botón "btnEliminar"
            if (dgvDetalles.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                // Obtener el objeto que está en esa fila y eliminarlo
                var detalleAEliminar = (DetalleVenta)dgvDetalles.Rows[e.RowIndex].DataBoundItem;
                _carrito.Remove(detalleAEliminar);

                RefrescarGrillaCarrito();
            }
        }
    }
}