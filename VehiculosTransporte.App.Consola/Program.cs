using System;
using VehiculosTransporte.App.Dominio;
using VehiculosTransporte.App.Persistencia;

namespace VehiculosTransporte.App.Consola
{
    class Program
    {
        private static IRepositorioPersonas _repoPersona = new RepositorioPersonas(new Persistencia.AppContext());
        private static IRepositorioMecanicos _repoMecanico = new RepositorioMecanicos(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Entity Framework!");
            AddPersona();
            GetAllPersonas();
            Console.WriteLine("-----------------");
            AddMecanico();
            GetAllPersonas();
            Console.WriteLine("-----------------");
            GetAllMecanicos();

        }

        private static void AddPersona(){
            var persona = new Persona{
                Nombres = "Persona",
                Apellidos = "1",
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

        private static void AddMecanico(){
            var mecanico = new Mecanico{
                Nombres = "Mecanico",
                Apellidos = "1",
                Cedula = "123456789",
                Numero_Telefono = "123456789",
                Direccion = "Calle 123"
            };
            _repoMecanico.AddMecanico(mecanico);
        }

        private static void BuscarMecanico(int idMecanico){
            var mecanico = _repoMecanico.GetMecanico(idMecanico);
            Console.WriteLine(mecanico.Nombres + " " + mecanico.Apellidos);
        }

        private static void EliminarMecanico(int idMecanico){
            _repoMecanico.DeleteMecanico(idMecanico);
        }

        private static void ActualizarMecanico(int idMecanico){
            var mecanico = _repoMecanico.GetMecanico(idMecanico);
            if (mecanico != null){
                mecanico.Nombres = "Juan";
                mecanico.Apellidos = "Perez 2";
                mecanico.Cedula = "123456789";
                mecanico.Numero_Telefono = "123456789";
                mecanico.Direccion = "Calle 123";
                _repoMecanico.UpdateMecanico(mecanico);
            }
        }

        private static void GetAllMecanicos(){
            var mecanicos = _repoMecanico.GetMecanicos();
            foreach (var mecanico in mecanicos){
                Console.WriteLine(mecanico.Nombres + " " + mecanico.Apellidos);
            }
        }
    }
}
