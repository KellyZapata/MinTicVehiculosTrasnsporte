using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioPersonas: IRepositorioPersonas
    {
        private readonly AppContext _appContext;

        public RepositorioPersonas(AppContext appContext)
        {
            _appContext = appContext;
        }

        Persona IRepositorioPersonas.AddPersona(Persona persona)
        {
            var personaAdicionada = _appContext.Personas.Add(persona);
            _appContext.SaveChanges();
            return personaAdicionada.Entity;
        }

        void IRepositorioPersonas.DeletePersona(int idPersona)
        {
            var personaEncontrada = _appContext.Personas.FirstOrDefault(p => p.Id == idPersona);
            if (personaEncontrada == null)
                return;
            _appContext.Personas.Remove(personaEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Persona> IRepositorioPersonas.GetPersonas()
        {
            return _appContext.Personas.Include("Vehiculo");
        }

        Persona IRepositorioPersonas.GetPersona(int idPersona)
        {
            return _appContext.Personas.FirstOrDefault(p => p.Id == idPersona);
        }

        Persona IRepositorioPersonas.UpdatePersona(Persona persona)
        {
            var personaEncontrada = _appContext.Personas.FirstOrDefault(p => p.Id == persona.Id);
            if (personaEncontrada != null)
            {
                personaEncontrada.Nombres = persona.Nombres;
                personaEncontrada.Apellidos = persona.Apellidos;
                personaEncontrada.Cedula = persona.Cedula;
                personaEncontrada.Numero_Telefono = persona.Numero_Telefono;
                personaEncontrada.Direccion = persona.Direccion;
                personaEncontrada.Discriminator = persona.Discriminator;
                personaEncontrada.VehiculoId = persona.VehiculoId;
                _appContext.SaveChanges();
            }
            return personaEncontrada;
        }
    }
}