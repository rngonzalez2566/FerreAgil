using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Detalle_Compra
    {
        DAL.Detalle_Compra detalleDAL = new DAL.Detalle_Compra();
        #region Gets
        public List<BE.Detalle_Compra> GetDetalleCompra(int idCompra)
        {
            try
            {
                return detalleDAL.GetDetalleCompra(idCompra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region ABM
        public int ModificaCantidadRecepcionada(int idDetalle, float cantidad)
        {
            try
            {
                return detalleDAL.ModificaCantidadRecepcionada(idDetalle, cantidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            #endregion

        }
}
