using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Services.Idioma
{
    public class sesionIdioma
    {

        static IList<IIdiomaObserver> _observers = new List<IIdiomaObserver>();

        private Idioma _idioma { get; set; }

        public Idioma Idioma
        {
            get
            {
                return _idioma;
            }
        }

        public void createInstance(Idioma idio)
        {
            _idioma = idio;
        }

        public static void SuscribirObservador(IIdiomaObserver o) // Para suscribirse a un idioma.
        {
            _observers.Add(o);
        }
        public static void DesuscribirObservador(IIdiomaObserver o) // Para desuscribirse de un idioma.
        {
            _observers.Remove(o);
        }
        private static void Notificar(IIdioma idioma) // Actualizo el idioma de la sesion
        {
            foreach (var o in _observers)
            {
                o.UpdateLanguage(idioma);
            }
        }
        public static void CambiarIdioma(IIdioma idioma) // Cambio de idioma.
        {
            Notificar(idioma);
        }
    }
}
