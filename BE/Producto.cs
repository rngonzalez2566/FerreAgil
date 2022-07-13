using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Producto
    {
        public int id_Producto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public UnidadMedida unidadMedida  { get; set; }
        public int leadTimeCompra { get; set; }
        public float PrecioUnitario { get; set; }
        public float consumoMensual { get; set; }
        public float consumoTrimestral { get; set; }
        public float consumoSemestral { get; set; }
        public float stockMinimo { get; set; }
        public float stockOptimo { get; set; }
        public string estado { get; set; }


    }
}
    