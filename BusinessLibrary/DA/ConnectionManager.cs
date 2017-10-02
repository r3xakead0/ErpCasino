using System.Configuration;
namespace ErpCasino.BusinessLibrary.DA
{
    public static class ConnectionManager
    {
        public static string ConexionLocal = ConfigurationManager.ConnectionStrings["ConexionLocal"].ConnectionString;
    }

}
