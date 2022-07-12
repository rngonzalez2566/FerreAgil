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
    public partial class AltaEtiqueta : Form, IIdiomaObserver
    {
        public AltaEtiqueta()
        {
            InitializeComponent();
        }
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        IDictionary<string, ITraduccion> traducciones;
        IIdioma idioma;
        private void AltaEtiqueta_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            cargarIdiomas();
            cargarEtiquetas();

        }

        public void cargarIdiomas()
        {
            IList<IIdioma> idiomas = idiomaBLL.ObtenerIdiomas();
            
            cmbIdioma.DataSource = idiomas;
            cmbIdioma.ValueMember = "id";
            cmbIdioma.DisplayMember = "Nombre";
            cmbIdioma.SelectedIndex = -1;


        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
            
        {
            if(cmbIdioma.SelectedIndex != -1)
            {
                idioma = idiomaBLL.ObtenerIdiomas().Where(i => i.Nombre == cmbIdioma.Text).FirstOrDefault();
                if (idioma != null) cargarTraducciones(idioma);
            }
                   
            
        }

        public void cargarTraducciones(IIdioma idioma)
        {
            if (idioma != null)
            {

            
            traducciones = idiomaBLL.ObtenerTraducciones(idioma);
            dtgTraducciones.DataSource = null;
            dtgTraducciones.Columns.Clear();


            dtgTraducciones.ColumnCount = 2;
            dtgTraducciones.Columns[0].Name = "Etiqueta";
            dtgTraducciones.Columns[1].Name = "Traduccion";

            foreach (var lista in traducciones)
            {
                dtgTraducciones.Rows.Add(lista.Value.Etiqueta.Nombre.ToString(), lista.Value.Texto.ToString());

            }
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEtiquetas.SelectedValue == null) throw new Exception("Debe elegir una etiqueta");
                if (string.IsNullOrWhiteSpace(txtTraduccion.Text)) throw new Exception("Se debe completar la traducción");

                foreach (var item in traducciones)
                {
                    if (item.Value.Etiqueta.Nombre.ToString() == cmbEtiquetas.Text)
                    {
                        throw new Exception("Esa traducción ya está cargada.");
                    }
                }

     
                Services.Idioma.Etiqueta etiqueta = idiomaBLL.ObtenerEtiquetas().Where(x => x.id == (int)cmbEtiquetas.SelectedValue).FirstOrDefault();

                Services.Idioma.Traduccion traduccion = new Services.Idioma.Traduccion();
                traduccion.Etiqueta = etiqueta;
                traduccion.Texto = txtTraduccion.Text;

                idiomaBLL.AltaTraduccion(idioma, traduccion);
                if (idioma != null) cargarTraducciones(idioma);
                txtTraduccion.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cargarEtiquetas()
        {
            cmbEtiquetas.DataSource = idiomaBLL.ObtenerEtiquetas();
            cmbEtiquetas.ValueMember = "Id";
            cmbEtiquetas.DisplayMember = "Nombre";
            cmbEtiquetas.SelectedIndex = -1;
        }
    }
}
