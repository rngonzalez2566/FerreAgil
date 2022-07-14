using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class Compra
    {
        DAL.Compra compraDAL = new DAL.Compra();
        #region Gets
        public int GetUltimoComprobante()
        {
            try
            {
                return compraDAL.GetUltimoComprobante();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el ultimo Nro");
            }
           
        }

        public List<BE.Compra> GetPendientes(string pendiente)
        {
            try
            {
                return compraDAL.GetPendientes(pendiente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BE.Compra GetCompra(int nro)
        {
            try
            {
                return compraDAL.GetCompra(nro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            #endregion
            #region ABM
            public int AltaCompra(BE.Compra compra)
        {
            try
            {
                return compraDAL.AltaCompra(compra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AltaDetalleCompra(BE.Detalle_Compra detalle, int idCompra)
        {
            try
            {
                return compraDAL.AltaDetalleCompra(detalle, idCompra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GenerarCompra(BE.Compra compra)
        {
            try
            {
                int idCompra = 0;

                using (TransactionScope scope = new TransactionScope())
                {
                    idCompra = AltaCompra(compra);
                    foreach (var item in compra.Items)
                    {
                        AltaDetalleCompra(item, idCompra);
                    }

                    scope.Complete();
                }

                return idCompra;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CambioEstado(int nro, string estado)
        {
            try
            {
                return compraDAL.CambioEstado(nro, estado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

            #endregion
        }
}
