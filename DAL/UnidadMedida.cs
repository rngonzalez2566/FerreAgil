using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnidadMedida:Acceso
    {
        #region Consultas
        private const string alta_UnidadMedida = "INSERT INTO Unidad_Medida (simbolo, nombre)" +
                                            " OUTPUT inserted.Id_unidadMedida VALUES (@simbolo, @nombre)";

        private const string baja_UnidadMedida = "UPDATE Unidad_Medida SET ESTADO = 'BAJA' OUTPUT inserted.Id_unidadMedida WHERE ID_UNIDADMEDIDA = @Id_unidadMedida ";

        private const string modificacion_UnidadMedida = "UPDATE Unidad_Medida SET SIMBOLO = @simbolo, SET NOMBRE = @nombre" +
                                                     " OUTPUT inserted.Id_unidadMedida  WHERE ID_UNIDADMEDIDA = @Id_unidadMedida ";

        private const string get_UnidadMedida = "SELECT * FROM Unidad_Medida WHERE ID_UNIDADMEDIDA = @Id_unidadMedida AND ESTADO is null ";

        private const string get_UnidadMedidas = "SELECT * FROM Unidad_Medida WHERE ESTADO is null ";
        #endregion


        #region Gets

        public BE.UnidadMedida GetUnidadMedida(int unidadMedidaId)
        {
            DataTable dt = new DataTable();
            BE.UnidadMedida unidadMedida = new BE.UnidadMedida();

            try
            {


                xCommandText = get_UnidadMedida;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@id_unidadMedida", unidadMedidaId);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    unidadMedida.id_UnidadMedida = int.Parse(dt.Rows[0]["id_unidadMedida"].ToString());
                    unidadMedida.simbolo = dt.Rows[0]["simbolo"].ToString();
                    unidadMedida.nombre = dt.Rows[0]["nombre"].ToString();
                    unidadMedida.estado = dt.Rows[0]["estado"].ToString();


                }
                else
                {
                    unidadMedida = null;
                }

                return unidadMedida;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<BE.UnidadMedida> GetUnidadMedidas()
        {
            
     

            try
            {
                DataTable dt = new DataTable();
                List<BE.UnidadMedida> listaUM = new List<BE.UnidadMedida>();
                xCommandText = get_UnidadMedidas;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        BE.UnidadMedida um = new BE.UnidadMedida();
                        um.id_UnidadMedida = int.Parse(fila[0].ToString());
                        um.simbolo = fila[1].ToString();
                        um.nombre = fila[2].ToString();

                        listaUM.Add(um);
                    }                 

                }

                return listaUM;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        #endregion
    }


}
