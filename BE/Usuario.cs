using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int contador { get; set; }
        public string email { get; set; }
        public string estado { get; set; }
        public IIdioma Idioma { get; set; }
    }
}
