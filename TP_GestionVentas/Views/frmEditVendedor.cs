using System;
using System.Windows.Forms;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmEditVendedor : Form
    {
        private readonly VendedorController _controller;
        private int? _vendedorId;

        public frmEditVendedor(VendedorController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        public void Configurar(int? id = null)
        {
            _vendedorId = id;
            if (_vendedorId.HasValue)
            {
                this.Text = "Modificar Vendedor";
                var v = _controller.ObtenerPorId(_vendedorId.Value);
                if (v != null)
                {
                    txtNombre.Text = v.NombreCompleto;
                    txtEmail.Text = v.Email;
                }
            }
            else
            {
                this.Text = "Nuevo Vendedor";
                txtNombre.Clear();
                txtEmail.Clear();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var vendedor = new Vendedor
                {
                    NombreCompleto = txtNombre.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                if (_vendedorId.HasValue)
                {
                    vendedor.VendedorId = _vendedorId.Value;
                    _controller.ModificarVendedor(vendedor);
                }
                else
                {
                    _controller.CrearVendedor(vendedor);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}