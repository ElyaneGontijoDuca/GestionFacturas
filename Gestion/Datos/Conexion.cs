using System.Data.SqlClient;

namespace Gestion.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        //Constructor de conexion
        public Conexion()
        {   //obtenendo la cadena de conexion 
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            //obt
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;

          }
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
