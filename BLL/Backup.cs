using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class Backup
    {

        #region Gets
        public List<BE.Backup> GetBackups()
        {
            try
            {
                DAL.Backup DALbackup = new DAL.Backup();
                List<BE.Backup> backup = DALbackup.GetBackups();
                return backup;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener los backups."); }
        }

        public BE.Backup GetBackup(int idBackup)
        {
            try
            {
                DAL.Backup DALbackup = new DAL.Backup();
                BE.Backup backup = DALbackup.GetBackup(idBackup);
                return backup;
            }
            catch (Exception) { throw new Exception("Hubo un error al querer obtener el backup."); }
        }
        #endregion

        #region ABM
        public void GenerarBackup()
        {
            try
            {
                DAL.Backup DALbackup = new DAL.Backup();
                if (SingletonSesion.GetUsuario().id_usuario != 0)
                {
                    string baseN = ConfigurationManager.AppSettings["base"];
                    DateTime fecha = DateTime.Now;

                    string nombre = $"{baseN}_{fecha.ToString("dd-MM-yyyy-HH-mm-ss")}";

                    BE.Backup backup = new BE.Backup()
                    {
                        Base = baseN,
                        Ruta = ConfigurationManager.AppSettings["ruta"] + nombre + ".bak",
                        Nombre = nombre,
                        Fecha = fecha,
                        Usuario = SingletonSesion.GetUsuario(),
                    };
                    bool Realizado = DALbackup.GenerarBackup(backup);

                    if (Realizado)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            int backupId = DALbackup.AltaBackup(backup);

                            scope.Complete();
                        }
                    }
                    else throw new Exception("Hubo un error al generar backup");
                }
                else throw new Exception("El usuario temporal no puede generar Backup");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GenerarRestore(BE.Backup backup)
        {
            try
            {
                DAL.Backup DALbackup = new DAL.Backup();
                backup.Nombre = ConfigurationManager.AppSettings["base"];
                bool Realizado = DALbackup.GenerarRestore(backup);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
