using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Idioma : ITraductor
    {
        DAL.Idioma idioma = new DAL.Idioma();
        #region Gets
        public IList<IIdioma> ObtenerIdiomas()
        {
            try
            {
                IList<IIdioma> idiomas = idioma.ObtenerIdiomas();

                return idiomas;
            }
            catch (Exception) { throw new Exception("Error al obtener los idiomas."); }
        }

        public List<Services.Idioma.Etiqueta> ObtenerEtiquetas()
        {
            try
            {

                return idioma.ObtenerEtiquetas();
            }
            catch (Exception) { throw new Exception("Error al obtener los idiomas."); }
        }

        public IIdioma ObtenerIdiomaDefault()
        {
            return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma _idioma)
        {
            try
            {
                IDictionary<string, ITraduccion> traducciones = idioma.ObtenerTraducciones(_idioma);

                return traducciones;
            }
            catch (Exception) { throw new Exception("Error al obtener las traducciones."); }
        }
        #endregion

        #region ABM
        public int AltaIdioma(BE.Idioma idiom)
        {


            try
            {
                if (idiom.Nombre == "") throw new Exception("Nombre del idioma en blanco");
                if (idioma.GetIdioma(idiom.Nombre) != null) throw new Exception("El Idioma ya se encuentra Registrado");
                return idioma.AltaIdioma(idiom);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int AltaTraduccion(IIdioma idiom, Services.Idioma.Traduccion traduccion)
        {
            try
            {
                return idioma.AltaTraduccion(idiom,traduccion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
