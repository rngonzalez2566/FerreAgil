using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Conexion
    {
        public SqlConnection instancia;
        public void conectar()
        {
            DAL.Conexion Conex = new DAL.Conexion();

            try
            {
                Conex.conectar();
            }
            catch (SqlException exc)
            {

                throw new Exception("ocurrio un Error en BD:" + exc.Message);
            }


        }
    }
}
