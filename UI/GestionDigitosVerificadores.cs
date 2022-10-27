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
    public partial class GestionDigitosVerificadores : Form
    {
        public GestionDigitosVerificadores()
        {
            InitializeComponent();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            BLL.DigitoVerificadorBLL dv = new BLL.DigitoVerificadorBLL();
            try
            {
                DialogResult confirmar = MessageBox.Show("Esta Seguro que desea Recalcular Digitos?", "Recalcular Digitos", MessageBoxButtons.YesNo);

                if (confirmar.Equals(DialogResult.Yes))
                {
                    dv.RecalcularDigitos();
                    MessageBox.Show("Se recalcularon los digitos correctamente");
                    Login.xError = false;
                    SingletonSesion.Logout();
                    MdiParent.Close();
                    this.Close();
                    Login l = new Login();
                    l.Show();


                }  
            }
            catch
            {
                MessageBox.Show("Error al querer recalcular digitos verificadores");
            }
        }
    }
}
