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
    public partial class frmReservas : Form
    {
        private readonly ReservaController _reservaController;
        private readonly IServiceProvider _serviceProvider;

        public frmReservas(ReservaController reservaController, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _reservaController = reservaController;
            _serviceProvider = serviceProvider;
        }

        private void frmReservas_Load(object sender, EventArgs e)
        {
            CargarReservas(); // Carga inicial
            AjustarVisualizacion();
        }

        private void CargarReservas()
        {
            try
            {
                dgvReservas.DataSource = _reservaController.ObtenerTodasReservasVista().ToList();

                if (dgvReservas.Columns.Contains("ReservaId"))
                {
                    dgvReservas.Columns["ReservaId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservas: {ex.Message}");
            }
        }
        private int? GetIdSeleccionado()
        {
            if (dgvReservas.CurrentRow != null)
            {
                return (int)dgvReservas.CurrentRow.Cells["ReservaId"].Value;
            }
            return null;
        }

        // EVENTOS DEL FORMULARIO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmEditReserva>();
            frm.ShowDialog();
            CargarReservas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetIdSeleccionado();
            if (id.HasValue)
            {
                var frm = _serviceProvider.GetRequiredService<frmEditReserva>();
                frm.LoadData(id.Value);
                frm.ShowDialog();
                CargarReservas();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetIdSeleccionado();
            if (id.HasValue && MessageBox.Show("¿Seguro de eliminar la reserva?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _reservaController.BajaReserva(id.Value);
                    MessageBox.Show("Reserva eliminada con éxito.", "Baja Exitosa");
                    CargarReservas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void AjustarVisualizacion()
        {
            if (dgvReservas.Columns.Count == 0) 
                return;

            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Ancho total mínimo (aproximadamente 1200px)
            dgvReservas.Columns["TipoReserva"].Width = 90;
            dgvReservas.Columns["Frecuencia"].Width = 80;
            dgvReservas.Columns["CantidadSemanas"].Width = 60;
            dgvReservas.Columns["Laboratorio"].Width = 80;
            dgvReservas.Columns["Profesor"].Width = 150;
            dgvReservas.Columns["Asignatura"].Width = 150;
            dgvReservas.Columns["Carrera"].Width = 150;
            dgvReservas.Columns["Comision"].Width = 100;
            dgvReservas.Columns["Inicio"].Width = 100;
            dgvReservas.Columns["Fin"].Width = 100;
            dgvReservas.Columns["Observaciones"].Width = 150;
            dgvReservas.Columns["Activa"].Width = 60;

            // Ocultar ID
            if (dgvReservas.Columns.Contains("ReservaId"))
            {
                dgvReservas.Columns["ReservaId"].Visible = false;
            }

            // --- Definir Orden y Títulos (DisplayIndex) ---
            try
            {
                dgvReservas.Columns["TipoReserva"].DisplayIndex = 0;
                dgvReservas.Columns["Frecuencia"].DisplayIndex = 1;
                dgvReservas.Columns["CantidadSemanas"].DisplayIndex = 2;
                dgvReservas.Columns["Laboratorio"].DisplayIndex = 3;
                dgvReservas.Columns["Profesor"].DisplayIndex = 4;
                dgvReservas.Columns["Asignatura"].DisplayIndex = 5;
                dgvReservas.Columns["Carrera"].DisplayIndex = 6;
                dgvReservas.Columns["Comision"].DisplayIndex = 7;
                dgvReservas.Columns["Inicio"].DisplayIndex = 8;
                dgvReservas.Columns["Fin"].DisplayIndex = 9;
                dgvReservas.Columns["Observaciones"].DisplayIndex = 10;
                dgvReservas.Columns["Activa"].DisplayIndex = 11;

                dgvReservas.Columns["TipoReserva"].HeaderText = "Tipo";
                dgvReservas.Columns["Laboratorio"].HeaderText = "Lab Nro.";
                dgvReservas.Columns["CantidadSemanas"].HeaderText = "Semanas";
                dgvReservas.Columns["Inicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvReservas.Columns["Fin"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al configurar columna: {ex.Message}");
            }
        }
    }
}
