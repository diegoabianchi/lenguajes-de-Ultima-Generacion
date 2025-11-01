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
    public partial class frmEditLaboratorio : Form
    {

        private readonly LaboratorioController _laboratorioController;
        private readonly ILaboratorioRepository _laboratorioRepository; // Necesario para el GetById
        private int? _laboratorioId; // Null: Alta, Valor: Edición
        public frmEditLaboratorio(LaboratorioController laboratorioController, ILaboratorioRepository laboratorioRepository)
        {
            InitializeComponent();
            _laboratorioController = laboratorioController;
            _laboratorioRepository = laboratorioRepository;
        }
        public void LoadData(int laboratorioId)
        {
            _laboratorioId = laboratorioId;
            this.Text = "Modificar Laboratorio";
            CargarDatosLaboratorio(laboratorioId);
        }
        private void CargarDatosLaboratorio(int id)
        {
            var lab = _laboratorioRepository.GetById(id);

            if (lab != null)
            {
                txtNumero.Text = lab.Numero.ToString();
                txtUbicacion.Text = lab.UbicacionPiso;
                txtCapacidad.Text = lab.CapacidadPuestos.ToString();
            }
            else
            {
                throw new KeyNotFoundException($"Laboratorio con ID {id} no encontrado.");
            }
        }


        // EVENTOS DEL FORMULARIO
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var lab = new Laboratorio
                {
                    Numero = int.Parse(txtNumero.Text),
                    UbicacionPiso = txtUbicacion.Text,
                    CapacidadPuestos = int.Parse(txtCapacidad.Text)
                };

                if (_laboratorioId.HasValue)
                {
                    // MODIFICACIÓN (UPDATE)
                    lab.LaboratorioId = _laboratorioId.Value;
                    _laboratorioController.ModificarLaboratorio(lab);
                }
                else
                {
                    // ALTA (CREATE)
                    _laboratorioController.CrearLaboratorio(lab);
                }

                MessageBox.Show("Laboratorio guardado con éxito.", "Éxito");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique que los campos 'Número' y 'Capacidad' sean números enteros válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEditLaboratorio_Load(object sender, EventArgs e)
        {
            return;
        }
    }
}
