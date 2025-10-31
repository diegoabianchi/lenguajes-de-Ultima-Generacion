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
    public partial class frmReservas : Form
    {
        private readonly ReservaRepository _reservaRepository;
        public frmReservas()
        {
            InitializeComponent();
            _reservaRepository = new ReservaRepository();
            Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmEditReserva frm = new frmEditReserva();
            frm.ShowDialog();
            Refresh();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                frmEditReserva frm = new frmEditReserva(id);
                frm.ShowDialog();
                Refresh();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            return;
        }

        private void frmReservas_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        #region HELPER
        private void Refresh()
        {
            dgvReservas.DataSource = _reservaRepository.GetAllReservasVista();

            if (dgvReservas.Columns.Contains("ReservaId"))
            {
                dgvReservas.Columns["ReservaId"].Visible = false;
            }
            AjustarVisualizacion();
        }

        private void AjustarVisualizacion()
        {
            // Si no hay columnas, salir
            if (dgvReservas.Columns.Count == 0) return;

            // --- 1. CONFIGURACIÓN DE ORDEN Y TÍTULOS ---
            dgvReservas.AutoGenerateColumns = true;

            // Definir el orden de las columnas por índice (ej: 0, 1, 2, ...)
            dgvReservas.Columns["TipoReserva"].DisplayIndex = 0;
            dgvReservas.Columns["Laboratorio"].DisplayIndex = 1;
            dgvReservas.Columns["Profesor"].DisplayIndex = 2;
            dgvReservas.Columns["Inicio"].DisplayIndex = 3;
            dgvReservas.Columns["Fin"].DisplayIndex = 4;

            // Mejorar los títulos
            dgvReservas.Columns["TipoReserva"].HeaderText = "Tipo";
            dgvReservas.Columns["Laboratorio"].HeaderText = "Lab Nro.";
            dgvReservas.Columns["Inicio"].HeaderText = "Inicio (Fecha y Hora)";

            // --- 2. FORMATO DE FECHA/HORA ---
            // Muestra la fecha y hora completa en formato local
            dgvReservas.Columns["Inicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvReservas.Columns["Fin"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Opcional: Ajustar el ancho
            dgvReservas.Columns["Inicio"].Width = 150;
        }
        private int? GetId()
        {
            try
            {
                if (dgvReservas.CurrentRow == null) return null;

                return int.Parse(dgvReservas.Rows[dgvReservas.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Seleccione una fila válida.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion


    }
}
