using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public abstract class Componente
    {
        public string nombre { get; set; }
        public int id { get; set; }
        public abstract IList<Componente> Hijos { get; }
        public abstract void AgregarHijo(Componente componente);
        public abstract void VaciarHijos();
        public abstract void BorrarHijo(Componente componente);
        public TipoPermiso Permiso { get; set; }
        public override string ToString()
        {
            return nombre;
        }
    }
}
