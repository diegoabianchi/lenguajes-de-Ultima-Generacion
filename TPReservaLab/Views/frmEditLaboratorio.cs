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
 
        public int? id;
        Laboratorio oLaboratorio = null;
        public frmEditLaboratorio(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
            {
                CargaDatosLaboratorio();
            }
        }
        private void CargaDatosLaboratorio()
        {
            using (var context = new ReservaLabContext())
            {
                oLaboratorio = context.Laboratorios.Find(id);
                txtNumero.Text = oLaboratorio.Numero.ToString();
                txtUbicacion.Text = oLaboratorio.UbicacionPiso.ToString();
                txtCapacidad.Text = oLaboratorio.CapacidadPuestos.ToString();
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var context = new ReservaLabContext())
            {
                if (oLaboratorio == null)
                {
                    // Creacion de nuevo alumno
                    Laboratorio newLab = new Laboratorio
                    {
                        Numero = int.Parse(txtNumero.Text),
                        UbicacionPiso = txtUbicacion.Text,
                        CapacidadPuestos = int.Parse(txtCapacidad.Text)
                        
                    };
                    context.Laboratorios.Add(newLab);
                }
                else
                {
                    // Modificacion 
                    oLaboratorio.Numero = int.Parse(txtNumero.Text);
                    oLaboratorio.UbicacionPiso = txtUbicacion.Text;
                    oLaboratorio.CapacidadPuestos = int.Parse(txtCapacidad.Text);
                    context.Entry(oLaboratorio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                context.SaveChanges();
                this.Close();
            }
        }

        private void frmEditLaboratorio_Load(object sender, EventArgs e)
        {
            return;
        }
    }
}
