using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Comprobante
    {
        public int id { get; set; }
        public int Nro { get; set; }
        public string Detalle { get; set; }

        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        
    }
}
