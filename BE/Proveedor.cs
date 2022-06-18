using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Proveedor
    {
        public int id_Proveedor { get; set; }
        public string razonSocial { get; set; }
        public int cuit { get; set; }

        public string direccion { get; set; }
        public int telefono { get; set; }
        public string estado { get; set; }
    }
}
