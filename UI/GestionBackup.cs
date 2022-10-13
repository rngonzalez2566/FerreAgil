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
    public partial class GestionBackup : Form, IIdiomaObserver
    {
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        Encriptar encriptar = new Encriptar();
        public GestionBackup()
        {
            InitializeComponent();
        }

        BLL.Backup backup = new BLL.Backup();

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        private void GestionBackup_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            cargarDatos();

        }

        public void cargarDatos()
        {
            dtgBackups.DataSource = null;
            dtgBackups.Columns.Clear();

            dtgBackups.ColumnCount = 5;
            dtgBackups.Columns[0].Name = "Nombre";
            dtgBackups.Columns[1].Name = "Ruta";
            dtgBackups.Columns[2].Name = "Fecha";
            dtgBackups.Columns[3].Name = "Usuario";
            dtgBackups.Columns[4].Name = "id";
            dtgBackups.Columns[4].Visible = false;


            List<BE.Backup> backups = backup.GetBackups();
            foreach (BE.Backup lista in backups)
            {
                dtgBackups.Rows.Add(lista.Nombre, lista.Ruta, lista.Fecha, encriptar.descencriptar(lista.Usuario.usuario), lista.Id_Backup);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmar = MessageBox.Show("Esta Seguro que desea realizar un Backup?","Generar Backup", MessageBoxButtons.YesNo);

                if (confirmar.Equals(DialogResult.Yes))
                {
                    backup.GenerarBackup();
                    MessageBox.Show("Se realizo el Backup Correctamente");
                    cargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgBackups.CurrentRow == null) throw new Exception("No selecciono un Backup para realizar Restore");

                BE.Backup back = backup.GetBackup((int)dtgBackups.CurrentRow.Cells["id"].Value);

                DialogResult confirmar = MessageBox.Show("Esta seguro que desea realizar un Restore?","Restore", MessageBoxButtons.YesNo);
                if (confirmar.Equals(DialogResult.Yes))
                {
                    backup.GenerarRestore(back);
                    MessageBox.Show("Se realizo un Restore Correctamente");
                    MdiParent.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
