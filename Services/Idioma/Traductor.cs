using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;


namespace Services.Idioma
{
    public class Traductor 
    {
        public static void Traducir(ITraductor itraductor, IIdioma idioma, Control.ControlCollection controls)
        {
            IDictionary<string, ITraduccion> traducciones = itraductor.ObtenerTraducciones(idioma);

            foreach (Control ctrl in controls)
            {
                 
                if (ctrl.Tag != null && traducciones.ContainsKey(ctrl.Tag.ToString()))
                    ctrl.Text = traducciones[ctrl.Tag.ToString()].Texto;

                if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    ctrl.Text = "";
                }
            }
        }

        public static void TraducirMenu(ITraductor idiomaBLL, IIdioma idioma, MenuStrip menu)
        {
            IDictionary<string, ITraduccion> traducciones = idiomaBLL.ObtenerTraducciones(idioma);

            foreach (ToolStripMenuItem item in menu.Items)
            {
                if (item.Tag != null && traducciones.ContainsKey(item.Tag.ToString()))
                    item.Text = traducciones[item.Tag.ToString()].Texto;


                foreach (ToolStripMenuItem subItem in item.DropDownItems)
                {
                    if (subItem.Tag != null && traducciones.ContainsKey(subItem.Tag.ToString()))
                        subItem.Text = traducciones[subItem.Tag.ToString()].Texto;
                    else if (subItem.AccessibleDescription != null && subItem.AccessibleDescription.ToString() == "idioma_agregado" && !traducciones.ContainsKey(subItem.Tag.ToString()))
                        subItem.Text = $"{subItem.Text}";

                    foreach (ToolStripItem subSubItem in subItem.DropDownItems)
                    {
                        if (subSubItem.Tag != null && traducciones.ContainsKey(subSubItem.Tag.ToString()))
                            subSubItem.Text = traducciones[subSubItem.Tag.ToString()].Texto;
                    }
                }
            }
        }

    }
}
