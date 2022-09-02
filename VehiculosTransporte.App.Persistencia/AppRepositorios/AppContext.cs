using Microsoft.EntityFrameworkCore;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public class Appcontext : DbContext
    {
        public DbSet<Persona> Personas{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=VehiculosTransporte");
            }
        }
    }
}
