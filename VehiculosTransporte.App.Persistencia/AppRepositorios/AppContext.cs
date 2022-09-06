using Microsoft.EntityFrameworkCore;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas{get;set;}
        public DbSet<Mecanico> Mecanicos{get;set;}
        public DbSet<Auxiliar> Auxiliares{get;set;}
        public DbSet<Verificacion> Verificaciones{get;set;}
        public DbSet<Repuesto> Repuestos{get;set;}
        public DbSet<Vehiculo> Vehiculos{get;set;}
        public DbSet<Propietario> Propietarios{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=VehiculosTransporte");
            }
        }
    }
}
