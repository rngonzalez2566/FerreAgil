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
    public partial class AsignacionPermisoUsuario : Form, IIdiomaObserver
    {
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        BLL.Permiso permiso = new BLL.Permiso();
        BLL.Usuario usuario = new BLL.Usuario();
        
        BE.Usuario _usu;
        BE.Usuario _user;
        public AsignacionPermisoUsuario()
        {
            InitializeComponent();
        }

        private void AsignacionPermisoUsuario_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            cmbPatentes.DataSource = permiso.GetPatentes();
            cmbFamilias.DataSource = permiso.GetFamilias();
            cmbUsuario.DataSource = usuario.GetUsuarios();
            cmbUsuario.ValueMember = "id_usuario";
            cmbUsuario.DisplayMember = "usuario";
            cmbUsuario.SelectedIndex = -1;
        }
        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _usu = (BE.Usuario)cmbUsuario.SelectedItem;
            _user = new BE.Usuario();
            _user.id_usuario = _usu.id_usuario;
            _user.usuario = _usu.usuario;
            permiso.GetUsuarioPermiso(_user);
            MostrarPermisosUsuario(_user);

        }

        private void MostrarPermisosUsuario(BE.Usuario user)
        {
            treePermisoUsuario.Nodes.Clear();
            TreeNode root = new TreeNode(user.usuario);
            foreach (var item in user.Permisos)
            {
                MostrarTreeUsuario(root, item);
            }
            treePermisoUsuario.Nodes.Add(root);
            treePermisoUsuario.ExpandAll();
        }

        private void MostrarTreeUsuario(TreeNode padre, Componente comp)
        {
            TreeNode hijo = new TreeNode(comp.nombre);
            hijo.Tag = comp;
            padre.Nodes.Add(hijo);
            foreach (var item in comp.Hijos)
            {
                MostrarTreeUsuario(hijo, item);
            }
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            bool tieneFamilia = false;
            if (_user != null)
            {
                var familia = (Familia)cmbFamilias.SelectedItem;
                if (familia != null)
                {
                    foreach (var item in _user.Permisos)
                    {
                        if (permiso.existeComponente(item, familia.id)) tieneFamilia = true;
                    }
                }

                if (tieneFamilia)
                {
                    string Mensaje = "La familia ya se encuentra asignada";
                    MessageBox.Show(Mensaje);
                }
                else
                {
                    permiso.LlenarComponenteFamilia(familia);
                    _user.Permisos.Add(familia);
                    MostrarPermisosUsuario(_user);
                }
            }
            else
            {
                string Mensaje = "No selecciono el usuario";
                MessageBox.Show(Mensaje);
            }
        }

        private void btnAgregarPatente_Click(object sender, EventArgs e)
        {
            if (_user != null)
            {
                var patente = (Patente)cmbPatentes.SelectedItem;
                if (patente != null)
                {
                    bool tienePatente = false;
                    foreach (var item in _user.Permisos)
                    {
                        if (permiso.existeComponente(item, patente.id))
                        {
                            tienePatente = true;
                            break;
                        }
                    }
                    if (tienePatente)
                    {
                        string Mensaje = "La patente ya se encuentra asignada";
                        MessageBox.Show(Mensaje);
                    }
                    else
                    {
                        _user.Permisos.Add(patente);
                        MostrarPermisosUsuario(_user);
                    }
                }
            }
        }

        private void btnAltaFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                permiso.GuardarPermisoUsuario(_user);
                string Mensaje = "Permisos Guardados";
                MessageBox.Show(Mensaje);
                treePermisoUsuario.Nodes.Clear();
            }
            catch
            {
                string Mensaje = "Error al guardar Permisos";
                MessageBox.Show(Mensaje);
            }
        }
    }
}
