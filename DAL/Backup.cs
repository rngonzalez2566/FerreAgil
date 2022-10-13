using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class Backup : Acceso
    {
        #region Consultas
        private const string alta_backup = "INSERT INTO dbo.[Backup] (Nombre, Fecha, Ruta, id_usuario) OUTPUT inserted.Id_backup VALUES (@nombre, @fecha, @ruta, @usuario)";
        private const string get_Backups = "SELECT Id_backup, Nombre, Ruta, Fecha, id_usuario FROM dbo.[Backup] ORDER BY Fecha DESC";
        private const string get_Backup = "SELECT Id_backup, Nombre, Ruta, Fecha, id_usuario FROM dbo.[Backup] WHERE Id_backup = @id";
        #endregion

        #region Gets

        public List<BE.Backup> GetBackups()
        {
            try
            {
                DataTable dt = new DataTable();
                List<BE.Backup> listaBackups = new List<BE.Backup>();

                xCommandText = get_Backups;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {

                        Usuario us = new Usuario();
                        BE.Backup backup = new BE.Backup();

                        backup.Id_Backup = int.Parse(fila[0].ToString());
                        backup.Nombre = fila[1].ToString();
                        backup.Ruta = fila[2].ToString();
                        backup.Fecha = DateTime.Parse(fila[3].ToString());
                        backup.Usuario = us.GetUsuarioByID(int.Parse(fila[4].ToString()));

                        listaBackups.Add(backup);
                    }
                }


                return listaBackups;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }

        }

        public BE.Backup GetBackup(int back)
        {

            try
            {
                DataTable dt = new DataTable();
                BE.Backup backup = new BE.Backup();

                xCommandText = get_Backup;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@id", back);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {

                    Usuario us = new Usuario();

                    backup.Id_Backup = int.Parse(dt.Rows[0]["Id_backup"].ToString());
                    backup.Nombre = dt.Rows[0]["Nombre"].ToString();
                    backup.Ruta = dt.Rows[0]["Ruta"].ToString();
                    backup.Fecha = DateTime.Parse(dt.Rows[0]["Fecha"].ToString());
                    backup.Usuario = us.GetUsuarioByID(int.Parse(dt.Rows[0]["id_usuario"].ToString()));
                }

                return backup;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion

        #region ABM
        public int AltaBackup(BE.Backup backup)
        {
            try
            {
                xCommandText = alta_backup;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@nombre", backup.Nombre);
                xParameters.Parameters.AddWithValue("@fecha", backup.Fecha);
                xParameters.Parameters.AddWithValue("@ruta", backup.Ruta);
                xParameters.Parameters.AddWithValue("@usuario", backup.Usuario.id_usuario);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public bool GenerarBackup(BE.Backup backup)
        {
            bool realizado = false;
            try
            {
                xCommandText = $"USE [master] BACKUP DATABASE [{backup.Base}] TO DISK = '{backup.Ruta}' " +
                                    $"WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Backup FerreAgil'";

                ExecuteNonQueryNonTransaction();

                realizado = true;
                return realizado;
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public bool GenerarRestore(BE.Backup backup)
        {
            bool realizado = false;
            try
            {
                xCommandText = $"USE [master] " +
                                        $"ALTER DATABASE [{backup.Nombre}] SET OFFLINE WITH ROLLBACK IMMEDIATE  " +
                                        $"RESTORE DATABASE [{backup.Nombre}] FROM DISK = '{backup.Ruta}' WITH REPLACE  " +
                                        $"ALTER DATABASE [{backup.Nombre}] SET ONLINE";

                ExecuteNonQueryNonTransaction();

                realizado = true;
                return realizado;
            }
            catch
            {
                throw new Exception("No se pudo generar el Restore del Backup seleccionado");
            }
        }
        #endregion

    }
}
