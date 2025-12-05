using System;
using System.Windows.Forms;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmEditProducto : Form
    {
        private readonly ProductoController _controller;
        private int? _productoId; // Null = Alta, Valor = Modificación

        // Constructor para Inyección de Dependencias
        public frmEditProducto(ProductoController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        // Método para inicializar el formulario (Alta o Edición)
        public void Configurar(int? id = null)
        {
            _productoId = id;
            CargarCategorias();

            if (_productoId.HasValue)
            {
                this.Text = "Modificar Producto";
                CargarDatosProducto(_productoId.Value);
                txtCodigo.Enabled = false; // Regla de Negocio: No solemos dejar cambiar el código primario
            }
            else
            {
                this.Text = "Nuevo Producto";
                txtCodigo.Enabled = true;
                LimpiarCampos();
            }
        }

        private void CargarCategorias()
        {
            try
            {
                var categorias = _controller.ObtenerCategorias();
                cbxCategoria.DataSource = categorias;
                cbxCategoria.DisplayMember = "Nombre";
                cbxCategoria.ValueMember = "CategoriaId";
                cbxCategoria.SelectedIndex = -1; // Que arranque vacío
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        private void CargarDatosProducto(int id)
        {
            var producto = _controller.ObtenerPorId(id);
            if (producto != null)
            {
                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                numPrecio.Value = producto.Precio;
                cbxCategoria.SelectedValue = producto.CategoriaId;
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            numPrecio.Value = 0;
            cbxCategoria.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones básicas de UI
                if (cbxCategoria.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una categoría.");
                    return;
                }

                // 2. Armar el objeto
                var producto = new Producto
                {
                    Codigo = txtCodigo.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = numPrecio.Value,
                    CategoriaId = (int)cbxCategoria.SelectedValue
                };

                // 3. Enviar al controlador
                if (_productoId.HasValue)
                {
                    producto.ProductoId = _productoId.Value; // Importante para el Update
                    _controller.ModificarProducto(producto);
                    MessageBox.Show("Producto modificado correctamente.");
                }
                else
                {
                    _controller.CrearProducto(producto);
                    MessageBox.Show("Producto creado correctamente.");
                }

                this.DialogResult = DialogResult.OK; // Para avisar al form padre que refresque
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}