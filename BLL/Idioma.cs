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
        public IList<IIdioma> ObtenerIdiomas()
        {
            try
            {
                IList<IIdioma> idiomas = idioma.ObtenerIdiomas();

                return idiomas;
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
    }
}
