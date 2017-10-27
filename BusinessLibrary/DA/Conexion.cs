using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Conexion
    {

        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Servidor { get; set; }
        public string BaseDatos { get; set; }

        public Conexion()
        {
            string cnnStr = ConnectionManager.ConexionLocal;

            var builder = new SqlConnectionStringBuilder(cnnStr);

            Usuario = builder.UserID;
            Clave = builder.Password;
            Servidor = builder.InitialCatalog;
            BaseDatos = builder.Password;
        }
    }

}
