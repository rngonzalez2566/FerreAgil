using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Idioma
{
    public class Etiqueta : IEtiqueta
    {
        public int id { get; set; }
        public string Nombre { get; set; }
    }
}
