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
        BLL.Compra compra = new BLL.Compra();
        List<BE.Detalle_Compra> listItem = new List<BE.Detalle_Compra>();
        bool xEntro = false;
        private void CompraMateriales_Load(object sender, EventArgs e)
        {
            
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            CargaProductos();
            CargaProveedores();
            txtNro.Text = compra.GetUltimoComprobante().ToString();
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
            dtgItems.DataSource = null;
            dtgItems.Rows.Clear();
            dtgItems.ClearSelection();
            dtgItems.TabStop = false;
            dtgItems.ReadOnly = true;

            dtgItems.ColumnCount = 5;
            dtgItems.Columns[0].Name = "Codigo";
            dtgItems.Columns[1].Name = "Descripcion";
            dtgItems.Columns[2].Name = "Cantidad";
            dtgItems.Columns[3].Name = "Precio Unitario";
            dtgItems.Columns[4].Name = "Total";

            foreach (BE.Detalle_Compra lista in list)
            {
                dtgItems.Rows.Add(lista.Producto.codigo,lista.Producto.descripcion,lista.Cantidad,lista.PrecioUnitario,lista.Total);
            }

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

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNro.Text == "") throw new Exception("Nro de Comprobante Vacio");
                if (cmbProveedor.Text == "") throw new Exception("Debe Completar un Proveedor");
                if (listItem.Count == 0) throw new Exception("Debe tener al menos un producto a comprar");
                int idProveedor = cmbProveedor.SelectedValue != null ? int.Parse(cmbProveedor.SelectedValue.ToString()) : 0;
                BE.Proveedor prov = proveedorBLL.GetProvedoor(idProveedor);
                if (prov == null) throw new Exception("Problema con el proveedor");
                BE.Compra comprobante = new BE.Compra()
                {
                    Fecha = DateTime.Parse(dateTimePicker1.Value.ToString("dd/MM/yyyy")),
                    Items = listItem,
                    Detalle = txtDetalle.Text,
                    Total = listItem.Sum(x => x.Total),
                    Proveedor = prov,
                    Estado = "Pendiente Envio Proveedor",
                    Nro = int.Parse(txtNro.Text)
                };
               
                compra.GenerarCompra(comprobante);
                MessageBox.Show("Compra Generada Correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtCantidad.Text == "") throw new Exception("Debe indicar la cantidad");
                bool xEntro = false;
                List<BE.Detalle_Compra> listItem1 = new List<BE.Detalle_Compra>(listItem);
 
                foreach (BE.Detalle_Compra lista in listItem1)
                {
                   
                    int idProducto = cmbProducto.SelectedValue != null ? int.Parse(cmbProducto.SelectedValue.ToString()) : 0;
                    BE.Producto pr = new BE.Producto();
                    pr = productoBLL.GetProducto(idProducto);
                    
                        if (lista.Producto.id_Producto == pr.id_Producto)
                        {
                            xEntro = true;
                            throw new Exception("El producto ya existe en la lista de items");
                        }

                }
                if (xEntro == false)
                {
                    int idProducto = cmbProducto.SelectedValue != null ? int.Parse(cmbProducto.SelectedValue.ToString()) : 0;
                    BE.Producto pr = new BE.Producto();
                    pr = productoBLL.GetProducto(idProducto);
                    BE.Detalle_Compra itemCompra = new BE.Detalle_Compra()
                    {
                        Producto = pr,
                        Cantidad = float.Parse(txtCantidad.Text),
                        PrecioUnitario = pr.PrecioUnitario,
                        Total = pr.PrecioUnitario * float.Parse(txtCantidad.Text)
                    };
                    listItem.Add(itemCompra);
                    cargarItems(listItem);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
