using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
   public class Usuario : Acceso
    {
        private const string login = @"SELECT TOP 1 * FROM Usuario WHERE usuario = @user";
        private const string bloqueo_User = @"update usuario set contador = @contador where id_usuario = @idUser";

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
                    //Usuario.DVH = int.Parse(dt.Rows[0]["DVH"].ToString());
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

    }
}
