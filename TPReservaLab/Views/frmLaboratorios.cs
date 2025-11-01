using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace TPReservaLab.Views
{
    public partial class frmLaboratorios : Form
    {
        private readonly LaboratorioController _laboratorioController;
        private readonly IServiceProvider _serviceProvider;
        private int _laboratorioIdSeleccionado = 0; // Para rastrear el elemento en Edición/Baja


        public frmLaboratorios(LaboratorioController laboratorioController, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _laboratorioController = laboratorioController;
            _serviceProvider = serviceProvider;
            CargarLaboratorios();
        }
        private void CargarLaboratorios()
        {
            try
            {
                // La Vista usa el Controlador para obtener datos
                dgvLaboratorios.DataSource = _laboratorioController.ObtenerTodos();
                dgvLaboratorios.Columns["LaboratorioId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar laboratorios: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int? GetIdSeleccionado()
        {
            try
            {
                if (dgvLaboratorios.CurrentRow == null) return null;
                // Asumiendo que el ID es la primera columna
                return (int)dgvLaboratorios.Rows[dgvLaboratorios.CurrentRow.Index].Cells["LaboratorioId"].Value;
            }
            catch { return null; }
        }
        private void dgvLaboratorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Para manejar la selección de fila para Edición/Baja
            if (e.RowIndex >= 0 && dgvLaboratorios.Rows[e.RowIndex].Cells["LaboratorioId"].Value != null)
            {
                _laboratorioIdSeleccionado = (int)dgvLaboratorios.Rows[e.RowIndex].Cells["LaboratorioId"].Value;
                // Opcional: Cargar datos a campos de texto si no usa frmEditLaboratorio
            }
        }


        // EVENTOS DEL FORMULARIO
        private void frmLaboratorios_Load(object sender, EventArgs e)
        {
            CargarLaboratorios();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmEditLaboratorio>();
            frm.ShowDialog();
            CargarLaboratorios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetIdSeleccionado();
            if (id.HasValue)
            {
                // 1. Obtener el formulario de DI (el DI inyecta el Controlador y el Repositorio)
                var frmEdicion = _serviceProvider.GetRequiredService<frmEditLaboratorio>();
                frmEdicion.LoadData(id.Value);
                frmEdicion.ShowDialog();
                CargarLaboratorios();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetIdSeleccionado();
            if (id.HasValue && MessageBox.Show("¿Seguro de eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // El formulario llama al Controlador (Lógica de Negocio)
                    _laboratorioController.EliminarLaboratorio(id.Value);
                    MessageBox.Show("Laboratorio eliminado con éxito.", "Baja Exitosa");
                    CargarLaboratorios();
                }
                catch (InvalidOperationException ex)
                {
                    // Captura la regla de negocio: "Tiene reservas activas"
                    MessageBox.Show(ex.Message, "Advertencia de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
