using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Proveedor
    {

        #region Gets
        public List<BE.Proveedor> GetProvedoores()
        {
            try
            {
                DAL.Proveedor proveedor = new DAL.Proveedor();
                return proveedor.GetProveedores();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener Los Proveedores");
            }
        }
        #endregion
    }
}
