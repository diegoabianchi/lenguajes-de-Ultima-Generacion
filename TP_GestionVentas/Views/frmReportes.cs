using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TP_GestionVentas.Controllers;

namespace TP_GestionVentas.Views
{
    public partial class frmReportes : Form
    {
        private readonly ReporteController _controller;

        public frmReportes(ReporteController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            // Configuración inicial de fechas: Primer día del mes actual hasta hoy
            var hoy = DateTime.Now;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = hoy;

            ConfigurarGrillas();
        }

        private void ConfigurarGrillas()
        {
            // Estilo general para todas las grillas (Opcional, para que se vean mejor)
            ConfigurarEstiloGrilla(dgvProductosTop);
            ConfigurarEstiloGrilla(dgvSucursales);
            ConfigurarEstiloGrilla(dgvVendedores);
        }

        private void ConfigurarEstiloGrilla(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date; // .Date para quitar la hora y empezar a las 00:00
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1); // Final del día (23:59:59)

                // 1. Reporte de Productos Top
                var listaTop = _controller.ReporteProductosTop(desde, hasta);
                dgvProductosTop.DataSource = listaTop;

                // 2. Reporte por Sucursal
                var listaSucursal = _controller.ReporteVentasPorSucursal(desde, hasta);
                dgvSucursales.DataSource = listaSucursal;

                // Formatear columnas de moneda si es necesario
                if (dgvSucursales.Columns["TotalFacturado"] != null)
                    dgvSucursales.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";

                // 3. Reporte por Vendedor
                var listaVendedor = _controller.ReporteVentasPorVendedor(desde, hasta);
                dgvVendedores.DataSource = listaVendedor;

                if (dgvVendedores.Columns["TotalFacturado"] != null)
                    dgvVendedores.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";

                MessageBox.Show("Reportes generados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reportes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}