using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bitacora
    {
        DAL.Bitacora bitacora = new DAL.Bitacora();
        #region ABM
        public int RegistrarBitacora(BE.Bitacora bit)
        {
            try
            {
                int idBitacora = bitacora.RegistrarBitacora(bit);
                return idBitacora;
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

            public DataTable ListarUsuarios()
            {
                try
                {

                    return bitacora.ListarCriticidad();
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
