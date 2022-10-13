using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Transactions;

namespace BLL
{
    public class Usuario
    {
        DAL.Idioma idioma = new DAL.Idioma();
        Encriptar Encripta = new Encriptar();
        DAL.Usuario usuario = new DAL.Usuario();
        DigitoVerificador dv = new DigitoVerificador();
        DAL.DigitoVerificador dvDAL = new DAL.DigitoVerificador(); 
        BLL.Bitacora bit = new BLL.Bitacora();

        #region ABM
        public BE.Usuario Login(string xUsuario, string password)
        {
          

            if (SingletonSesion.IsLogged())
                throw new Exception("Ya hay una sesión iniciada");

            if (xUsuario == "") throw new Exception("Usuario en blanco");

            if (password == "") throw new Exception("Password en blanco");

            BE.Usuario user = usuario.Login(Encripta.encriptar(true, xUsuario));
            if (user == null) throw new Exception("Usuario Invalido");

            if (user.contador >= 3)
            {
                bit.RegistrarBitacora("EL USUARIO SE ENCUENTRA BLOQUEADO: " + Encripta.descencriptar(user.usuario), "ALTA");
                throw new Exception("El Usuario se encuentra Bloqueado");
            }
            else
            {
                if (!Encripta.encriptar(false, password).Equals(user.contrasena))
                {
                    if (BloquearUsuario(user) >= 3)
                    {
                        bit.RegistrarBitacora("USUARIO BLOQUEADO: " + Encripta.descencriptar(user.usuario), "ALTA");
                        throw new Exception("Se alcanzo el maximo de intentos fallidos, se bloquea el usuario");
                    }
                    else
                    {
                        bit.RegistrarBitacora("PASSWORD INVALIDA PARA USUARIO: " + Encripta.descencriptar(user.usuario), "ALTA");
                        throw new Exception("Password invalida");
                    }
                        

                }

                else
                {

                    SingletonSesion.Login(user, idioma.ObtenerIdiomaDefault());
                    bit.RegistrarBitacora("USUARIO LOGUEADO", "ALTA");
                    return user;
                }
            }


        }

        public int BloquearUsuario(BE.Usuario Usu)
        {
            
            Encriptar Encripta = new Encriptar();
          

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    Usu.contador = Usu.contador + 1;
                    Usu.DVH = dv.CalcularDV(Usu);
                    
                    usuario.BloquearUsuario(Usu);
                    dvDAL.AltaDVV("Usuario");

                    scope.Complete();

                    return Usu.contador;
                }
            }
            catch
            {
                throw new Exception("Ha ocurrido un error al intentar bloquear el usuario");
            }
          
        }

        public void Logout()
        {
            bit.RegistrarBitacora("USUARIO DESLOGUEADO", "ALTA");
            SingletonSesion.Logout();
        }

        public int AltaUsuario(BE.Usuario Usu)
        {


            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ValidarUsuario(Usu);
                    string xPassword = GeneraClave();
                    Usu.usuario = Encripta.encriptar(true, Usu.usuario);
                    Usu.contrasena = Encripta.encriptar(false, xPassword);
                    Usu.contador = 0;
                    if (usuario.GetUsuario(Usu.usuario) != null) throw new Exception("El Usuario ya se encuentra Registrado");
                    if (usuario.GetUsuarioPorEmail(Usu.email) != null) throw new Exception("El Mail ya se encuentra registrado");
                    Usu.DVH = dv.CalcularDV(Usu);
                    int idUsuario = usuario.AltaUsuario(Usu);
                    EnviaMailClave(Encripta.descencriptar(Usu.usuario), xPassword);

                    dvDAL.AltaDVV("Usuario");

                    bit.RegistrarBitacora("SE DIO DE ALTA EL USUARIO: " + Encripta.descencriptar(Usu.usuario), "ALTA");

                    scope.Complete();

                    return idUsuario;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region Validaciones
        private void ValidarUsuario(BE.Usuario Usu)
        {
            if ((ValidaEmail(Usu.email) == false) || string.IsNullOrWhiteSpace(Usu.email)) throw new Exception("Mail vacio o con formato incorrecto");
            if (string.IsNullOrEmpty(Usu.usuario)) throw new Exception("El usuario es requerido");

        }
        #endregion

        #region Utilidades
        private string GeneraClave()
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 8;
            string Password = "";
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                Password += letra.ToString();
            }
            return Password;
        }
        private void EnviaMailClave(string xUsuario, string xPassword)
        {

            string texto = "Contraseña: " + xPassword;

            StreamWriter fichero; //Clase que representa un fichero
            fichero = File.CreateText("C:\\usuario_Campo\\" + xUsuario + ".txt"); //Creamos un fichero
            fichero.WriteLine(texto); // Lo mismo que cuando escribimos por consola
            fichero.Close();


        }

        private bool ValidaEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0) return true;
                else return false;
            }
            else return false;
        }
        #endregion

        #region Gets
        public List<BE.Usuario> GetUsuarios()
        {
            try
            {
                DAL.Usuario usuario = new DAL.Usuario();
                return usuario.GetUsuarios();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener Unidades de Medida");
            }
        }
        #endregion
    }
}
