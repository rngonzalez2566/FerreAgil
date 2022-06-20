using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnidadMedida
    {
        #region ABM

        #endregion
        #region Get
        public BE.UnidadMedida GetUnidadMedida(int idUM)
        {
            try
            {
                DAL.UnidadMedida um = new DAL.UnidadMedida();
                return um.GetUnidadMedida(idUM);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener Unidad de medida");
            }
        }
        public List<BE.UnidadMedida> GetUnidadMedidas()
        {
            try
            {
                DAL.UnidadMedida um = new DAL.UnidadMedida();
                return um.GetUnidadMedidas();
            }
            catch (Exception) { 
                throw new Exception("Error al obtener Unidades de Medida"); 
            }
        }
        #endregion
        #region Validaciones
        public void validarUnidadMedida(BE.UnidadMedida um)
        {
            if (string.IsNullOrEmpty(um.simbolo)) throw new Exception("El Simbolo es requerido");
            if (string.IsNullOrEmpty(um.nombre)) throw new Exception("El Nombre es requerido");
        }
        #endregion
    }
}
