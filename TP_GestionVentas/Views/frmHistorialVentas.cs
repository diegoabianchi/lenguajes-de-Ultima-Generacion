using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmHistorialVentas : Form
    {
        private readonly VentaController _controller;

        public frmHistorialVentas(VentaController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void frmHistorialVentas_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas();
            CargarClientes();

            // Fechas por defecto: Mes actual
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = DateTime.Now;

            BuscarVentas();
        }

        private void ConfigurarGrillas()
        {
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.RowHeadersVisible = false;

            dgvDetallesVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetallesVenta.ReadOnly = true;
            dgvDetallesVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetallesVenta.RowHeadersVisible = false;
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = _controller.ObtenerClientes();
                clientes.Insert(0, new Cliente { ClienteId = 0, NombreCompleto = "--- Todos ---" });
                cbxCliente.DataSource = clientes;
                cbxCliente.DisplayMember = "NombreCompleto";
                cbxCliente.ValueMember = "ClienteId";
            }
            catch { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarVentas();
        }

        private void BuscarVentas()
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                int? clienteId = null;

                if (cbxCliente.SelectedValue != null && (int)cbxCliente.SelectedValue > 0)
                {
                    clienteId = (int)cbxCliente.SelectedValue;
                }

                var historial = _controller.ObtenerHistorial(desde, hasta, clienteId);

                dgvDetallesVenta.DataSource = null;
                lblDetalle.Text = "Seleccione una venta para ver detalles";
                dgvVentas.DataSource = historial;


                // Formato moneda
                if (dgvVentas.Columns["Total"] != null)
                {
                    dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
                // Limpiamos si no trajo nada
                if (historial.Count == 0)
                {
                    dgvDetallesVenta.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        // Evento al hacer clic en una venta para ver sus productos
        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null) return;

            // Obtenemos el objeto DTO seleccionado
            var ventaSeleccionada = (TP_GestionVentas.Models.DTOs.VentaHistorialDTO)dgvVentas.CurrentRow.DataBoundItem;

            CargarDetalles(ventaSeleccionada.VentaId);
        }

        private void CargarDetalles(int ventaId)
        {
            try
            {
                lblDetalle.Text = $"Productos de la Venta #{ventaId}";
                var ventaCompleta = _controller.ObtenerDetalleVenta(ventaId);
                if (ventaCompleta != null)
                {
                    // Usamos una proyección simple anónima para mostrar en la grilla
                    dgvDetallesVenta.DataSource = ventaCompleta.Detalles.Select(d => new
                    {
                        Producto = d.Producto.Nombre,
                        Cantidad = d.Cantidad,
                        Unitario = d.PrecioUnitario,
                        Subtotal = d.Subtotal
                    }).ToList();

                    if (dgvDetallesVenta.Columns["Unitario"] != null)
                        dgvDetallesVenta.Columns["Unitario"].DefaultCellStyle.Format = "C2";
                    if (dgvDetallesVenta.Columns["Subtotal"] != null)
                        dgvDetallesVenta.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles: " + ex.Message);
            }
        }
    }
}