using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Services.Idioma
{
    public class Idioma : IIdioma
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public bool Default { get; set; }
    }
}
