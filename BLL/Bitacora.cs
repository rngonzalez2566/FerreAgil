using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class Bitacora
    {
        DAL.Bitacora bitacora = new DAL.Bitacora();
        DigitoVerificador dv = new DigitoVerificador();
        DAL.DigitoVerificador dvDAL = new DAL.DigitoVerificador();
        #region ABM
        public int RegistrarBitacora(string Descripcion, string Criticidad)
        {


            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    BE.Bitacora bit = new BE.Bitacora()
                    {
                        Usuario = SingletonSesion.GetUsuario(),
                        Descripcion = Descripcion,
                        Criticidad = Criticidad,
                        Fecha = DateTime.Now

                    };
                    bit.DVH = dv.CalcularDV(bit);

                    int idBitacora = bitacora.RegistrarBitacora(bit);
                    dvDAL.AltaDVV("Bitacora");

                    scope.Complete();
                    return idBitacora;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
        #endregion

        #region Get
        public DataTable ListarCriticidad()
            {
                try
                {

                    return bitacora.ListarCriticidad();
                }
                catch (Exception)
                {
                    throw new Exception("Error al obtener Criticidades");
                }
            
            }

            public List<BE.Usuario> ListarUsuarios()
            {
                try
                {

                    return bitacora.ListarUsuarios();
                }
                catch (Exception)
                {
                    throw new Exception("Error al obtener Usuarios");
                }
            }
            public List<BE.Bitacora> Busqueda(string xUsuario, string xFechaD, string xFechaH, string xCriticidad)
            {
                try
                {

                    return bitacora.Busqueda(xUsuario, xFechaD, xFechaH, xCriticidad);
                }
                catch (Exception)
                {
                    throw new Exception("Error al realizar la busqueda");
                }
            
            }

        #endregion
    }
}
