namespace TPReservaLab.Views
{
    public partial class frmLaboratorios : Form
    {

        public frmLaboratorios()
        {
            InitializeComponent();
        }
        private void frmLaboratorios_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmEditLaboratorio frm = new frmEditLaboratorio();
            frm.ShowDialog();
            Refresh();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                frmEditLaboratorio frm = new frmEditLaboratorio(id);
                frm.ShowDialog();
                Refresh();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                if (MessageBox.Show("¿Está seguro de eliminar el Laboratorio seleccionado?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return; // Cancela la operación
                }

                using (var context = new ReservaLabContext())
                {
                    // LÓGICA DE NEGOCIO: VALIDAR RESERVAS ACTIVAS (REQUISITO DEL ENUNCIADO)
                    bool hasActiveReservations = context.Reservas.Any(r => r.LaboratorioId == id && r.IsActive);

                    if (hasActiveReservations)
                    {
                        MessageBox.Show("No se puede eliminar este laboratorio porque tiene reservas activas asignadas.", "Error de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Detiene la eliminación
                    }

                    // Si no hay reservas activas, procede con la eliminación
                    var lab = context.Laboratorios.Find(id);
                    if (lab != null)
                    {
                        context.Laboratorios.Remove(lab);
                        context.SaveChanges();
                        MessageBox.Show("Laboratorio eliminado con éxito.", "Baja Exitosa");
                    }
                }
                Refresh();
            }
        }


        #region HELPER
        private void Refresh()
        {
            using (var context = new ReservaLabContext())
            {
                var lst = context.Laboratorios.ToList();
                dataGridLaboratorios.DataSource = lst;

                if (dataGridLaboratorios.Columns.Contains("LaboratorioId"))
                    dataGridLaboratorios.Columns["LaboratorioId"].Visible = false;

            }
        }

        private int? GetId()
        {
            try
            {
                if (dataGridLaboratorios.CurrentRow == null) return null;

                return int.Parse(dataGridLaboratorios.Rows[dataGridLaboratorios.CurrentRow.Index].Cells[0].Value.ToString());
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
