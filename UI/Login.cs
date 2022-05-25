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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLL.Usuario usu = new BLL.Usuario();

            try
            {
                BE.Usuario usuario = usu.Login(this.txtUsuario.Text, this.txtPassword.Text);
                Principal frm = new Principal();
                this.Hide();
                frm.Show();
                //frm.ValidarForm();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                txtPassword.Clear();
            }
        }
    }
}
