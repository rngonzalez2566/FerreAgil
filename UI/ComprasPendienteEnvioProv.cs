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
    public partial class ComprasPendienteEnvioProv : Form, IIdiomaObserver
    {
        public ComprasPendienteEnvioProv()
        {
            InitializeComponent();
        }
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        BLL.Compra compra  = new BLL.Compra();
        private void ComprasPendienteEnvioProv_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            CargarPendientes(compra.GetPendienteEnvioProveedor());
        }
        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        public void CargarPendientes(List<BE.Compra>listaCompra)
        {
            dtgPendientes.DataSource = null;
            dtgPendientes.Rows.Clear();
            dtgPendientes.ClearSelection();
            dtgPendientes.TabStop = false;
            dtgPendientes.ReadOnly = true;

            dtgPendientes.ColumnCount = 6;
            dtgPendientes.Columns[0].Name = "id";
            dtgPendientes.Columns[0].Visible = false;
            dtgPendientes.Columns[1].Name = "Nro";
            dtgPendientes.Columns[2].Name = "Fecha";
            dtgPendientes.Columns[3].Name = "Detalle";
            dtgPendientes.Columns[4].Name = "Total";
            dtgPendientes.Columns[4].Name = "Proveedor";

            foreach (BE.Compra lista in listaCompra)
            {
                dtgPendientes.Rows.Add(lista.id,lista.Nro,lista.Fecha,lista.Detalle,lista.Total,lista.Proveedor.razonSocial);
            }

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                int xNro = txtNro.Text == "" ? 0 : int.Parse(txtNro.Text);
                if (xNro == 0) throw new Exception("Nro de Comprobante Vacio");
                compra.EnvioProveedor(xNro);
                CargarPendientes(compra.GetPendienteEnvioProveedor());
                txtNro.Text = 0.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void dtgPendientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtNro.Text = dtgPendientes.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
