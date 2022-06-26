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
    public partial class AltaUsuario : Form, IIdiomaObserver
    {
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        BE.Usuario usuario = new BE.Usuario();
        BLL.Usuario us = new BLL.Usuario();
        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {

                

                usuario.usuario = txtUsuario.Text;
                usuario.email = txtMail.Text;

                us.AltaUsuario(usuario);
                MessageBox.Show("Usuario dado de alta con exito");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void limpiar()
        {
            txtUsuario.Text = "";
            txtMail.Text = "";
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);
        }
    }
}
