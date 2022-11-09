using Gestion.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Gestion.Context
{
    public class GestionContext : DbContext
    {
        //Constructor para conexion de la base de datos 
        public GestionContext (DbContextOptions<GestionContext>options):base(options)

        {
            
        }
        //propriedade referente a entidad Cliente
       public DbSet<ClienteModel> Cliente { get; set; } //representando la tabla


    }
}
