using System;
using VehiculosTransporte.App.Dominio;
using VehiculosTransporte.App.Persistencia;

namespace VehiculosTransporte.App.Consola
{
    class Program
    {
        private static IRepositorioPersonas _repoPersona = new RepositorioPersonas(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Entity Framework!");
            AddPersona();
            GetAllPersonas();
            ActualizarPersona(3);
            BuscarPersona(3);
            // EliminarPersona(2);
        }

        private static void AddPersona(){
            var persona = new Persona{
                Nombres = "Juan",
                Apellidos = "Perez",
                Cedula = "123456789",
                Numero_Telefono = "123456789",
                Direccion = "Calle 123"
            };
            _repoPersona.AddPersona(persona);
        }

        private static void BuscarPersona(int idPersona){
            var persona = _repoPersona.GetPersona(idPersona);
            Console.WriteLine(persona.Nombres + " " + persona.Apellidos);
        }

        private static void EliminarPersona(int idPersona){
            _repoPersona.DeletePersona(idPersona);
        }

        private static void ActualizarPersona(int idPersona){
            var persona = _repoPersona.GetPersona(idPersona);
            if (persona != null){
                persona.Nombres = "Juan";
                persona.Apellidos = "Perez 2";
                persona.Cedula = "123456789";
                persona.Numero_Telefono = "123456789";
                persona.Direccion = "Calle 123";
                _repoPersona.UpdatePersona(persona);
            }
        }

        private static void GetAllPersonas(){
            var personas = _repoPersona.GetPersonas();
            foreach (var persona in personas){
                Console.WriteLine(persona.Nombres + " " + persona.Apellidos);
            }
        }
    }
}
