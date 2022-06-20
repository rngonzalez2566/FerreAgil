using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }
        BLL.UnidadMedida um = new BLL.UnidadMedida();
        BLL.Producto pr = new BLL.Producto();
        private void Producto_Load(object sender, EventArgs e)
        {
            cargaUnidadMedida();
        }
        public void cargaUnidadMedida()
        {
            cmbUM.DataSource = um.GetUnidadMedidas();
            cmbUM.ValueMember = "Id_unidadMedida";
            cmbUM.DisplayMember = "Nombre";
            cmbUM.SelectedIndex = -1;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                BE.UnidadMedida unidadMedida = new BE.UnidadMedida();
                BE.Producto producto = new BE.Producto();
                unidadMedida = um.GetUnidadMedida(int.Parse(cmbUM.ValueMember));
                producto.codigo = txtCodigo.Text;
                producto.descripcion = txtDescripcion.Text;
                producto.stockMinimo = float.Parse(txtMinimo.Text);
                producto.stockOptimo = float.Parse(txtOptimo.Text);
                producto.unidadMedida = unidadMedida;
                pr.altaProducto(producto);
                MessageBox.Show("Producto dado de Alta con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
    }
}
