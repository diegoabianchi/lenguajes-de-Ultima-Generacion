using System;
using System.Windows.Forms;
using TP_GestionVentas.Controllers;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Views
{
    public partial class frmEditCliente : Form
    {
        private readonly ClienteController _controller;
        private int? _clienteId;

        public frmEditCliente(ClienteController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        public void Configurar(int? id = null)
        {
            _clienteId = id;
            if (_clienteId.HasValue)
            {
                this.Text = "Modificar Cliente";
                CargarDatos();
            }
            else
            {
                this.Text = "Nuevo Cliente";
                Limpiar();
            }
        }

        private void CargarDatos()
        {
            var c = _controller.ObtenerPorId(_clienteId.Value);
            if (c != null)
            {
                txtNombre.Text = c.NombreCompleto;
                txtDNI.Text = c.CUIT_DNI;
                txtEmail.Text = c.Email;
                cbxTipo.SelectedItem = c.TipoCliente;
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            cbxTipo.SelectedIndex = 0; // Seleccionar Minorista por defecto
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Cliente
                {
                    NombreCompleto = txtNombre.Text.Trim(),
                    CUIT_DNI = txtDNI.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    TipoCliente = cbxTipo.SelectedItem?.ToString() ?? "Minorista"
                };

                if (_clienteId.HasValue)
                {
                    cliente.ClienteId = _clienteId.Value;
                    _controller.ModificarCliente(cliente);
                    MessageBox.Show("Cliente modificado.");
                }
                else
                {
                    _controller.CrearCliente(cliente);
                    MessageBox.Show("Cliente creado.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}