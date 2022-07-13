using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Stock:Acceso
    {
        DAL.Producto producto = new DAL.Producto();
        #region Consultas
        private const string alta_Stock = "INSERT INTO Stock (id_producto, cantidad)" +
                                             " OUTPUT inserted.Id_Stock VALUES (@producto, @cantidad)";

        private const string modificacion_Stock = "UPDATE STOCK SET CANTIDAD = @cantidad OUTPUT inserted.ID_stock WHERE ID_PRODUCTO = @producto ";


        private const string get_Stock = "SELECT * FROM Stock WHERE ID_PRODUCTO = @producto";

        private const string get_Punto_Pedido = "SELECT p.ID_Producto, " +
                                                "CASE WHEN s.id_stock is null then p.StockOptimo " +
                                                "else case when s.cantidad<p.StockMinimo then StockOptimo " +
                                                "- s.cantidad else 0 end end cantidad " +
                                                "FROM Producto P " +
                                                "LEFT JOIN stock s on s.id_producto = p.ID_Producto " +
                                                "where p.Estado is null and p.StockOptimo> 0 " +
                                                "and CASE WHEN s.id_stock is null then p.StockOptimo " +
                                                "else case when s.cantidad<p.StockMinimo then StockOptimo " +
                                                "- s.cantidad else 0 end end> 0";
        #endregion

        #region ABM
        #endregion
        #region Gets
        public List<BE.Stock> GetPuntoPedido()
        {

            try
            {
                DataTable dt = new DataTable();
                List<BE.Stock> lista = new List<BE.Stock>();

                xCommandText = get_Punto_Pedido;
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        BE.Stock stock = new BE.Stock();
                        stock.Producto = producto.GetProducto(int.Parse(fila[0].ToString()));
                        stock.Cantidad = float.Parse(fila[1].ToString());
                        lista.Add(stock);                    
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
    }
}
