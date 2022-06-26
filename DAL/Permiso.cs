using BE.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Permiso : Acceso
    {
        #region Consultas
        private const string alta_Permiso = "INSERT INTO PERMISO (nombre, permiso) VALUES (@nombre, @permiso)";
        private const string get_Patentes = "SELECT idPermiso, Nombre FROM PERMISO WHERE PERMISO is not null";
        private const string get_Familias = "SELECT idPermiso, Nombre FROM PERMISO WHERE PERMISO is null";
        private const string get_All = "WITH RECURSIVO AS (SELECT fp.idPermisoPadre, fp.idPermisoHijo FROM Familia_Patente fp WHERE fp.idPermisoPadre = @idpermisopadre " +
                                        "UNION ALL SELECT fp2.idPermisoPadre, fp2.idPermisoHijo FROM Familia_Patente fp2 INNER JOIN RECURSIVO r " +
                                        "on r.idPermisoHijo = fp2.idPermisoPadre) " +
                                        "SELECT r.idPermisoPadre, r.idPermisoHijo, p.idPermiso, p.Nombre, p.Permiso FROM RECURSIVO r " +
                                        "INNER JOIN Permiso p on r.idPermisoHijo = p.idPermiso";
        private const string delete_Familia_Patente = "DELETE FROM Familia_Patente WHERE idPermisoPadre = @idpermisopadre";
        private const string crear_Familia_Patente = "INSERT INTO Familia_Patente(idPermisoPadre, idPermisoHijo) " +
                                                      "VALUES(@idpermisopadre, @idpermisohijo)";



        #endregion
        #region ABM
        public void AltaPermiso(Componente cmp, bool esFamilia)
        {
            try
            {
                xCommandText = alta_Permiso;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@nombre", cmp.nombre);

                if (esFamilia) xParameters.Parameters.AddWithValue("@permiso", DBNull.Value);
                else xParameters.Parameters.AddWithValue("@permiso", cmp.Permiso.ToString());
                executeNonQuery();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public void CrearFamiliaPatente(Familia familia) // Método para asignar los permisos a una familia.
        {
            try
            {

                xCommandText = delete_Familia_Patente;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idpermisopadre", familia.id);

                executeNonQuery();

                foreach (var item in familia.Hijos)
                {

                    xCommandText = crear_Familia_Patente;
                    xParameters.Parameters.Clear();
                    xParameters.Parameters.AddWithValue("@idpermisopadre", familia.id);
                    xParameters.Parameters.AddWithValue("@idpermisohijo", item.id);
                    executeNonQuery();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        #region Gets
        public Array GetTipoPermiso()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }

        public IList<Patente> GetPatentes()
        {
            try
            {
                DataTable dt = new DataTable();
                IList<Patente> lista = new List<Patente>();

                xCommandText = get_Patentes;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Patente patente = new Patente();
                        patente.id = int.Parse(fila[0].ToString());
                        patente.nombre = fila[1].ToString();

                        lista.Add(patente);
                    }

                }

                return lista;
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
            
        }

        public IList<Familia> GetFamilias()
        {
            try
            {
                DataTable dt = new DataTable();
                IList<Familia> lista = new List<Familia>();

                xCommandText = get_Familias;
                xParameters.Parameters.Clear();    
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Familia familia = new Familia();
                        familia.id = int.Parse(fila[0].ToString());
                        familia.nombre = fila[1].ToString();

                        lista.Add(familia);
                    }

                }

                return lista;
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }

        }

        public IList<Componente> GetAll(int familia) // Traigo a una lista, patentes y familias.
        {

            try
            {

                xCommandText = get_All;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idpermisopadre", familia);

                DataTable dt = new DataTable();
                dt = ExecuteReader();


                var lista = new List<Componente>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rows in dt.Rows)
                    {
                        int idpadre = 0;
                        if (rows["idPermisoPadre"] != DBNull.Value)
                        {
                            idpadre = int.Parse(rows["idPermisoPadre"].ToString());
                        }

                        var id = int.Parse(rows["idPermiso"].ToString());
                        var nombre = (rows["Nombre"].ToString());
                        var permiso = string.Empty;
                        if (rows["Permiso"] != DBNull.Value) permiso = rows["Permiso"].ToString();

                        Componente componente; // Acá voy a identificar si lo que traje es una patente o una familia.
                        if (string.IsNullOrEmpty(permiso)) componente = new Familia();
                        else componente = new Patente();

                        componente.id = id;
                        componente.nombre = nombre;
                        if (!string.IsNullOrEmpty(permiso)) componente.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);

                        var padre = ObtenerComponente(idpadre, lista);
                        if (padre == null) lista.Add(componente);
                        else padre.AgregarHijo(componente);
                    }
                }
                return lista;
            }
            catch 
            {

                throw new Exception("Error en la base de datos.");
            }
        }

        private Componente ObtenerComponente(int id, IList<Componente> lista) // Método para obtener el Componente.
        {
            Componente componente = lista != null ? lista.Where(i => i.id.Equals(id)).FirstOrDefault() : null;

            if (componente == null && lista != null)
            {
                foreach (var item in lista)
                {
                    var _lista = ObtenerComponente(id, item.Hijos);
                    if (_lista != null && _lista.id == id) return _lista;
                    else if (_lista != null) return ObtenerComponente(id, _lista.Hijos);
                }
            }
            return componente;
        }

        public bool existeComponente(Componente comp, int id) // Método para verificar si existe el Componente.
        {
            bool existeComp = false;
            if (comp.id.Equals(id))
            {
                existeComp = true;
            }
            else
            {
                foreach (var item in comp.Hijos)
                {
                    existeComp = existeComponente(item, id);
                    if (existeComp) return true;
                }
            }
            return existeComp;
        }

        #endregion
    }
}
