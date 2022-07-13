using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Stock
    {
        #region Gets
        public List<BE.Stock> GetPuntoPedido()
        {
            try
            {
                DAL.Stock stock = new DAL.Stock();
                return stock.GetPuntoPedido();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener Productos");
            }
        }
        #endregion
    }
}
