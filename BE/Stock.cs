using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Stock
    {
        public int id { get; set; }
        public Producto Producto { get; set; }
        public float Cantidad { get; set; }
        public int Condicion { get; set; }
    }
}
