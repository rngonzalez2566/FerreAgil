﻿using System;
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
        public static bool xError = false;
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
                frm.ValidarForm();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                txtPassword.Clear();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            BLL.Conexion conex = new BLL.Conexion();
            try
            {
                conex.conectar();
                BLL.DigitoVerificadorBLL dv = new BLL.DigitoVerificadorBLL();
                List<string> xMensaje = dv.VerificarDV();
                if (xMensaje.Count > 0)
                {
                    MessageBox.Show("Error en la integridad de la base de datos");
                    xError = true;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("PROBLEMAS CON LA BASE DE DATOS, CONTACTESE CON EL ADMINISTRADOR");
                Application.Exit();
            }
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Producto frm = new Producto();
            frm.Show();
        }
    }
}
