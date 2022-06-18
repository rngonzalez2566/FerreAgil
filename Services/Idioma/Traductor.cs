using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAL;

namespace Services.Idioma
{
    public class Traductor : Acceso
    {
        //public static IIdioma ObtenerIdiomaDefault()
        //{
        //    return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
        //}

        //public  IList<IIdioma> ObtenerIdiomas() // Traigo la lista de todos los idiomas que están cargados en el sistema.
        //{
            //IList<IIdioma> _idiomas = new List<IIdioma>();

            ////DAL.Acceso Acceso = new DAL.Acceso();
            //DataTable dt = new DataTable();

            //string xConsulta = "SELECT * FROM Idioma";

            //try
            //{
            //    xCommandText = xConsulta;
            //    xParameters.Parameters.Clear();
            //    dt = ExecuteReader();


            //    if (dt.Rows.Count > 0)
            //    {
            //        Usuario.id_usuario = int.Parse(dt.Rows[0]["id_usuario"].ToString());
            //        Usuario.usuario = dt.Rows[0]["usuario"].ToString();
            //        Usuario.contador = int.Parse(dt.Rows[0]["contador"].ToString());
            //        Usuario.estado = dt.Rows[0]["estado"].ToString();
            //        Usuario.email = dt.Rows[0]["email"].ToString();
            //        Usuario.contrasena = dt.Rows[0]["contrasena"].ToString();
            //        //Usuario.DVH = int.Parse(dt.Rows[0]["DVH"].ToString());
            //    }

            //    return Usuario;
            //}
            //catch
            //{
            //    throw new Exception("Se produjo un error con la base de datos");
            //}
            //dt = Acceso.GenerarConsulta(xConsulta);

        //    foreach (DataRow fila in dt.Rows)
        //    {
        //        _idiomas.Add(
        //           new Idioma()
        //           {
        //               id = int.Parse(fila[0].ToString()),
        //               Nombre = fila[1].ToString(),
        //               Default = bool.Parse(fila[2].ToString())
        //           });
        //    }
        //    return _idiomas;
        //}

    //    public static IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
    //    {
    //        //si no hay idioma definido, traigo el idioma por default (que es el español)
    //        if (idioma == null)
    //        {
    //            idioma = ObtenerIdiomaDefault();
    //        }
    //        Acceso Acceso = new Acceso();
    //        DataTable dt = new DataTable();

    //        IDictionary<string, ITraduccion> _traducciones = new Dictionary<string, ITraduccion>(); // Traigo las traducciones del idioma seleccionado.
    //        try
    //        {
    //            //Obtengo las traducciones del idioma que tengo seleccionado
    //            string Consulta = @"SELECT t.idIdioma, t.Traduccion as traduccion_traduccion, e.idEtiqueta, NombreEtiqueta as nombre_etiqueta FROM Traduccion t" +
    //                                " INNER JOIN Etiqueta e on t.idEtiqueta = e.idEtiqueta WHERE t.idIdioma = " + idioma.id;
    //            dt = Acceso.GenerarConsulta(Consulta);

    //            foreach (DataRow fila in dt.Rows)
    //            {
    //                var etiqueta = fila[3].ToString();
    //                _traducciones.Add(etiqueta,
    //                 new Traduccion()
    //                 {
    //                     Texto = fila[1].ToString(),
    //                     Etiqueta = new Etiqueta()
    //                     {
    //                         id = int.Parse(fila[2].ToString()),
    //                         Nombre = etiqueta
    //                     }
    //                 });
    //            }
    //            return _traducciones;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }
    //}
}
}
