using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {

        public BE.Usuario Login(string xUsuario, string password)
        {
            Encriptar Encripta = new Encriptar();
            DAL.Usuario usu = new DAL.Usuario();

            if (SingletonSesion.IsLogged())
                throw new Exception("Ya hay una sesión iniciada");

            if (xUsuario == "") throw new Exception("Usuario en blanco");

            if (password == "") throw new Exception("Password en blanco");

            BE.Usuario user = usu.Login(Encripta.encriptar(true, xUsuario));
            if (user == null) throw new Exception("Usuario Invalido");

            if (user.contador >= 3)
            {
                throw new Exception("El Usuario se encuentra Bloqueado");
            }
            else
            {
                if (!Encripta.encriptar(false, password).Equals(user.contrasena))
                {
                    if (BloquearUsuario(user) >= 3)
                    {
                        throw new Exception("Se alcanzo el maximo de intentos fallidos, se bloquea el usuario");
                    }
                    else throw new Exception("Password invalida");

                }

                else
                {

                    SingletonSesion.Login(user);
                    return user;
                }
            }


        }

        public int BloquearUsuario(BE.Usuario Usu)
        {
            //BLL.Bitacora bit = new BLL.Bitacora();
            Encriptar Encripta = new Encriptar();
            //BLL.DigitoVerificador Dv = new BLL.DigitoVerificador();
            DAL.Usuario usuario = new DAL.Usuario();

            Usu.contador = Usu.contador + 1;
            //if (Usu.contador >= 3)
            //{
            //    string xTexto = bit.registrarBitacora(Usu, "Se bloqueo por intentos fallidos el usuario: " + Encripta.descencriptar(Usu.usuario), 1, DateTime.Now).ToString();
            //}
            //else
            //{
            //    string xTexto = bit.registrarBitacora(Usu, "Intento Fallido de ingreso del usuario: " + Encripta.descencriptar(Usu.usuario), 1, DateTime.Now).ToString();
            //}
            //Usu.DVH = Dv.CalcularDV("usuario", Usu);
            usuario.BloquearUsuario(Usu);
            return Usu.contador;
        }
    }
}
