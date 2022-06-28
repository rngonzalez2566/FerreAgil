using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Usuario : Acceso
    {
        #region Consultas
        private const string login = @"SELECT TOP 1 * FROM Usuario WHERE usuario = @user";
        private const string bloqueo_User = @"update usuario set contador = @contador where id_usuario = @idUser";
        private const string alta_User = "INSERT INTO USUARIO (usuario, email, contrasena, contador) " +
                                         " OUTPUT inserted.Id_usuario VALUES (@usuario, @email, @contrasena, 0) ";
        private const string get_User_User = "SELECT TOP 1 * FROM Usuario WHERE usuario = @user";
        private const string get_User_Email = "SELECT TOP 1 * FROM Usuario WHERE email = @email";
        private const string get_Users = "SELECT  id_usuario, usuario FROM Usuario";
        #endregion

        #region ABM
        public BE.Usuario Login(string xUsuario)
        {

            DataTable dt = new DataTable();
            BE.Usuario Usuario = new BE.Usuario();
            try
            {
                xCommandText = login;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@user", xUsuario);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    Usuario.id_usuario = int.Parse(dt.Rows[0]["id_usuario"].ToString());
                    Usuario.usuario = dt.Rows[0]["usuario"].ToString();
                    Usuario.contador = int.Parse(dt.Rows[0]["contador"].ToString());
                    Usuario.estado = dt.Rows[0]["estado"].ToString();
                    Usuario.email = dt.Rows[0]["email"].ToString();
                    Usuario.contrasena = dt.Rows[0]["contrasena"].ToString();
      
                }

                return Usuario;
            }
            catch
            {
                throw new Exception("Se produjo un error con la base de datos");
            }

        }

        public void BloquearUsuario(BE.Usuario usu)
        {
            try
            {
                xCommandText = bloqueo_User;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@contador", usu.contador);
                xParameters.Parameters.AddWithValue("@idUser", usu.id_usuario);
                executeNonQuery();

            }
            catch
            {

                throw new Exception("Se produjo un error con la base de datos");
            }
        }

        public int AltaUsuario(BE.Usuario usu)
        {
            try
            {
                xCommandText = alta_User;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@usuario", usu.usuario);
                xParameters.Parameters.AddWithValue("@email", usu.email);
                xParameters.Parameters.AddWithValue("@contrasena", usu.contrasena);


                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region Gets
        public BE.Usuario GetUsuario(string xUsuario)
        {
            DataTable dt = new DataTable();
            BE.Usuario Usuario = new BE.Usuario();

            try
            {
                xCommandText = get_User_User;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@user", xUsuario);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    Usuario.id_usuario = int.Parse(dt.Rows[0]["id_usuario"].ToString());
                    Usuario.usuario = dt.Rows[0]["usuario"].ToString();
                    Usuario.contador = int.Parse(dt.Rows[0]["contador"].ToString());
                    Usuario.estado = dt.Rows[0]["estado"].ToString();
                    Usuario.email = dt.Rows[0]["email"].ToString();
                    Usuario.contrasena = dt.Rows[0]["contrasena"].ToString();
                }
                else
                {
                    Usuario = null;
                }

                return Usuario;
            }
            catch
            {
                throw new Exception("Se produjo un error con la base de datos");
            }

        }

        public BE.Usuario GetUsuarioPorEmail(string xEmail)
        {
            DataTable dt = new DataTable();
            BE.Usuario Usuario = new BE.Usuario();

            try
            {
                xCommandText = get_User_Email;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@email", xEmail);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    Usuario.id_usuario = int.Parse(dt.Rows[0]["id_usuario"].ToString());
                    Usuario.usuario = dt.Rows[0]["usuario"].ToString();
                    Usuario.contador = int.Parse(dt.Rows[0]["contador"].ToString());
                    Usuario.estado = dt.Rows[0]["estado"].ToString();
                    Usuario.email = dt.Rows[0]["email"].ToString();
                    Usuario.contrasena = dt.Rows[0]["contrasena"].ToString();
                }
                else
                {
                    Usuario = null;
                }

                return Usuario;
            }
            catch
            {
                throw new Exception("Se produjo un error con la base de datos");
            }

        }

        public List<BE.Usuario> GetUsuarios()
        {
            try
            {
                Services.Encriptar encriptar = new Services.Encriptar();
                DataTable dt = new DataTable();
                List<BE.Usuario> lista = new List<BE.Usuario>();

                xCommandText = get_Users;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {

                        BE.Usuario usuario = new BE.Usuario();

                        usuario.id_usuario = int.Parse(fila[0].ToString());
                        usuario.usuario = encriptar.descencriptar(fila[1].ToString());


                        lista.Add(usuario);
                    }
                }


                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }


        }
        #endregion
    }
}
