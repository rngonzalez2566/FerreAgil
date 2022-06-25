using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAL
{
    public class Idioma : Acceso, ITraductor
    {
        #region Consultas
        private const string get_Idioma = "SELECT * FROM IDIOMA";
        private const string get_Traducciones = "SELECT t.id_idioma, t.Traduccion , e.id_etiqueta , e.nombre_etiqueta FROM Traducciones t " +
                                                "INNER JOIN etiquetas e on e.id_etiqueta = t.id_etiqueta where t.id_idioma = @id_idioma";
        #endregion
        #region Gets
        public IList<IIdioma> ObtenerIdiomas()

        {
            try
            {
                xCommandText = get_Idioma;
                DataTable dt = new DataTable();

                IList<IIdioma> _idiomas = new List<IIdioma>();
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        IIdioma idioma    = new BE.Idioma();
                        idioma.id = int.Parse(fila[0].ToString());
                        idioma.Nombre = fila[1].ToString();
                        idioma.Default = bool.Parse(fila[2].ToString());
                        _idiomas.Add(idioma);
                    }
                }

                return _idiomas;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public IIdioma ObtenerIdiomaDefault()
        {
            return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
        {
            try
            {
             
                if (idioma == null) idioma = ObtenerIdiomaDefault();

                IDictionary<string, ITraduccion> _traducciones = new Dictionary<string, ITraduccion>(); // Traigo las traducciones del idioma seleccionado.
               
                DataTable dt = new DataTable();

                xCommandText = get_Traducciones;
                
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@id_idioma", idioma.id);
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        ITraduccion traduccion = new Services.Idioma.Traduccion();
                        traduccion.Texto = fila[1].ToString();
                        Services.Idioma.Etiqueta etiqueta = new Services.Idioma.Etiqueta()
                        {
                            id = int.Parse(fila[2].ToString()),
                            Nombre = fila[3].ToString()
                        };
                        traduccion.Etiqueta = etiqueta;

                        _traducciones.Add(traduccion.Etiqueta.Nombre, traduccion);
                    }
                }

                return _traducciones;
            }
            catch (Exception)
            {
                throw new Exception("Error en las traducciones");
            }
        }
        #endregion
    }
}
