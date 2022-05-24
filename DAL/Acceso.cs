using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso 
    {
        public string ExecutenonQuery(string query)
        {
            Conexion con = new Conexion();
            SqlTransaction TR = con.conectar().BeginTransaction();
            SqlCommand comando = new SqlCommand(query, con.conectar());
            int r = 0;
            try
            {

                r = comando.ExecuteNonQuery();
                return r.ToString();
            }
            catch (SqlException e)
            {
                _error = e.ToString();
                return _error;

            }
            finally
            {
                con.desconectar();
            }

        }
    }
}
