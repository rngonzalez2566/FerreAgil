﻿using Interfaces;
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
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Compra_Materiales") == false) compraDeMaterialesToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Pendiente_Envio_Prov") == false) pendientesEnvioProveedorToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Recepcion_Materiales") == false) pendientesEnvioProveedorToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Pendiente_Envio_Almacen") == false) pendientesEnvioAlmacenToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Recepcion_Almacen") == false) recepcionAlmacenToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Analisis_Stock") == false) analisisStockProductosToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Gestion_Backup") == false) gestionDeBackupsToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Bitacora") == false) bitacoraToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Recalcular_digitos") == false) gestionDigitosVerificadorsToolStripMenuItem.Enabled = false;
            if (permiso.VerificarPermiso(SingletonSesion.GetUsuario(), "Control_Cambios") == false) controlDeCambiosToolStripMenuItem.Enabled = false;
            
            if (Login.xError)
            {
                altaUsuarioToolStripMenuItem.Enabled = false;
                bajaUsuarioToolStripMenuItem.Enabled = false;
                desbloquearUsuarioToolStripMenuItem1.Enabled = false;
                cambioDePasswordToolStripMenuItem1.Enabled = false;
                altaPermisosStripMenuItem.Enabled = false;
                asignacionFamiliaPatenteToolStripMenuItem1.Enabled = false;
                asignacionPermisosUsuariosToolStripMenuItem.Enabled = false;
                desasignarPermisosToolStripMenuItem1.Enabled = false;
                productosToolStripMenuItem.Enabled = false;
                proveedorToolStripMenuItem.Enabled = false;
                compraToolStripMenuItem.Enabled = false;
                ventaToolStripMenuItem.Enabled = false;
                altaIdiomaToolStripMenuItem.Enabled = false;
                altaEtiquetasToolStripMenuItem.Enabled = false;
                compraDeMaterialesToolStripMenuItem.Enabled = false;
                pendientesEnvioProveedorToolStripMenuItem.Enabled = false;
                pendientesEnvioProveedorToolStripMenuItem.Enabled = false;
                pendientesEnvioAlmacenToolStripMenuItem.Enabled = false;
                recepcionAlmacenToolStripMenuItem.Enabled = false;
                analisisStockProductosToolStripMenuItem.Enabled = false;
                controlDeCambiosToolStripMenuItem.Enabled = false;

            }
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

                UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
                menuIdioma.DropDownItems.Clear();
                obtenerIdiomas();
            }

        }

        private void altaEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AltaEtiqueta frm = new AltaEtiqueta();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void compraDeMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompraMateriales frm = new CompraMateriales();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void pendientesEnvioProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComprasPendienteEnvioProv frm = new ComprasPendienteEnvioProv();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void recepcionarMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecepcionMateriales frm = new RecepcionMateriales();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void pendientesEnvioAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompraPendienteEnvioAlmacen frm = new CompraPendienteEnvioAlmacen();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void recepcionAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecepcionAlmacen frm = new RecepcionAlmacen();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void analisisStockProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalisisCompra frm = new AnalisisCompra();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void gestionDigitosVerificadorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionDigitosVerificadores frm = new GestionDigitosVerificadores();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void gestionDeBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionBackup frm = new GestionBackup();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitacora frm = new Bitacora();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void controlDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
