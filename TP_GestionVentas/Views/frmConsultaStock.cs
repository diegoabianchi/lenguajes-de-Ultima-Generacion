using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmConsultaStock : Form
    {
        private readonly ProductoController _controller;

        public frmConsultaStock(ProductoController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void frmConsultaStock_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            // Cargar todo al inicio
            EjecutarConsulta();
        }

        private void CargarSucursales()
        {
            try
            {
                var lista = _controller.ObtenerSucursales();

                // Agregamos una opción "Todas" ficticia
                lista.Insert(0, new Sucursal { SucursalId = 0, Nombre = "--- Todas las Sucursales ---" });

                cbxSucursal.DisplayMember = "Nombre";
                cbxSucursal.ValueMember = "SucursalId";
                cbxSucursal.DataSource = lista;
                cbxSucursal.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursales: " + ex.Message);
            }
        }

        private void EjecutarConsulta()
        {
            try
            {
                int? sucursalId = null;
                if (cbxSucursal.SelectedValue != null && (int)cbxSucursal.SelectedValue > 0)
                {
                    sucursalId = (int)cbxSucursal.SelectedValue;
                }

                string busqueda = txtBuscar.Text.Trim();

                var resultados = _controller.ConsultarDisponibilidad(sucursalId, busqueda);
                dgvStock.DataSource = resultados;

                // Formato condicional simple (Opcional): Pintar de rojo si Stock es 0
                ConfigurarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error consultando stock: " + ex.Message);
            }
        }

        private void ConfigurarGrilla()
        {
            // Ocultar columnas feas si es necesario, o ajustar anchos
            if (dgvStock.Columns.Count > 0)
            {
                dgvStock.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvStock.Columns["Cantidad"].Width = 80;
            }
        }

        // Eventos para filtrar automáticamente
        private void cbxSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            EjecutarConsulta();
        }
        private void txtBuscar_KeyUp(object sender, EventArgs e)
        {
            EjecutarConsulta();
        }
    }
}