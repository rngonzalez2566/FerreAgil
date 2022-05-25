using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SingletonSesion
    {
        private static Usuario _instance = null;
        private static object _Lock = new object();

        private SingletonSesion()
        {
        }

        public static Usuario Login(Usuario user)
        {
            
            lock (_Lock)
            {
                if (_instance == null)
                {
                    _instance = user;
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
    }
}
