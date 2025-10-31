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
        private readonly ReservaRepository _reservaRepository;
        private int? _reservaId;
        public frmEditReserva(int? reservaId = null)
        {
            InitializeComponent();
            _reservaRepository = new ReservaRepository(); // Usa la conexión directa
            _reservaId = reservaId;

            CargarDatosDeReferencia(); // Carga ComboBoxes (Laboratorios, Profesores, Tipos)

            // Asocia el evento de cambio de tipo para ocultar/mostrar paneles
            cbxTipoReserva.SelectedIndexChanged += cbxTipoReserva_SelectedIndexChanged;

            if (_reservaId.HasValue)
            {
                CargarDatosReserva(_reservaId.Value);
            }
            else
            {
                // Establecer un valor inicial para mostrar un panel al inicio (ej. Cuatrimestral)
                cbxTipoReserva.SelectedIndex = 0;
            }
        }

        // --- LÓGICA DE HERENCIA: Mostrar/Ocultar Paneles ---
        private void cbxTipoReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cbxTipoReserva.Text;

            gbCuatrimestral.Visible = (tipo == "Cuatrimestral");
            gbEventual.Visible = (tipo == "Eventual");
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Reserva reserva;

                // Lógica para construir el objeto del MODELO (Reserva)
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
                else { throw new ArgumentException("Debe seleccionar un tipo de reserva."); }

                // Asignar propiedades comunes
                reserva.LaboratorioId = (int)cbxLaboratorio.SelectedValue;
                reserva.ProfesorId = (int)cbxProfesor.SelectedValue;
                // ... Asignar AsignaturaId, CarreraId, ComisionId
                reserva.FechaInicio = dtpFechaInicio.Value;
                reserva.FechaFin = dtpFechaFin.Value;

                // Llamada al Repositorio (la validación de conflicto debe estar aquí o en el Repositorio)
                if (_reservaId.HasValue)
                {
                    // MODIFICACIÓN: La validación de conflicto en el Repositorio debe excluir esta reserva.
                    reserva.ReservaId = _reservaId.Value;
                    _reservaRepository.Update(reserva);
                }
                else
                {
                    // ALTA: La validación de conflicto se ejecuta sobre todas las reservas.
                    _reservaRepository.Add(reserva);
                }

                MessageBox.Show("Reserva guardada con éxito.", "Éxito");
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                // Captura el error de Conflicto de Horario o validación de negocio
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosDeReferencia()
        {
            // 1. LABORATORIOS
            cbxLaboratorio.DataSource = _reservaRepository.GetLaboratorios();
            cbxLaboratorio.DisplayMember = "Numero";
            cbxLaboratorio.ValueMember = "LaboratorioId";

            // 2. PROFESORES
            cbxProfesor.DataSource = _reservaRepository.GetProfesores();
            cbxProfesor.DisplayMember = "NombreCompleto";
            cbxProfesor.ValueMember = "ProfesorId";

            // 3. TIPOS DE RESERVA
            cbxTipoReserva.DataSource = _reservaRepository.GetTiposReserva();
            cbxTipoReserva.DisplayMember = "Codigo";
            cbxTipoReserva.ValueMember = "TipoReservaId";

            // 4. CARRERAS
            cbxCarrera.DataSource = _reservaRepository.GetCarreras();
            cbxCarrera.DisplayMember = "Nombre";
            cbxCarrera.ValueMember = "CarreraId";

            // 5. ASIGNATURAS
            cbxAsignatura.DataSource = _reservaRepository.GetAsignaturas();
            cbxAsignatura.DisplayMember = "Nombre";
            cbxAsignatura.ValueMember = "AsignaturaId";

            // 6. COMISIONES
            cbxComision.DataSource = _reservaRepository.GetComisiones();
            cbxComision.DisplayMember = "Codigo";
            cbxComision.ValueMember = "ComisionId";
        }

        private void CargarDatosReserva(int id)
        {
            var reserva = _reservaRepository.GetReservaDetalle(id);

            if (reserva == null)
            {
                MessageBox.Show("Reserva no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // --- CARGA DE PROPIEDADES Comunes ---
            dtpFechaInicio.Value = reserva.FechaInicio;
            dtpFechaFin.Value = reserva.FechaFin;

            // Establecer el valor seleccionado en los ComboBoxes (usando ValueMember)
            cbxLaboratorio.SelectedValue = reserva.LaboratorioId;
            cbxProfesor.SelectedValue = reserva.ProfesorId;
            cbxAsignatura.SelectedValue = reserva.AsignaturaId;
            cbxCarrera.SelectedValue = reserva.CarreraId;
            cbxComision.SelectedValue = reserva.ComisionId;
            cbxTipoReserva.SelectedValue = reserva.TipoReservaId;

            if (reserva is ReservaCuatrimestral cuatrimestral)
            {
                // 1. Es Cuatrimestral: Habilitar el panel Cuatrimestral (el evento SelectedIndexChanged ya lo hace)
                dtpFechaFinCuatri.Value = cuatrimestral.FechaFinCuatri;

                if (cuatrimestral.Frecuencia == "Semanal")
                    rdbSemanal.Checked = true;
                else
                    rdbQuincenal.Checked = true;

            }
            else if (reserva is ReservaEventual eventual)
            {
                // 2. Es Eventual: Habilitar el panel Eventual
                txtCantSemanas.Text = eventual.CantidadSemanas.ToString();
            }
        }
    }
}
