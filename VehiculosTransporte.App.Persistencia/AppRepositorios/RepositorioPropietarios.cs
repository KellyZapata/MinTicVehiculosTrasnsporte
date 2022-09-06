using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioPropietarios: IRepositorioPropietarios
    {
        private readonly AppContext _appContext;

        public RepositorioPropietarios(AppContext appContext)
        {
            _appContext = appContext;
        }

        Propietario IRepositorioPropietarios.AddPropietario(Propietario propietario)
        {
            var propietarioAdicionada = _appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return propietarioAdicionada.Entity;
        }

        void IRepositorioPropietarios.DeletePropietario(int idPropietario)
        {
            var propietarioEncontrada = _appContext.Propietarios.FirstOrDefault(p => p.Id == idPropietario);
            if (propietarioEncontrada == null)
                return;
            _appContext.Propietarios.Remove(propietarioEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Propietario> IRepositorioPropietarios.GetPropietarios()
        {
            return _appContext.Propietarios;
        }

        Propietario IRepositorioPropietarios.GetPropietario(int idPropietario)
        {
            return _appContext.Propietarios.FirstOrDefault(p => p.Id == idPropietario);
        }

        Propietario IRepositorioPropietarios.UpdatePropietario(Propietario propietario)
        {
            var propietarioEncontrada = _appContext.Propietarios.FirstOrDefault(p => p.Id == propietario.Id);
            if (propietarioEncontrada != null)
            {
                propietarioEncontrada.VehiculoId = propietario.VehiculoId;
                propietarioEncontrada.Nombres = propietario.Nombres;
                propietarioEncontrada.Apellidos = propietario.Apellidos;
                propietarioEncontrada.Numero_Telefono = propietario.Numero_Telefono;
                propietarioEncontrada.Direccion = propietario.Direccion;
                propietarioEncontrada.Cedula = propietario.Cedula;
                _appContext.SaveChanges();
            }
            return propietarioEncontrada;
        }
    }

}