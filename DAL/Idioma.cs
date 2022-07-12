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
        private const string alta_Idioma = "INSERT INTO IDIOMA (nombre,[Default]) " +
                                           " OUTPUT inserted.id_idioma VALUES (@nombre,0) ";
        private const string get_ValidaIdioma = "SELECT * FROM IDIOMA where nombre = @nombre";
        private const string get_EtiquetasIdioma = "Select e.nombre_etiqueta, t.traduccion from etiquetas e " +
                                                    "inner join Traducciones t on t.id_etiqueta = e.id_etiqueta " +
                                                    "where t.id_idioma = @idioma";
        private const string get_Etiquetas = "SELECT * FROM ETIQUETAS";
        private const string alta_Traduccion = "INSERT INTO TRADUCCIONES (id_idioma,traduccion, id_etiqueta) " +
                                           " OUTPUT inserted.id_traducciones VALUES (@idioma,@traduccion,@etiqueta) ";
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

        public List<Services.Idioma.Etiqueta> ObtenerEtiquetas()
        {
            try
            {

                List<Services.Idioma.Etiqueta> lista = new List<Services.Idioma.Etiqueta>();
                DataTable dt = new DataTable();
                xCommandText = get_Etiquetas;

                xParameters.Parameters.Clear();
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Services.Idioma.Etiqueta etiqueta = new Services.Idioma.Etiqueta()
                        {
                            id = int.Parse(fila[0].ToString()),
                            Nombre = fila[1].ToString()
                        };
                        lista.Add(etiqueta);
                    }
                }

                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Error en las traducciones");
            }
        }
        public BE.Idioma GetIdioma(string xNombre)
        {
            DataTable dt = new DataTable();
            BE.Idioma idioma = new BE.Idioma();

            try
            {
                xCommandText = get_ValidaIdioma;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@nombre", xNombre);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    idioma.id = int.Parse(dt.Rows[0]["id_idioma"].ToString());
                    idioma.Nombre = dt.Rows[0]["nombre"].ToString();

                }
                else
                {
                    idioma = null;
                }

                return idioma;
            }
            catch
            {
                throw new Exception("Se produjo un error con la base de datos");
            }
        }
            #endregion
            #region ABM
            public int AltaIdioma(BE.Idioma idioma)
             {
            try
            {
                xCommandText = alta_Idioma;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@nombre", idioma.Nombre);


                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AltaTraduccion(IIdioma idioma, Services.Idioma.Traduccion traduccion)
        {
            try
            {
                xCommandText = alta_Traduccion;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idioma", idioma.id);
                xParameters.Parameters.AddWithValue("@traduccion", traduccion.Texto);
                xParameters.Parameters.AddWithValue("@etiqueta", traduccion.Etiqueta.id);


                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        #endregion
    }
}
