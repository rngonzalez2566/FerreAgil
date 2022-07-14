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
    public partial class AnalisisCompra : Form, IIdiomaObserver
    {
        public AnalisisCompra()
        {
            InitializeComponent();
        }
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        BLL.Stock stock = new BLL.Stock();
        List<BE.Stock> lista = new List<BE.Stock>();
        private void AnalisisCompra_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            cargarDatos();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        public void cargarDatos()
        {
            lista = stock.GetAnalisisStock();
            dtgAnalisis.DataSource = null;
            dtgAnalisis.Rows.Clear();
            dtgAnalisis.ClearSelection();
            dtgAnalisis.TabStop = false;
            dtgAnalisis.ReadOnly = true;

            dtgAnalisis.ColumnCount = 6;
            dtgAnalisis.Columns[0].Name = "Codigo";
            dtgAnalisis.Columns[1].Name = "Descripcion";
            dtgAnalisis.Columns[2].Name = "Cantidad Stock";
            dtgAnalisis.Columns[3].Name = "Stock Minimo";
            dtgAnalisis.Columns[4].Name = "Stock Optimo";
            dtgAnalisis.Columns[5].Name = "Estado";

            int i = 0;
            foreach (BE.Stock lista in lista)
            {
                dtgAnalisis.Rows.Add(lista.Producto.codigo,lista.Producto.descripcion,lista.Cantidad,lista.Producto.stockMinimo,lista.Producto.stockOptimo,lista.Condicion);
                if (lista.Condicion == 0)
                {
                    dtgAnalisis.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                if (lista.Condicion == 1)
                {
                    dtgAnalisis.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                if (lista.Condicion == 2)
                {
                    dtgAnalisis.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }


                i = i + 1;
            }
        }
    }
}
