using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Detalle_Compra
    {
        public int id { get; set; }
        public Producto Producto { get; set; }
        public float Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Total { get; set; }

        public float CantidadRecepcionada { get; set; }
    }
}
