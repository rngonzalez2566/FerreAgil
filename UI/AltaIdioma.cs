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
    public partial class AltaIdioma : Form, IIdiomaObserver
    {
        public AltaIdioma()
        {
            InitializeComponent();
        }
        BLL.Idioma idioma = new BLL.Idioma();
        BE.Idioma idiom = new BE.Idioma();
        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
              

                idiom.Nombre = txtIdioma.Text;

                idioma.AltaIdioma(idiom);
                MessageBox.Show("Idioma dado de alta con exito");
                cargarIdiomas();
                txtIdioma.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cargarIdiomas()
        {
            dtgIdiomas.DataSource = null;
            dtgIdiomas.Columns.Clear();

            dtgIdiomas.ColumnCount = 2;
            dtgIdiomas.Columns[0].Name = "Nombre";
            dtgIdiomas.Columns[1].Name = "Default";

            IList<IIdioma> idiomas = idioma.ObtenerIdiomas();
            foreach (BE.Idioma lista in idiomas)
            {
                dtgIdiomas.Rows.Add(lista.Nombre, lista.Default);
            }
        }

        private void AltaIdioma_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            cargarIdiomas();
        }

     
       
        public void UpdateLanguage(IIdioma idioma1)
        {
            Services.Idioma.Traductor.Traducir(idioma, idioma1, this.Controls);
        }

        private void dtgIdiomas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
