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
    public partial class CompraMateriales : Form, IIdiomaObserver
    {
        public CompraMateriales()
        {
            InitializeComponent();
        }
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        BLL.Producto productoBLL = new BLL.Producto();
        BLL.Proveedor proveedorBLL = new BLL.Proveedor();
        BLL.Stock stock = new BLL.Stock();
        List<BE.Detalle_Compra> listItem = new List<BE.Detalle_Compra>();
        bool xEntro = false;
        private void CompraMateriales_Load(object sender, EventArgs e)
        {
            
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            CargaProductos();
            CargaProveedores();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        public void CargaProductos()
        {
            try { 
            cmbProducto.DataSource = productoBLL.GetProductos();
            cmbProducto.ValueMember = "id_producto";
            cmbProducto.DisplayMember = "Descripcion";
            cmbProducto.SelectedIndex = -1;
            }
        catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        public void CargaProveedores()
        {
            try
            {
                cmbProveedor.DataSource = proveedorBLL.GetProvedoores();
                cmbProveedor.ValueMember = "id_proveedor";
                cmbProveedor.DisplayMember = "razonSocial";
                cmbProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<BE.Stock> listaPP =  stock.GetPuntoPedido();
                foreach(BE.Stock st in listaPP)
                {
                    xEntro = false;
                    if(listItem.Count > 0)
                    {
                        foreach (var item in listItem)
                        {
                            if (item.Producto.id_Producto == st.Producto.id_Producto)
                            {
                                xEntro=true;
                            }
                        }
                        if (xEntro == false)
                        {
                            BE.Detalle_Compra itemCompra = new BE.Detalle_Compra()
                            {
                                Producto = st.Producto,
                                Cantidad = st.Cantidad,
                                PrecioUnitario = st.Producto.PrecioUnitario,
                                Total = st.Producto.PrecioUnitario * st.Cantidad
                            };
                            listItem.Add(itemCompra);
                        }
                    }
                    else
                    {
                        BE.Detalle_Compra itemCompra = new BE.Detalle_Compra()
                        {
                            Producto = st.Producto,
                            Cantidad = st.Cantidad,
                            PrecioUnitario = st.Producto.PrecioUnitario,
                            Total = st.Producto.PrecioUnitario * st.Cantidad
                        };
                        listItem.Add(itemCompra);
                    }
                    
                }

                cargarItems(listItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void cargarItems(List<BE.Detalle_Compra> list)
        {
            dtgItems.DataSource = list;
            dtgItems.ClearSelection();
            dtgItems.TabStop = false;
            dtgItems.ReadOnly = true;

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            if (listItem.Count > 0)
            {
                double total = listItem.Sum(x => x.Total);
                txtTotal.Text = total.ToString();
            }
           
        }
    }
}
