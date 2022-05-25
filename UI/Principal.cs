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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

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
    }
}
