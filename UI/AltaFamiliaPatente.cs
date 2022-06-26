using BE.Composite;
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
    public partial class AltaFamiliaPatente : Form, IIdiomaObserver
    {
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        BLL.Permiso permiso = new BLL.Permiso();
    
        public AltaFamiliaPatente()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAltaPatente_Click(object sender, EventArgs e)
        {
          
            try
            {
                Patente patente = new Patente();
                {
                    patente.nombre = txtPatente.Text;
                   
                    patente.Permiso = cmbPermisos.SelectedItem != null ? (TipoPermiso)this.cmbPermisos.SelectedItem : 0;
                }
                permiso.AltaPermiso(patente, false);
                MessageBox.Show("Patente dada de Alta con exito");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
         }

        private void AltaFamiliaPatente_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            cmbPermisos.DataSource = permiso.GetTipoPermiso();
         
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        private void btnAltaFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                Familia familia = new Familia();
                {
                    familia.nombre = txtFamilia.Text;
                }
                permiso.AltaPermiso(familia, true);
                MessageBox.Show("Familia dada de Alta con exito");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void limpiar()
        {
            txtFamilia.Text = "";
            txtPatente.Text = "";
            cmbPermisos.SelectedIndex = -1;

        }
    }
}
