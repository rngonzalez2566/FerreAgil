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
    public partial class RecepcionMateriales : Form, IIdiomaObserver
    {
        public RecepcionMateriales()
        {
            InitializeComponent();
        }
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        BLL.Compra compra = new BLL.Compra();
        BLL.Detalle_Compra detalleDAL = new BLL.Detalle_Compra();
        string pendiente = "Enviado Proveedor";
        string estado = "Pedido Recepcionado";
        private void RecepcionMateriales_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            CargarPendientes(compra.GetPendientes(pendiente));
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        public void CargarPendientes(List<BE.Compra> listaCompra)
        {
            dtgCompras.DataSource = null;
            dtgCompras.Rows.Clear();
            dtgCompras.ClearSelection();
            dtgCompras.TabStop = false;
            dtgCompras.ReadOnly = true;

            dtgCompras.ColumnCount = 6;
            dtgCompras.Columns[0].Name = "id";
            dtgCompras.Columns[0].Visible = false;
            dtgCompras.Columns[1].Name = "Nro";
            dtgCompras.Columns[2].Name = "Fecha";
            dtgCompras.Columns[3].Name = "Detalle";
            dtgCompras.Columns[4].Name = "Total";
            dtgCompras.Columns[5].Name = "Proveedor";

            foreach (BE.Compra lista in listaCompra)
            {
                dtgCompras.Rows.Add(lista.id, lista.Nro, lista.Fecha, lista.Detalle, lista.Total, lista.Proveedor.razonSocial);
            }

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                int xNro = txtID.Text == "" ? 0 : int.Parse(txtID.Text);
                if (xNro == 0) throw new Exception("Nro de Comprobante no seleccionado");
                List<BE.Detalle_Compra> listaItem = detalleDAL.GetDetalleCompra(xNro);
                CargarItems(listaItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void CargarItems(List<BE.Detalle_Compra> listaItem)
        {
            dtgItems.DataSource = null;
            dtgItems.Rows.Clear();
            dtgItems.ClearSelection();
            dtgItems.TabStop = false;
            dtgItems.ReadOnly = true;

            dtgItems.ColumnCount = 7;
            dtgItems.Columns[0].Name = "id";
            dtgItems.Columns[1].Name = "Codigo";
            dtgItems.Columns[2].Name = "Descripcion";
            dtgItems.Columns[3].Name = "Cantidad";
            dtgItems.Columns[4].Name = "Precio Unitario";
            dtgItems.Columns[5].Name = "Total";
            dtgItems.Columns[6].Name = "Cantidad Recepcionada";

            foreach (BE.Detalle_Compra lista in listaItem)
            {
                dtgItems.Rows.Add(lista.id,lista.Producto.codigo,lista.Producto.descripcion,lista.Cantidad,lista.PrecioUnitario,lista.Total,lista.CantidadRecepcionada);
            }

        }

        private void dtgCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtID.Text = dtgCompras.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNro.Text = dtgCompras.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dtgItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCantidad.Text = dtgItems.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtItem.Text = dtgItems.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                int xNro = txtID.Text == "" ? 0 : int.Parse(txtID.Text);
                int idDetalle = txtItem.Text == "" ? 0 : int.Parse(txtItem.Text);
                float cantidad = txtCantidad.Text == "" ? 0 : int.Parse(txtCantidad.Text);
                if (idDetalle == 0) throw new Exception("Item no seleccionado");
                if (xNro == 0) throw new Exception("Nro de Comprobante no seleccionado");
                detalleDAL.ModificaCantidadRecepcionada(idDetalle, cantidad);

                List<BE.Detalle_Compra> listaItem = detalleDAL.GetDetalleCompra(xNro);
                CargarItems(listaItem);
                txtItem.Text = "";
                txtCantidad.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                int xNro = txtNro.Text == "" ? 0 : int.Parse(txtNro.Text);
                if (xNro == 0) throw new Exception("Nro de Comprobante Vacio");
                compra.CambioEstado(xNro, estado);
                CargarPendientes(compra.GetPendientes(pendiente));
                txtID.Text = 0.ToString();
                txtNro.Text = 0.ToString();
                dtgItems.DataSource = null;
                dtgItems.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
