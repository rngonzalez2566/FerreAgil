using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso : Conexion
    {
        SqlConnection con = new SqlConnection();
        private string xTextCommand;
        private SqlCommand parameters = new SqlCommand();

        protected string xCommandText
        {
            get { return xTextCommand; }
            set { xTextCommand = value; }
        }

        protected SqlCommand xParameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        private void Conectar()
        {
            con.ConnectionString = conexion;
            con.Open();
        }
        private void Desconectar()
        {
            con.Close();
        }

        public void executeNonQuery()
        {
            //En primer lugar se debe abrir la conexion
            Conectar();

            
            SqlTransaction TR = con.BeginTransaction();
            SqlCommand command = new SqlCommand(xCommandText, con, TR);

            command.CommandType = CommandType.Text;
            command.Parameters.Clear();

            //se van a agregar los parametros
            foreach (SqlParameter p in xParameters.Parameters)
            {
                command.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            try
            {
                //ejecuto la query
                command.ExecuteNonQuery();
                TR.Commit();
            }
            //error de SQL
            catch (SqlException exc)
            {
                //en caso de error se realizara un rollback y generara una excepcion
                TR.Rollback();
                throw new Exception("ocurrio un Error en BD:" + exc.Message);
            }
            //otros errores
            catch (Exception exc2)
            {
                //en caso de error se realizara un rollback y generara una excepcion
                TR.Rollback();
                throw new Exception("ocurrio un Error :" + exc2.Message);
            }
            finally
            {
                //se cierra la conexion
                Desconectar();
            }
        }


        public DataTable ExecuteReader()
        {
            //En primer lugar se debe abrir la conexion
            Conectar();
            SqlDataReader dr;
            DataTable dt = new DataTable();
            SqlTransaction TR = con.BeginTransaction();
            SqlCommand comando = new SqlCommand(xCommandText, con, TR);

            comando.CommandType = CommandType.Text;
            comando.Parameters.Clear();

            //se van a agregar los parametros
            foreach (SqlParameter p in xParameters.Parameters)
            {
                comando.Parameters.AddWithValue(p.ParameterName, p.SqlValue);
            }

            try
            {
                //ejecuto la query
                dr = comando.ExecuteReader();
                dt.Load(dr);
                TR.Commit();
                return dt;
            }
            //error de SQL
            catch (SqlException exc)
            {
                //en caso de error se realizara un rollback y generara una excepcion
                TR.Rollback();
                throw new Exception("ocurrio un Error en BD:" + exc.Message);
            }
            //otros errores
            catch (Exception exc2)
            {
                //en caso de error se realizara un rollback y generara una excepcion
                TR.Rollback();
                throw new Exception("ocurrio un Error :" + exc2.Message);
            }
            finally
            {
                //se cierra la conexion
                Desconectar();
                
            }

        }

    }
}
