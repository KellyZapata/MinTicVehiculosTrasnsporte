using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioConductores: IRepositorioConductores
    {
        private readonly AppContext _appContext;

        public RepositorioConductores(AppContext appContext)
        {
            _appContext = appContext;
        }

        Conductor IRepositorioConductores.AddConductor(Conductor conductor)
        {
            var conductorAdicionada = _appContext.Conductores.Add(conductor);
            _appContext.SaveChanges();
            return conductorAdicionada.Entity;
        }

        void IRepositorioConductores.DeleteConductor(int idConductor)
        {
            var conductorEncontrada = _appContext.Conductores.FirstOrDefault(p => p.Id == idConductor);
            if (conductorEncontrada == null)
                return;
            _appContext.Conductores.Remove(conductorEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Conductor> IRepositorioConductores.GetConductores()
        {
            return _appContext.Conductores;
        }

        Conductor IRepositorioConductores.GetConductor(int idConductor)
        {
            return _appContext.Conductores.FirstOrDefault(p => p.Id == idConductor);
        }

        Conductor IRepositorioConductores.UpdateConductor(Conductor conductor)
        {
            var conductorEncontrada = _appContext.Conductores.FirstOrDefault(p => p.Id == conductor.Id);
            if (conductorEncontrada != null)
            {
                conductorEncontrada.VehiculoId = conductor.VehiculoId;
                conductorEncontrada.Nombres = conductor.Nombres;
                conductorEncontrada.Apellidos = conductor.Apellidos;
                conductorEncontrada.Numero_Telefono = conductor.Numero_Telefono;
                conductorEncontrada.Direccion = conductor.Direccion;
                conductorEncontrada.Cedula = conductor.Cedula;
                _appContext.SaveChanges();
            }
            return conductorEncontrada;
        }
    }
}