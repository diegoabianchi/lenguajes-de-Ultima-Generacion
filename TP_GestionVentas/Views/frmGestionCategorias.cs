using System;
using System.Windows.Forms;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmGestionCategorias : Form
    {
        private readonly CategoriaController _controller;
        private int _idSeleccionado = 0; // 0 = Modo Alta

        public frmGestionCategorias(CategoriaController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void frmGestionCategorias_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarDatos();
        }

        private void ConfigurarGrilla()
        {
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.ReadOnly = true;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.RowHeadersVisible = false;
        }

        private void CargarDatos()
        {
            try
            {
                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = _controller.ObtenerTodas();

                // Ocultar columna de Productos (Navegación)
                if (dgvCategorias.Columns["Productos"] != null)
                    dgvCategorias.Columns["Productos"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var cat = new Categoria
                {
                    CategoriaId = _idSeleccionado,
                    Nombre = txtNombre.Text.Trim()
                };

                _controller.GuardarCategoria(cat);

                MessageBox.Show("Categoría guardada correctamente.");
                Limpiar();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una categoría de la lista para eliminar.");
                return;
            }

            var categoriaSeleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"¿Eliminar la categoría '{categoriaSeleccionada.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _controller.EliminarCategoria(categoriaSeleccionada.CategoriaId);

                    CargarDatos();
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar (probablemente tenga productos asociados).\n" + ex.Message);
                }
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            _idSeleccionado = 0;
            dgvCategorias.ClearSelection();
        }

        // Evento al hacer clic en la grilla para editar
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cat = (Categoria)dgvCategorias.Rows[e.RowIndex].DataBoundItem;
                _idSeleccionado = cat.CategoriaId;
                txtNombre.Text = cat.Nombre;
            }
        }
    }
}