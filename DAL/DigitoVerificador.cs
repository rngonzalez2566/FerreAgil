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
        private const string get_Tabla_Digitos = "select nombre_tabla from DigitoVerificador";
        private const string get_Recalcula_Digitos = "select * from {0}";
        

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

        public void RecalcularDigitos()
        {
            Services.DigitoVerificador dv = new Services.DigitoVerificador();
            DAL.DigitoVerificador dvDAL = new DAL.DigitoVerificador();
            try
            {
                xCommandText = get_Tabla_Digitos;

                DataTable dt = new DataTable();
                dt = ExecuteReader();
                string tabla;
                string xQuery;

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        tabla = fila[0].ToString();
                        if (tabla == "Usuario")
                        {
                            xCommandText = String.Format(get_Recalcula_Digitos, tabla);
                            DataTable dtU = new DataTable();
                            dtU = ExecuteReader();
                            if (dtU.Rows.Count > 0)
                            {
                                foreach (DataRow fila1 in dtU.Rows)
                                {

                                    BE.Usuario usuario = new BE.Usuario();

                                    usuario.id_usuario = int.Parse(fila1[0].ToString());
                                    usuario.usuario = fila1[1].ToString();
                                    usuario.contrasena = fila1[2].ToString();
                                    usuario.contador = int.Parse(fila1[3].ToString());
                                    usuario.email = fila1[5].ToString();
                                    usuario.DVH = dv.CalcularDV(usuario);

                                    xQuery = "update usuario set DVH = {0} where id_usuario = {1}";
                                    xCommandText = String.Format(xQuery, usuario.DVH, usuario.id_usuario);
                                    executeNonQuery();
                                    dvDAL.AltaDVV("Usuario");
                                }
                            }
                        }
                        else
                        if (tabla == "Bitacora")
                        {
                            xCommandText = String.Format(get_Recalcula_Digitos, tabla);
                            DataTable dtB = new DataTable();
                            dtB = ExecuteReader();

                            if (dtB.Rows.Count > 0)
                            {
                                foreach (DataRow fila2 in dtB.Rows)
                                {

                                    BE.Bitacora bit = new BE.Bitacora();
                                    Usuario us = new Usuario();

                                    bit.id_bitacora = int.Parse(fila2[0].ToString());
                                    if (fila2[1].ToString() != "")
                                    {
                                        bit.Usuario = us.GetUsuarioByID(int.Parse(fila2[1].ToString()));
                                    }

                                    bit.Descripcion = fila2[2].ToString();
                                    bit.Criticidad = fila2[3].ToString();
                                    bit.Fecha = DateTime.Parse(fila2[4].ToString());
                                    bit.DVH = dv.CalcularDV(bit);

                                    xQuery = "update Bitacora set DVH = {0} where id_bitacora = {1}";
                                    xCommandText = String.Format(xQuery, bit.DVH, bit.id_bitacora);
                                    executeNonQuery();

                                    dvDAL.AltaDVV("Bitacora");
                                }
                            }
                        }
                    }
                }
                

            }
            catch
            {

                throw new Exception("Error al recalcular digitos verificadores");
            }

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

        public List<String> VerificarDV()
        {
            BE.Usuario usuario = new BE.Usuario();
            usuario.id_usuario = 1;
            usuario.usuario = "Sistema";
            var lista = new List<String>();

            string xMensaje = "";
            string xConsulta = "SELECT D.nombre_tabla TABLA, D.valorDVV DV FROM DigitoVerificador D";
            xCommandText = xConsulta;
            DataTable tb = new DataTable();
            tb = ExecuteReader();

            foreach (DataRow fila in tb.Rows)
            {
                int xDV = int.Parse(fila[1].ToString());
                string xTabla = fila[0].ToString();

                

                string xConsulta1 = "SELECT ISNULL(SUM(DVH),0) DVH FROM {0}";
                xCommandText = String.Format(xConsulta1, xTabla);
                DataTable tb1 = new DataTable();
                tb1 = ExecuteReader();

                int xValor = int.Parse(tb1.Rows[0]["DVH"].ToString());

                if (xValor != xDV)
                {
                    xMensaje = "Error en la integridad de la base de datos";
                    lista.Add("Error en la validacion de la suma de digitos horizontales con el Digito Vertical de la tabla: " + xTabla);
                }

            }
            return lista;
        }
        #endregion
    }
}
