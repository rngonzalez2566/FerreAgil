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
    public partial class Bitacora : Form, IIdiomaObserver
    {
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        public Bitacora()
        {
            InitializeComponent();
        }

        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }
        private void btnAltaFamilia_Click(object sender, EventArgs e)
        {
            try
            {

            
            BLL.Bitacora bit = new BLL.Bitacora();
            Encriptar encriptar = new Encriptar();

            string fltUsuario = " 1 = 1 ";
            string fltFechaD = " AND 1 = 1 ";
            string fltFechaH = " AND 1 = 1 ";
            string fltCriticidad = " AND 1 = 1 ";


            if (ftUsuario.Checked == false && ftfecha.Checked == false && ftCriticidad.Checked == false)
            {
                    MessageBox.Show("No selecciono ningun filtro de busqueda");
                    return;
            }

            if (ftUsuario.Checked == true && cmbUsuario.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un usuario");
                return;
            }

            if (ftCriticidad.Checked == true && cmbCriticidad.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una criticidad");
                return;
            }

            if (ftfecha.Checked == true)
            {
              

                if (dpd.Value > dph.Value)
                {
                    MessageBox.Show("La fecha desde no puede ser mayor a la fecha Hasta");
                    return;
                }

            }

            if (ftCriticidad.Checked == true)
            {
                fltCriticidad = " and b.criticidad = '" + cmbCriticidad.Text + "' ";
            }

            if (ftUsuario.Checked == true)
            {
                fltUsuario = "U.usuario = '" + cmbUsuario.Text + "' ";
            }

            if (ftfecha.Checked == true)
            {
                fltFechaD = "and b.Fecha >= '" + dpd.Value + "'  ";
                fltFechaH = "and b.Fecha <= '" + dph.Value + "'  ";
            }

            dtgBitacora.DataSource = null;
            dtgBitacora.Rows.Clear();
            dtgBitacora.ClearSelection();
            dtgBitacora.TabStop = false;
            dtgBitacora.ReadOnly = true;

            dtgBitacora.ColumnCount = 4;
            dtgBitacora.Columns[0].Name = "Fecha";
            dtgBitacora.Columns[1].Name = "Usuario";
            dtgBitacora.Columns[2].Name = "Descripcion";
            dtgBitacora.Columns[3].Name = "Criticidad";


            List<BE.Bitacora> bitacora = bit.Busqueda(fltUsuario, fltFechaD, fltFechaH, fltCriticidad);
            foreach (BE.Bitacora lista in bitacora)
            {
                dtgBitacora.Rows.Add(lista.Fecha, encriptar.descencriptar(lista.Usuario.usuario), lista.Descripcion,lista.Criticidad);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
        }
    }
}
