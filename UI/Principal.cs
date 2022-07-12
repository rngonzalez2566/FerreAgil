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
        BLL.Permiso permiso = new BLL.Permiso();
        private bool mdiChildActivo = false;
        public Principal()
        {
            InitializeComponent();
            

        }
        
        private void Principal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            obtenerIdiomas();
            VerificarPermisosMenu();

        }

        private void VerificarPermisosMenu()
        {
          

            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Alta_Usuario") == false) altaUsuarioToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Baja_Usuario") == false) bajaUsuarioToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Desbloquear_Usuario") == false) desbloquearUsuarioToolStripMenuItem1.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Cambio_Password") == false) cambioDePasswordToolStripMenuItem1.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Crear_Familia_Patentes") == false) altaPermisosStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Asignar_Familia_Patentes") == false) asignacionFamiliaPatenteToolStripMenuItem1.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Asignar_Permisos_Usuarios") == false) asignacionPermisosUsuariosToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Desasignar_Permisos") == false) desasignarPermisosToolStripMenuItem1.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Abm_Producto") == false) productosToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Abm_Proveedor") == false) proveedorToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Gestion_Compras") == false) compraToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Gestion_Ventas") == false) ventaToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Alta_Idioma") == false) altaIdiomaToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Alta_Etiquetas") == false) altaEtiquetasToolStripMenuItem.Enabled = false;



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
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }


        private void altaPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AltaFamiliaPatente frm = new AltaFamiliaPatente();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void asignacionPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AsignacionPermisoUsuario frm = new AsignacionPermisoUsuario();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void desasignarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void asignacionFamiliaPatenteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AsignacionFamiliaPatente frm = new AsignacionFamiliaPatente();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AltaFamiliaPatente frm = new AltaFamiliaPatente();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void altaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AltaUsuario frm = new AltaUsuario();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void bajaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cambioDePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void desbloquearUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void asignacionFamiliaPatenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            AsignacionFamiliaPatente frm = new AsignacionFamiliaPatente();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void asignacionPermisosUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AsignacionPermisoUsuario frm = new AsignacionPermisoUsuario();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void desasignarPermisosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void altaIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
  
            AltaIdioma frm = new AltaIdioma();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void Principal_MdiChildActivate(object sender, EventArgs e)
        {
            Form formEvento = (Form)sender;
            if (formEvento.ActiveMdiChild == null)
            {
                mdiChildActivo = false;
                UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
                menuIdioma.DropDownItems.Clear();
                obtenerIdiomas();
            }
            else
            {
                mdiChildActivo = true;
            }
        }

        private void altaEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AltaEtiqueta frm = new AltaEtiqueta();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}
