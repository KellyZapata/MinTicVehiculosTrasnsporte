using System;
using VehiculosTransporte.App.Dominio;
using VehiculosTransporte.App.Persistencia;

namespace VehiculosTransporte.App.Consola
{
    class Program
    {
        private static IRepositorioPersonas _repoPersona = new RepositorioPersonas(new Persistencia.AppContext());
        private static IRepositorioMecanicos _repoMecanico = new RepositorioMecanicos(new Persistencia.AppContext());

        private static IRepositorioVerificaciones _repoVerificacion = new RepositorioVerificaciones(new Persistencia.AppContext());
        private static IRepositorioRepuestos _repoRepuesto = new RepositorioRepuestos(new Persistencia.AppContext());
        private static IRepositorioVehiculos _repoVehiculo = new RepositorioVehiculos(new Persistencia.AppContext());
        private static IRepositorioBus _repoBus = new RepositorioBus(new Persistencia.AppContext());
        private static IRepositorioMicrobuses _repoMicrobus = new RepositorioMicrobuses(new Persistencia.AppContext());

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
            AddVehiculo();
            AddBus();
            AddMicrobus();
            AddVerificacion();
            GetAllVerificaciones();
            AddRepuesto();
            GetAllRepuestos();
            Console.WriteLine("-----------------");

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

        private static void AddMicrobus(){
            var microbus = new Microbus{
                Placa = "123456",
                Marca = "Marca",
                Modelo = "Modelo",
                Expiracion_tenicomecanica =DateTime.Now,
                Expiracion_soat =DateTime.Now,
                Expiracion_seguro_contractual =DateTime.Now,
                Expiracion_extra_contractual =DateTime.Now
            };
            _repoMicrobus.AddMicrobus(microbus);
        }

        private static void AddVehiculo(){
            var vehiculo = new Vehiculo{
                Placa = "123456",
                Marca = "Marca",
                Modelo = "Modelo",
                Expiracion_tenicomecanica = DateTime.Now,
                Expiracion_soat = DateTime.Now,
                Expiracion_seguro_contractual = DateTime.Now,
                Expiracion_extra_contractual = DateTime.Now
            };
            _repoVehiculo.AddVehiculo(vehiculo);
        }
        private static void AddBus(){
            var bus = new Bus{
                Placa = "123456",
                Marca = "Marca",
                Modelo = "Modelo",
                Expiracion_tenicomecanica = DateTime.Now,
                Expiracion_soat = DateTime.Now,
                Expiracion_seguro_contractual = DateTime.Now,
                Expiracion_extra_contractual = DateTime.Now
            };
            _repoBus.AddBus(bus);
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

         private static void AddVerificacion(){
            var verificacion = new Verificacion{
                VehiculoId = 1,
                MecanicoId = 2,
                Nivel_Aceite = "6 Litros",
                Nivel_Liquido_frenos = "2 Litros",
                Nivel_Refrigerante = "10 Litros",
                Nivel_Liquido_direccion = "5 Litros",
            };
            _repoVerificacion.AddVerificacion(verificacion);
        }

        private static void BuscarVerificacion(int idVerificacion){
            var verificacion = _repoVerificacion.GetVerificacion(idVerificacion);
            Console.WriteLine(verificacion.Vehiculo + " " + verificacion.Mecanico);
        }

        private static void EliminarVerificacion(int idVerificacion){
            _repoVerificacion.DeleteVerificacion(idVerificacion);
        }

        private static void ActualizarVerificacion(int idVerificacion){
            var verificacion = _repoVerificacion.GetVerificacion(idVerificacion);
            if (verificacion != null){
                verificacion.VehiculoId = 1;
                verificacion.MecanicoId = 9;
                verificacion.Nivel_Aceite = "8 Litros";
                verificacion.Nivel_Liquido_frenos = "3 Litros";
                verificacion.Nivel_Refrigerante = "12 Litros";
                verificacion.Nivel_Liquido_direccion = "6 Litros";
                _repoVerificacion.UpdateVerificacion(verificacion);
            }
        }

        private static void GetAllVerificaciones(){
            var verificaciones = _repoVerificacion.GetVerificaciones();
            foreach (var verificacion in verificaciones){
                 Console.WriteLine(verificacion.Vehiculo + " " + verificacion.MecanicoId);
            }
        }

         private static void AddRepuesto(){
            var repuesto = new Repuesto{
                VerificacionId = 1,
                Descripcion = "primer mantenimiento",
                Precio = 500,
            };
            _repoRepuesto.AddRepuesto(repuesto);
        }

        private static void BuscarRepuesto(int idRepuesto){
            var repuesto = _repoRepuesto.GetRepuesto(idRepuesto);
            Console.WriteLine(repuesto.VerificacionId + " " + repuesto.Descripcion);
        }

        private static void EliminarRepuesto(int idRepuesto){
            _repoRepuesto.DeleteRepuesto(idRepuesto);
        }

        private static void ActualizarRepuesto(int idRepuesto){
            var repuesto = _repoRepuesto.GetRepuesto(idRepuesto);
            if (repuesto != null){
                repuesto.VerificacionId = 1;
                repuesto.Descripcion = "segundo mantenimiento";
                repuesto.Precio = 600;
                _repoRepuesto.UpdateRepuesto(repuesto);
            }
        }

        private static void GetAllRepuestos(){
            var repuestos = _repoRepuesto.GetRepuestos();
            foreach (var repuesto in repuestos){
                 Console.WriteLine(repuesto.VerificacionId + " " + repuesto.Descripcion);
            }
        }
    }
}
