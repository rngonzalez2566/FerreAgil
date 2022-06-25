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
    public partial class Principal : Form, IIdiomaObserver
    {
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        public Principal()
        {
            InitializeComponent();
            

        }
        
        private void Principal_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            obtenerIdiomas();
           
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);
            Services.Idioma.Traductor.TraducirMenu(idiomaBLL, idioma, menuStrip1);
           
        }

        private void obtenerIdiomas()
        {
            IList<IIdioma> idiomas = idiomaBLL.ObtenerIdiomas();
            foreach (IIdioma idioma in idiomas)
            {

                ToolStripMenuItem idiomaMenu = new ToolStripMenuItem();
                idiomaMenu.Text = idioma.Nombre;
                idiomaMenu.Tag = idioma;
                this.menuIdioma.DropDownItems.Add(idiomaMenu);

                idiomaMenu.Click += _Click;
            }
        }

        private void _Click(object sender, EventArgs e)
        {
            SingletonSesion.CambiarIdioma(((IIdioma)((ToolStripMenuItem)sender).Tag));
        }
        public void ValidarForm()
        {

            Encriptar encriptar = new Encriptar();
            if (SingletonSesion.IsLogged())
                this.toolStripSesion.Text = encriptar.descencriptar(SingletonSesion.GetUsuario().usuario);
            else
                this.toolStripSesion.Text = "[Sesión no iniciada]";

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro?", "Confirme", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BLL.Usuario usu = new BLL.Usuario();
                usu.Logout();
                ValidarForm();
                this.Close();
                Login l = new Login();
                l.Show();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Producto frm = new Producto();
            frm.Show();
        }
    }
}
