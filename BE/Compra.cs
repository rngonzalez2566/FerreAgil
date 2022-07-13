using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Compra : Comprobante
    {
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaRecepcionAlmacen { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<Detalle_Compra> Items { get; set; }
    }
}
