using Microsoft.EntityFrameworkCore;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas{get;set;}
        public DbSet<Mecanico> Mecanicos{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=VehiculosTransporte");
            }
        }
    }
}
