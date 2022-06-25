using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Services
{
    public class SingletonSesion
    {
        private static Usuario _instance = null;
        private static object _Lock = new object();
        static IList<IIdiomaObserver> _observers = new List<IIdiomaObserver>();

        private SingletonSesion()
        {
        }

        public static Usuario Login(Usuario user, IIdioma idioma)
        {
            
            lock (_Lock)
            {
                if (_instance == null)
                {
                    _instance = user;
                    user.Idioma = idioma;
                }
            }

            return _instance;
        }

        public static Usuario GetUsuario()
        {
            return _instance;
        }

        public static Usuario Logout()
        {
            return _instance = null;
        }

        public static bool IsLogged()
        {
            return _instance != null;
        }

        public static void SuscribirObservador(IIdiomaObserver o) // Para suscribirse a un idioma.
        {
            _observers.Add(o);
        }
        public static void DesuscribirObservador(IIdiomaObserver o) // Para desuscribirse de un idioma.
        {
            _observers.Remove(o);
        }
        private static void Notificar(IIdioma idioma) // Actualizo el idioma del usuario.
        {
            foreach (var o in _observers)
            {
                o.UpdateLanguage(idioma);
                _instance.Idioma = idioma;
            }
        }
        public static void CambiarIdioma(IIdioma idioma) // Cambio de idioma.
        {
            Notificar(idioma);
        }
    }
}
