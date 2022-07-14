using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class Stock
    {
        DAL.Stock stockDAL = new DAL.Stock();
        DAL.Compra compraDAL = new DAL.Compra();
        #region Gets
        public List<BE.Stock> GetPuntoPedido()
        {
            try
            {
                return stockDAL.GetPuntoPedido();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener Productos");
            }
        }
        public BE.Stock GetStock(BE.Producto prod)
        {
            try
            {
                return stockDAL.GetStock(prod);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener Productos");
            }
        }

        public List<BE.Stock> GetAnalisisStock()
        {
            try
            {
                return stockDAL.GetAnalisisStock();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener Productos");
            }
        }


            #endregion
            #region AMB
            public void IngresoStock(BE.Compra compra,string estado)
            {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
 
                    foreach (var item in compra.Items)
                    {
                        int modo = 0;
                        BE.Stock stock = new BE.Stock();
                        stock = stockDAL.GetStock(item.Producto);
                        compraDAL.CambioEstado(compra.Nro, estado);
                        if (stock == null)
                        {
                            BE.Stock stock1 = new BE.Stock();
                            modo = 1;
                            stock1.Cantidad = item.CantidadRecepcionada;
                            stock1.Producto = item.Producto;
                            stockDAL.IngresoStock(stock1, modo);
                        }
                        else
                        {
                            stock.Cantidad = stock.Cantidad + item.CantidadRecepcionada;
                            stockDAL.IngresoStock(stock, modo);
                        }
                        
                    }
                    
                    scope.Complete();
                }


                
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener Productos");
            }
        }

        #endregion
    }
}
