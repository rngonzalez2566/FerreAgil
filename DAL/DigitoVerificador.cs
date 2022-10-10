using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DigitoVerificador : Acceso
    {
        #region Consultas
        private const string alta_DVV = "INSERT INTO DigitoVerificador (nombre_tabla, valorDVV) " +
                                         " OUTPUT inserted.id_DV VALUES (@tabla, @dvv) ";
        private const string get_DVH = "SELECT ISNULL(SUM(DVH),0) DVH FROM {0}";
        private const string exist_DVV = "SELECT ISNULL(SUM(valorDVV),0) DVV FROM digitoVerificador where nombre_tabla = @tabla";
        private const string actualizar_DVV = "update DigitoVerificador set valorDVV = @dvv OUTPUT inserted.id_DV where nombre_tabla = @tabla";

        #endregion

        #region ABM
        public int AltaDVV(string xTabla)
        {
            try
            {

                int dvv = existeDVV(xTabla);

                int dvh = CalcularDVH(xTabla);


                if (dvv == 0) xCommandText = alta_DVV;
                else xCommandText = actualizar_DVV;

                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@tabla", xTabla);
                xParameters.Parameters.AddWithValue("@dvv", dvh);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Gets

        public int CalcularDVH(string xTabla)
        {
            int xDVH = 0;
            
            xCommandText = String.Format(get_DVH,xTabla);

            DataTable dt = new DataTable();
            dt = ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                xDVH = int.Parse(dt.Rows[0]["DVH"].ToString());
            }

            return xDVH;
        }

        public int existeDVV(string xTabla)
        {
            int xDVV = 0;

            xCommandText = exist_DVV;
            xParameters.Parameters.Clear();
            xParameters.Parameters.AddWithValue("@tabla", xTabla);

            DataTable dt = new DataTable();
            dt = ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                xDVV = int.Parse(dt.Rows[0]["DVV"].ToString());
            }

            return xDVV;
        }

        #endregion
    }
}
