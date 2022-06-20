using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Producto
    {
        #region ABM
        public int altaProducto(BE.Producto producto)
        {
            DAL.Producto dalProducto = new DAL.Producto();
            ValidaPRoducto(producto);
            int idProducto = dalProducto.AltaProducto(producto);
            return idProducto;
        }
        #endregion
        #region Validaciones
        private void ValidaPRoducto(BE.Producto producto)
        {
            if (string.IsNullOrEmpty(producto.codigo)) throw new Exception("El codigo es requerido");
            if (string.IsNullOrEmpty(producto.descripcion)) throw new Exception("La descripcion es requerida");
            if (producto.stockMinimo < 0) throw new Exception("El Stock minimo puede ser mayor o igual a cero");
            if (producto.stockOptimo < 0) throw new Exception("El Stock optimo puede ser mayor o igual a cero");
            if (producto.unidadMedida == null) throw new Exception("La unidad de medida es requerida");

        }
        #endregion
    }
}
