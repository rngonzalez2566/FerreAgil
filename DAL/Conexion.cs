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
        private static SqlConnection instancia = null;
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

        public SqlConnection conectar()
        {
            instancia = new SqlConnection();
            instancia.ConnectionString = conexion;
            instancia.Open();

            if (instancia.State == System.Data.ConnectionState.Closed)
            {
               instancia.Open();
            }

            return instancia;
        }

        public void desconectar()
        {
            if (instancia.State == System.Data.ConnectionState.Open)
            {

                instancia.Close();
            }
        }

    }
}
