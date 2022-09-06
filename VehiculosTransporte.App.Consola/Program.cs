﻿using System;
using VehiculosTransporte.App.Dominio;
using VehiculosTransporte.App.Persistencia;

namespace VehiculosTransporte.App.Consola
{
    class Program
    {
        private static IRepositorioPersonas _repoPersona = new RepositorioPersonas(new Persistencia.AppContext());
        private static IRepositorioMecanicos _repoMecanico = new RepositorioMecanicos(new Persistencia.AppContext());

        private static IRepositorioVerificaciones _repoVerificacion = new RepositorioVerificaciones(new Persistencia.AppContext());
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
            AddVerificacion();
            GetAllVerificaciones();
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
            var verificacion = new verificacion{
                Vehiculo = "Vehiculo",
                Mecanico = "1",
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
            _repoPersona.DeleteVerificacion(idVerificacion);
        }

        private static void ActualizarVerificacion(int idVerificacion){
            var verificacion = _repoVerificacion.GetVerificacion(idVerificacion);
            if (verificacion != null){
                verificacion.Vehiculo = " Nissan";
                verificacion.Mecanico = "2";
                verificacion.Nivel_Aceite = "8 Litros";
                verificacion.Nivel_Liquido_frenos = "3 Litros";
                verificacion.Nivel_Refrigerante = "12 Litros";
                verificacion.Nivel_Liquido_direccion = "6 Litros";
                _repoVerificacion..UpdateVerificacion(verificacion);
            }
        }

        private static void GetAllVerificaciones(){
            var verificaciones = _repoPersona.GetVerificaciones();
            foreach (var verificacion in verificaciones){
                 Console.WriteLine(verificacion.Vehiculo + " " + verificacion.Mecanico);
            }
        }

    }
}
