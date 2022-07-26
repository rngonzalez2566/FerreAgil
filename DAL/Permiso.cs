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
        private const string get_Permiso = "SELECT UPPER(NOMBRE) NOMBRE FROM PERMISO WHERE NOMBRE = @nombre";
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
        private const string get_Usuario_Permiso = "SELECT p.* FROM Usuario_Permiso up INNER JOIN Permiso p on p.idPermiso = up.idPermiso " +
                                                    "WHERE idUsuario = @idusuario";
        private const string delete_Permiso_Usuario = "DELETE FROM Usuario_Permiso WHERE idUsuario = @idusuario";
        private const string Crear_Permiso_Usuario = "INSERT INTO Usuario_Permiso(idUsuario, idPermiso) VALUES(@idusuario, @idpermiso)";
        private const string get_VerificarPermisos = "SELECT up.idUsuario, p.idPermiso, p.Nombre, p.Permiso, p1.Permiso as CodigoPermiso " +
                                                        "FROM Permiso p INNER JOIN Usuario_Permiso up on up.idPermiso = p.idPermiso " +
                                                        "INNER JOIN Familia_Patente fp on fp.idPermisoPadre = p.idPermiso " +
                                                        "INNER JOIN Permiso p1 on p1.idPermiso = fp.idpermisohijo " +
                                                        "WHERE idUsuario = @idusuario and p1.Permiso = @permiso " +
                                                        "UNION ALL " +
                                                        "SELECT up.idUsuario, p.idPermiso, p.Nombre, p.Permiso, p1.Permiso as CodigoPermiso " +
                                                        "FROM Permiso p INNER JOIN Usuario_Permiso up on up.idPermiso = p.idPermiso " +
                                                        "INNER JOIN Familia_Patente fp on fp.idPermisoHijo = p.idPermiso " +
                                                        "INNER JOIN Permiso p1 on p1.idPermiso = fp.idpermisohijo " +
                                                        "WHERE idUsuario = @idusuario and p1.Permiso = @permiso " +
                                                        "UNION ALL " +
                                                        "SELECT up.idUsuario, p.idPermiso,  '', '', p.Permiso as CodigoPermiso " +
                                                        "FROM Permiso p INNER JOIN Usuario_Permiso up on up.idPermiso = p.idPermiso " +
                                                        "WHERE UP.idUsuario = @idusuario and p.Permiso = @permiso";

        private const string get_ValidaFamilia = "WITH RECURSIVO AS(SELECT fp.idPermisoPadre, fp.idPermisoHijo, 0 as cont FROM Familia_Patente fp " +
                                                    "WHERE fp.idPermisoPadre in ( " +
                                                    "Select fpp.idPermisoPadre " +
                                                    "from Familia_Patente fpp " +
                                                    "inner join Permiso pp2 on pp2.idPermiso = fpp.idPermisoPadre " +
                                                    "where fpp.idPermisoHijo in ( " +
                                                    "SELECT fp.idPermisoPadre " +
                                                    "FROM Familia_Patente fp " +
                                                    "inner join permiso p1 on p1.idPermiso = fp.idPermisoPadre " +
                                                    "WHERE fp.idPermisoHijo = @idFamilia) " +
                                                    "UNION ALL " +
                                                    "SELECT fp.idPermisoPadre " +
                                                    "FROM Familia_Patente fp " +
                                                    "inner join permiso p1 on p1.idPermiso = fp.idPermisoPadre " +
                                                    "WHERE fp.idPermisoHijo = @idFamilia " +
                                                    ") " +
                                                    "UNION ALL " +
                                                    "SELECT fp2.idPermisoPadre, fp2.idPermisoHijo, cont + 1 " +
                                                    "FROM Familia_Patente fp2 INNER JOIN RECURSIVO r " +
                                                    "on r.idPermisoHijo = fp2.idPermisoPadre) " +
                                                    "select* from( " +
                                                    "SELECT r.idPermisoPadre , p1.Nombre " +
                                                    "FROM RECURSIVO r " +
                                                    "INNER JOIN Permiso p on r.idPermisoHijo = p.idPermiso " +
                                                    "INNER JOIN Permiso p1 on r.idPermisoPadre = p1.idPermiso " +
                                                    "inner join Permiso p3 on p3.idPermiso = @idFamilia " +
                                                    "where (cont = 0 or (p.idPermiso = @idFamilia)) " +
                                                    "group by r.idPermisoPadre,p1.Nombre " +
                                                    "UNION ALL " +
                                                    "SELECT fm.idPermisoPadre, pm1.Nombre FROM Familia_Patente fm " +
                                                    "inner join Permiso pm1 on pm1.idPermiso = fm.idPermisoPadre " +
                                                    "where fm.idPermisoHijo in ( " +
                                                     "select * from spResult  " +
                                                    ") " +
                                                    ") q " +
                                                    "group by q.idPermisoPadre, q.nombre";









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

        public void GuardarPermiso(BE.Usuario user) // Método para guardar los permisos que se asignaron.
        {
            try
            {
                xCommandText = delete_Permiso_Usuario;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idusuario", user.id_usuario);

                executeNonQuery();

                foreach (var item in user.Permisos)
                {

                    xCommandText = Crear_Permiso_Usuario;
                    xParameters.Parameters.Clear();
                    xParameters.Parameters.AddWithValue("@idusuario", user.id_usuario);
                    xParameters.Parameters.AddWithValue("@idpermiso", item.id);

                    executeNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Gets

        public bool GetPermiso(string nombre)
        {
            try
            {
                DataTable dt = new DataTable();
                bool existe = false;

                xCommandText = get_Permiso;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@nombre", nombre);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    existe = true;
                }

                return existe;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
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

        public IList<Familia> GetFamiliasValidacion(int id)
        {
            try
            {
                

                DataTable dt = new DataTable();
                IList<Familia> lista = new List<Familia>();

                xCommandText = get_ValidaFamilia;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idFamilia", id);
                StoredProcedure("CrearTablaTemporal",id);
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

        public void GetUsuarioPermiso(BE.Usuario user)
        {

            try
            {
                DataTable dt = new DataTable();

                xCommandText = get_Usuario_Permiso;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idusuario", user.id_usuario);
                dt = ExecuteReader();



                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rows in dt.Rows)
                    {
                        int id = int.Parse(rows["idPermiso"].ToString());
                        string nombre = rows["Nombre"].ToString();
                        string permiso = String.Empty;
                        if (rows["Permiso"].ToString() != String.Empty) permiso = rows["Permiso"].ToString();

                        Componente componente;
                        if (!String.IsNullOrEmpty(permiso))
                        {
                            componente = new Patente();
                            componente.id = id;
                            componente.nombre = nombre;
                            componente.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);
                            user.Permisos.Add(componente);
                        }
                        else
                        {
                            componente = new Familia();
                            componente.id = id;
                            componente.nombre = nombre;

                            var familia = GetAll(id);
                            foreach (var f in familia)
                            {
                                componente.AgregarHijo(f);
                            }
                            user.Permisos.Add(componente);
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public void LlenarComponenteFamilia(Familia familia) // Método para llenar la Familia.
        {
            familia.VaciarHijos();
            foreach (var item in GetAll(familia.id))
            {
                familia.AgregarHijo(item);
            }
        }

        public bool VerificarPermiso(BE.Usuario user, string Permiso)
        {
            bool valido = false;
            try
            {
                DataTable dt = new DataTable();

                xCommandText = get_VerificarPermisos;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idusuario", user.id_usuario);
                xParameters.Parameters.AddWithValue("@permiso", Permiso);
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        string codigopermiso = fila["CodigoPermiso"].ToString();
                        if (codigopermiso == Permiso) return valido = true;
                    }

                }

                return valido;
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }


        }

        #endregion
    }
}
