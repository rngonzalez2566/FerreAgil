using Interfaces;
using Services;
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
    public partial class Producto : Form, IIdiomaObserver
    {
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        public Producto()
        {
            InitializeComponent();
        }
        BLL.UnidadMedida um = new BLL.UnidadMedida();
        BLL.Producto pr = new BLL.Producto();
        BE.UnidadMedida unidadMedida = new BE.UnidadMedida();
        int idProducto = 0;
        private void Producto_Load(object sender, EventArgs e)
        {
            cargaUnidadMedida();
            cargarDatos();
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

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

            dtgProductos.ColumnCount = 9;
            dtgProductos.Columns[0].Name = "Codigo";
            dtgProductos.Columns[1].Name = "Descripcion";
            dtgProductos.Columns[2].Name = "Unidad Medida";
            dtgProductos.Columns[3].Name = "Stock Minimo";
            dtgProductos.Columns[4].Name = "Stock Optimo";
            dtgProductos.Columns[5].Name = "Consumo Mensual";
            dtgProductos.Columns[6].Name = "Consumo Trimestral";
            dtgProductos.Columns[7].Name = "Consumo Semestral";
            dtgProductos.Columns[8].Name = "id";
            dtgProductos.Columns[8].Visible = false;


            List <BE.Producto> productos = pr.GetProductos();
            foreach (BE.Producto lista in productos)
            {
                dtgProductos.Rows.Add(lista.codigo,lista.descripcion,lista.unidadMedida.nombre,lista.stockMinimo,lista.stockOptimo,lista.consumoMensual,lista.consumoTrimestral,lista.consumoSemestral, lista.id_Producto);
            }
        }

        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDescripcion.Text = dtgProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMinimo.Text = dtgProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtOptimo.Text = dtgProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
            idProducto = int.Parse(dtgProductos.Rows[e.RowIndex].Cells[8].Value.ToString());
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                
                BE.Producto producto = new BE.Producto();
                producto.id_Producto = idProducto;
                pr.bajaProducto(producto);
                MessageBox.Show("Producto dado de baja con exito");
                cargarDatos();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                BE.Producto producto = new BE.Producto();
                producto.id_Producto = idProducto;
                producto.codigo = txtCodigo.Text;
                producto.descripcion = txtDescripcion.Text;
                int idUM = cmbUM.SelectedValue != null ? int.Parse(cmbUM.SelectedValue.ToString()) : 0;
                unidadMedida = um.GetUnidadMedida(idUM);
                producto.unidadMedida = unidadMedida;
                producto.stockMinimo = txtMinimo.Text == "" ? 0 : float.Parse(txtMinimo.Text);
                producto.stockOptimo = txtOptimo.Text == "" ? 0 : float.Parse(txtOptimo.Text);
                pr.modificacionProducto(producto);
                MessageBox.Show("Se modifico el producto con exito");
                cargarDatos();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
