using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Detalle_Compra: Acceso
    {
        #region Consultas
        private const string get_Detalle_Compra = "SELECT id_Detalle_compra, id_Producto, Cantidad, PrecioUnitario, " +
                                               "Total, isnull(CantidadRecepcionada,0) CantidadRecepcionada FROM Detalle_Compra Where id_compra = @idCompra";
        private const string Modifica_Cantidad_Recepcionada = "update Detalle_Compra set CantidadRecepcionada = @cantidad OUTPUT inserted.id_Detalle_compra where id_Detalle_compra = @id";
        #endregion

        #region Gets
        public List<BE.Detalle_Compra> GetDetalleCompra(int idCompra)
        {

            try
            {
                DataTable dt = new DataTable();
                List<BE.Detalle_Compra> lista = new List<BE.Detalle_Compra>();

                xCommandText = get_Detalle_Compra;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@idCompra", idCompra);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    BE.Producto prod = new BE.Producto();
                    DAL.Producto prodDAL = new DAL.Producto();

                    foreach (DataRow fila in dt.Rows)
                    {

                        BE.Detalle_Compra detalle = new BE.Detalle_Compra();

                        detalle.id = int.Parse(fila[0].ToString());
                        prod = prodDAL.GetProducto(int.Parse(fila[1].ToString()));
                        detalle.Producto = prod;
                        detalle.Cantidad = float.Parse(fila[2].ToString());
                        detalle.PrecioUnitario = float.Parse(fila[3].ToString());
                        detalle.Total = float.Parse(fila[4].ToString());
                        detalle.CantidadRecepcionada = float.Parse(fila[5].ToString());

                        lista.Add(detalle);
                    }

                }

                return lista;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
        #region ABM
        public int ModificaCantidadRecepcionada(int idDetalle,float cantidad)
        {
            try
            {
                xCommandText = Modifica_Cantidad_Recepcionada;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@cantidad", cantidad);
                xParameters.Parameters.AddWithValue("@id", idDetalle);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
