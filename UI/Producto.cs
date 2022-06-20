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
            cargarDatos();
        }
        public void cargaUnidadMedida()
        {
            cmbUM.DataSource = um.GetUnidadMedidas();
            cmbUM.ValueMember = "id_UnidadMedida";
            cmbUM.DisplayMember = "Nombre";
            cmbUM.SelectedIndex = -1;

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                BE.UnidadMedida unidadMedida = new BE.UnidadMedida();
                BE.Producto producto = new BE.Producto();
                int idUM = cmbUM.SelectedValue != null ? int.Parse(cmbUM.SelectedValue.ToString()):0;
                unidadMedida = um.GetUnidadMedida(idUM);
                producto.codigo = txtCodigo.Text;
                producto.descripcion = txtDescripcion.Text;
                producto.stockMinimo = txtMinimo.Text == "" ? 0 : float.Parse(txtMinimo.Text);
                producto.stockOptimo = txtOptimo.Text == "" ? 0 : float.Parse(txtOptimo.Text);
                producto.unidadMedida = unidadMedida;
                producto.leadTimeCompra = 0;
                producto.consumoMensual = 0;
                producto.consumoTrimestral = 0;
                producto.consumoSemestral = 0;
                pr.altaProducto(producto);
                MessageBox.Show("Producto dado de Alta con exito");
                cargarDatos();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtOptimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        public void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            cmbUM.SelectedIndex = -1;
            txtMinimo.Text = 0.ToString();
            txtOptimo.Text = 0.ToString();

        }
        public void cargarDatos()
        {
            dtgProductos.DataSource = null;
            dtgProductos.Columns.Clear();

            dtgProductos.ColumnCount = 8;
            dtgProductos.Columns[0].Name = "Codigo";
            dtgProductos.Columns[1].Name = "Descripcion";
            dtgProductos.Columns[2].Name = "Unidad Medida";
            dtgProductos.Columns[3].Name = "Stock Minimo";
            dtgProductos.Columns[4].Name = "Stock Optimo";
            dtgProductos.Columns[5].Name = "Consumo Mensual";
            dtgProductos.Columns[6].Name = "Consumo Trimestral";
            dtgProductos.Columns[7].Name = "Consumo Semestral";


            List <BE.Producto> productos = pr.GetProductos();
            foreach (BE.Producto lista in productos)
            {
                dtgProductos.Rows.Add(lista.codigo,lista.descripcion,lista.unidadMedida.nombre,lista.stockMinimo,lista.stockOptimo,lista.consumoMensual,lista.consumoTrimestral,lista.consumoSemestral);
            }
        }

        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDescripcion.Text = dtgProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMinimo.Text = dtgProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtOptimo.Text = dtgProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
