using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class Conexion
    {
        private readonly string server;
        private readonly string baseDatos;
        public string conexion { get; set; }
        
        public Conexion ()
        {
            SqlConnection instancia = new SqlConnection();
            server = ConfigurationManager.AppSettings["server"];
            baseDatos = ConfigurationManager.AppSettings["base"];

            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder()
            {
                DataSource = server,
                InitialCatalog = baseDatos,
                IntegratedSecurity = true,
            };
            
            conexion = sqlConnectionString.ConnectionString;
        }

        

    }
}
