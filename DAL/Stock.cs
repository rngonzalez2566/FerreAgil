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
        private const string get_Analisis_Stock = "SELECT p.ID_Producto,isnull(s.cantidad,0) cantidad, " +                                               
                                                  "case when p.StockMinimo = 0 then 0 else case when p.StockMinimo > 0 and ISNULL(s.cantidad,0) <= p.StockOptimo " +
                                                  "and  ISNULL(s.cantidad,0) >= p.StockMinimo then 1 " +
                                                  "else case when p.StockMinimo > 0 and ISNULL(s.cantidad,0) < p.StockMinimo then 2 end end end estado " +
                                                  "FROM Producto P " +
                                                  "LEFT JOIN Stock S ON S.id_producto = P.ID_Producto " +
                                                  "where p.Estado is null";

        #endregion

        #region ABM

        public int IngresoStock(BE.Stock stock,int modo)
        {
            try
            {
                if(modo == 1)
                {
                    xCommandText = alta_Stock;
                }
                else
                {
                    xCommandText = modificacion_Stock;
                }
               
                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@producto", stock.Producto.id_Producto);
                xParameters.Parameters.AddWithValue("@cantidad", stock.Cantidad);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
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
        public BE.Stock GetStock(BE.Producto prod)
        {

            try
            {
                DataTable dt = new DataTable();
                BE.Stock stock = new BE.Stock();
                DAL.Producto producto = new DAL.Producto();
                int idProd = 0;
                xCommandText = get_Stock;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@producto", prod.id_Producto);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {

                    stock.id = int.Parse(dt.Rows[0]["id_stock"].ToString());
                    idProd = int.Parse(dt.Rows[0]["id_producto"].ToString());
                    stock.Producto = producto.GetProducto(idProd);
                    stock.Cantidad = float.Parse(dt.Rows[0]["cantidad"].ToString());
                  
                }
                else
                {
                    stock = null;
                }

                return stock;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<BE.Stock> GetAnalisisStock()
        {
            try
            {
                DataTable dt = new DataTable();
                List<BE.Stock> lista = new List<BE.Stock>();

                xCommandText = get_Analisis_Stock;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {

                        BE.Stock stock = new BE.Stock();
                        BE.Producto Producto = new BE.Producto();
                        DAL.Producto prodDAL = new DAL.Producto();

                        int idProd = int.Parse(fila[0].ToString());
                        stock.Producto = prodDAL.GetProducto(idProd);
                        stock.Cantidad = float.Parse(fila[1].ToString());
                        stock.Condicion = int.Parse(fila[2].ToString());


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
