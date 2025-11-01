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
    public partial class frmEditReserva : Form
    {
        private readonly ReservaController _reservaController;
        private int? _reservaId; // Null: Alta, Valor: Edición

        public frmEditReserva(ReservaController reservaController)
        {
            InitializeComponent();
            _reservaController = reservaController;
            _reservaId = null;
            this.Text = "Nueva Reserva";

            // 1. Suscribir el evento ANTES de CargarDatosDeReferencia
            cbxTipoReserva.SelectedIndexChanged += cbxTipoReserva_SelectedIndexChanged;

            LimpiarCampos();
            CargarDatosDeReferencia();
            if (cbxTipoReserva.Items.Count > 0)
            {
                cbxTipoReserva.SelectedIndex = 0; // Forzar la selección del primer elemento
            }
        }
        public void LoadData(int reservaId)
        {
            this.Text = "Agregar/Modificar Reserva";
            _reservaId = reservaId;
            CargarDatosReserva(reservaId);

            // No se permitirá modificar el tipo de reserva una vez creada
            cbxTipoReserva.Enabled = false;
        }
        private void CargarDatosDeReferencia()
        {
            // 1. LABORATORIOS
            cbxLaboratorio.DataSource = _reservaController.ObtenerDatosLaboratorios();
            cbxLaboratorio.DisplayMember = "Numero";
            cbxLaboratorio.ValueMember = "LaboratorioId";
            cbxLaboratorio.SelectedIndex = -1;

            // 2. PROFESORES
            cbxProfesor.DataSource = _reservaController.ObtenerDatosProfesores();
            cbxProfesor.DisplayMember = "NombreCompleto";
            cbxProfesor.ValueMember = "ProfesorId";
            cbxProfesor.SelectedIndex = -1;

            // 3. TIPOS DE RESERVA
            cbxTipoReserva.DataSource = _reservaController.ObtenerDatosTiposReserva();
            cbxTipoReserva.DisplayMember = "Codigo";
            cbxTipoReserva.ValueMember = "TipoReservaId";
            cbxTipoReserva.SelectedIndex = -1;

            // 4. CARRERAS
            cbxCarrera.DataSource = _reservaController.ObtenerDatosCarreras();
            cbxCarrera.DisplayMember = "Nombre";
            cbxCarrera.ValueMember = "CarreraId";
            cbxCarrera.SelectedIndex = -1;

            // 5. ASIGNATURAS
            cbxAsignatura.DataSource = _reservaController.ObtenerDatosAsignaturas();
            cbxAsignatura.DisplayMember = "Nombre";
            cbxAsignatura.ValueMember = "AsignaturaId";
            cbxAsignatura.SelectedIndex = -1;

            // 6. COMISIONES
            cbxComision.DataSource = _reservaController.ObtenerDatosComisiones();
            cbxComision.DisplayMember = "Codigo";
            cbxComision.ValueMember = "ComisionId";
            cbxComision.SelectedIndex = -1;

        }
        private void CargarDatosReserva(int id)
        {
            try
            {
                var reserva = _reservaController.GetReservaParaEdicion(id);
                if (reserva == null)
                {
                    MessageBox.Show("Reserva no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Propiedades comunes
                dtpFechaInicio.Value = reserva.FechaInicio;
                dtpFechaFin.Value = reserva.FechaFin;
                cbxLaboratorio.SelectedValue = reserva.LaboratorioId;
                cbxProfesor.SelectedValue = reserva.ProfesorId;
                cbxAsignatura.SelectedValue = reserva.AsignaturaId;
                cbxCarrera.SelectedValue = reserva.CarreraId;
                cbxComision.SelectedValue = reserva.ComisionId;
                cbxTipoReserva.SelectedValue = reserva.TipoReservaId;
                txtObservaciones.Text = reserva.Observaciones;

                // Propiedades especificas
                if (reserva is ReservaCuatrimestral cuatrimestral)
                {
                    cbxTipoReserva.SelectedValue = cuatrimestral.TipoReservaId;
                    dtpFechaFinCuatri.Value = cuatrimestral.FechaFinCuatri;

                    if (cuatrimestral.Frecuencia == "Semanal")
                        rdbSemanal.Checked = true;
                    else
                        rdbQuincenal.Checked = true;
                }
                else if (reserva is ReservaEventual eventual)
                {
                    cbxTipoReserva.SelectedValue = eventual.TipoReservaId;
                    txtCantSemanas.Text = eventual.CantidadSemanas.ToString();
                }

                mostrarOcultarPaneles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la reserva: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void mostrarOcultarPaneles()
        {
            string tipo = cbxTipoReserva.Text;
            gbCuatrimestral.Visible = (tipo == "Cuatrimestral");
            gbEventual.Visible = (tipo == "Eventual");
        }
        private void cbxTipoReserva_SelectedIndexChanged(object? sender, EventArgs e)
        {
            mostrarOcultarPaneles();
        }
        private void LimpiarCampos()
        {
            txtCantSemanas.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddHours(2);
            dtpFechaFinCuatri.Value = DateTime.Today.AddMonths(4);
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Reserva reserva;

            try
            {
                // Primero seteo los datos especificos según el tipo de reserva
                if (cbxTipoReserva.Text == "Cuatrimestral")
                {
                    var cuatrimestral = new ReservaCuatrimestral
                    {
                        Frecuencia = rdbSemanal.Checked ? "Semanal" : "Quincenal",
                        FechaFinCuatri = dtpFechaFinCuatri.Value
                    };
                    reserva = cuatrimestral;
                }
                else if (cbxTipoReserva.Text == "Eventual")
                {
                    var eventual = new ReservaEventual
                    {
                        CantidadSemanas = int.Parse(txtCantSemanas.Text)
                    };
                    reserva = eventual;
                }
                else
                {
                    throw new ArgumentException("Debe seleccionar un tipo de reserva.");
                }

                // Luego asigo las propiedades base comunes
                reserva.LaboratorioId = Convert.ToInt32(cbxLaboratorio.SelectedValue);
                reserva.ProfesorId = Convert.ToInt32(cbxProfesor.SelectedValue);
                reserva.CarreraId = Convert.ToInt32(cbxCarrera.SelectedValue);
                reserva.AsignaturaId = Convert.ToInt32(cbxAsignatura.SelectedValue);
                reserva.ComisionId = Convert.ToInt32(cbxComision.SelectedValue);
                reserva.TipoReservaId = Convert.ToInt32(cbxTipoReserva.SelectedValue);
                reserva.FechaInicio = dtpFechaInicio.Value;
                reserva.FechaFin = dtpFechaFin.Value;
                reserva.Observaciones = txtObservaciones.Text;
                reserva.IsActive = true;

                if (_reservaId.HasValue)
                {
                    // MODIFICACIÓN (UPDATE)
                    reserva.ReservaId = _reservaId.Value;
                    _reservaController.ModificarReserva(reserva);
                }
                else
                {
                    _reservaController.AltaReserva(reserva);
                }

                MessageBox.Show("Reserva guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique que todos los campos numéricos sean válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fatal del sistema: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
