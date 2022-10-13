using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public  class Backup
    {
        public int Id_Backup { get; set; }
        public string Base { get; set; }
        public string Ruta { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }
    }
}
