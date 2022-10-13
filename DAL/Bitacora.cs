using BE;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Bitacora : Acceso
    {
        #region Consultas

        private const string alta_Bitacora = "INSERT INTO BITACORA (id_usuario,Fecha,Descripcion,Criticidad,DVH) " +
                                             " OUTPUT inserted.id_bitacora VALUES (@usuario, @fecha, @descripcion, @criticidad, @dv) ";
        private const string get_User_Bitacora = "SELECT U.id_usuario ID, U.usuario USUARIO FROM Usuario U " +
                                                 "INNER JOIN Bitacora B ON B.id_usuario = U.id_usuario " +                                   
                                                  "GROUP BY U.usuario, U.id_usuario";
        private const string get_Criticidad_Bitacora = "SELECT  B.Criticidad CRITICIDAD FROM Bitacora B GROUP BY B.Criticidad";
       

        #endregion

        #region ABM
        public int RegistrarBitacora(BE.Bitacora bit)
        {
            try
            {
                xCommandText = alta_Bitacora;

                xParameters.Parameters.Clear();

                if(bit.Usuario != null)
                {
                    xParameters.Parameters.AddWithValue("@usuario", bit.Usuario.id_usuario);
                }
                else
                {
                    xParameters.Parameters.AddWithValue("@usuario", DBNull.Value);
                }
                
                xParameters.Parameters.AddWithValue("@fecha", bit.Fecha);
                xParameters.Parameters.AddWithValue("@descripcion", bit.Descripcion);
                xParameters.Parameters.AddWithValue("@criticidad", bit.Criticidad);
                xParameters.Parameters.AddWithValue("@dv", bit.DVH);


                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Gets
        public DataTable ListarCriticidad()
        {
            DataTable dt = new DataTable();

            try
            {
                xCommandText = get_Criticidad_Bitacora;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();
                return dt;
            }
            catch
            {
                throw new Exception("Se produjo un error con la base de datos");
            }

        }

        public List<BE.Usuario> ListarUsuarios()
        {
            DataTable dt = new DataTable();

            try
            {
                xCommandText = get_User_Bitacora;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();
                List<BE.Usuario> lista = new List<BE.Usuario>();
                Services.Encriptar encriptar = new Services.Encriptar();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        BE.Usuario usuario = new BE.Usuario();
                        usuario.id_usuario = int.Parse(fila[0].ToString());
                        usuario.usuario = encriptar.descencriptar(fila[1].ToString());

                        lista.Add(usuario);
                    }
                }
                        return lista;
            }
            catch
            {
                throw new Exception("Se produjo un error con la base de datos");
            }

        }

        public List<BE.Bitacora> Busqueda(string xUsuario, string xFechaD, string xFechaH, string xCriticidad)
        {

           try
               {
            List<BE.Bitacora> ListaBitacora = new List<BE.Bitacora>();
            DataTable dt = new DataTable();
            string get_Busqueda = "SELECT B.id_bitacora, B.fecha , b.id_usuario usuario, " +
                                   "b.Descripcion, b.Criticidad " +
                                   "FROM Bitacora B " +
                                   "left join usuario u on u.id_usuario = b.id_usuario " +
                                   "WHERE " + xUsuario + xFechaD + xFechaH + xCriticidad + " " +
                                   "order by b.Fecha";
            xCommandText = get_Busqueda;
            xParameters.Parameters.Clear();

            dt = ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {

                    BE.Bitacora bitacora = new BE.Bitacora();
                    Usuario us = new Usuario();

                    bitacora.id_bitacora = int.Parse(fila[0].ToString());
                    bitacora.Fecha = DateTime.Parse(fila[1].ToString());
                    if(fila[2].ToString() != "")
                    {
                        bitacora.Usuario = us.GetUsuarioByID(int.Parse(fila[2].ToString()));
                    }
              
                    bitacora.Descripcion = fila[3].ToString();
                    bitacora.Criticidad = fila[4].ToString();

                    ListaBitacora.Add(bitacora);
                }
            }
                return ListaBitacora;
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }


            
        }
        #endregion
    }
}
