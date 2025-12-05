using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models; // Necesario para el tipo Producto

namespace TP_GestionVentas.Views
{
    public partial class frmGestionProductos : Form
    {
        private readonly ProductoController _controller;
        private readonly IServiceProvider _serviceProvider;

        // Constructor con Inyección de Dependencias
        public frmGestionProductos(ProductoController controller, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _controller = controller;
            _serviceProvider = serviceProvider;
        }

        private void frmGestionProductos_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                // 1. Obtener datos del controlador
                var lista = _controller.ObtenerTodos();

                // 2. Asignar a la grilla
                dgvProductos.DataSource = null; // Reset para refrescar correctamente
                dgvProductos.DataSource = lista;

                // 3. Ocultar columnas que no queremos ver (como los ids)
                OcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void OcultarColumnas()
        {
            // Ajustamos esto según lo que EF nos traiga
            if (dgvProductos.Columns["ProductoId"] != null) dgvProductos.Columns["ProductoId"].Visible = false;
            if (dgvProductos.Columns["CategoriaId"] != null) dgvProductos.Columns["CategoriaId"].Visible = false;

            // Las propiedades de navegación (Listas de Stock/Detalles)
            if (dgvProductos.Columns["Stocks"] != null) dgvProductos.Columns["Stocks"].Visible = false;
            if (dgvProductos.Columns["DetallesVenta"] != null) dgvProductos.Columns["DetallesVenta"].Visible = false;
            if (dgvProductos.Columns["Categoria"] != null) dgvProductos.Columns["Categoria"].Visible = false; // Se ve el objeto, luego lo mejoraremos
        }

        // BUSQUEDA EN TIEMPO REAL
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscar.Text;
                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    CargarGrilla(); // Si está vacío, carga todo
                }
                else
                {
                    var listaFiltrada = _controller.BuscarProductos(busqueda);
                    dgvProductos.DataSource = listaFiltrada;
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
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
                return;
            }

            // Obtenemos el objeto completo de la fila seleccionada
            var productoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar '{productoSeleccionado.Nombre}'?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    _controller.EliminarProducto(productoSeleccionado.ProductoId);
                    CargarGrilla();
                    MessageBox.Show("Producto eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // 1. Pedir una nueva instancia del formulario al DI
            var frm = _serviceProvider.GetRequiredService<frmEditProducto>();

            // 2. Configurarlo en modo Alta (sin ID)
            frm.Configurar(null);

            // 3. Mostrarlo y esperar resultado
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla(); // Refrescar la lista si se guardó algo
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para modificar.");
                return;
            }

            // Obtener el objeto seleccionado
            var productoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            // 1. Pedir instancia
            var frm = _serviceProvider.GetRequiredService<frmEditProducto>();

            // 2. Configurarlo en modo Edición (con ID)
            frm.Configurar(productoSeleccionado.ProductoId);

            // 3. Mostrar
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }
    }
}