using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioConductores: IRepositorioConductores
    {
        private readonly AppContext _appContext = new AppContext();

        public IEnumerable<Conductor> GetConductores()
        {
            return _appContext.Conductores;
        }

        public Conductor AddConductor(Conductor conductor)
        {
            var conductorAdicionado = _appContext.Conductores.Add(conductor);
            _appContext.SaveChanges();
            return conductorAdicionado.Entity;
        }

        public Conductor UpdateConductor(Conductor conductor)
        {
            var conductorEncontrado = _appContext.Conductores.FirstOrDefault(p => p.Id == conductor.Id);
            if (conductorEncontrado != null)
            {
                conductorEncontrado.Nombres = conductor.Nombres;
                conductorEncontrado.Apellidos = conductor.Apellidos;
                conductorEncontrado.Numero_Telefono = conductor.Numero_Telefono;
                conductorEncontrado.Cedula = conductor.Cedula;
                conductorEncontrado.VehiculoId = conductor.VehiculoId;
                _appContext.SaveChanges();
            }
            return conductorEncontrado;
        }

        public void DeleteConductor(int idConductor)
        {
            var conductorEncontrado = _appContext.Conductores.FirstOrDefault(p => p.Id == idConductor);
            if (conductorEncontrado == null)
                return;
            _appContext.Conductores.Remove(conductorEncontrado);
            _appContext.SaveChanges();
        }

        public Conductor GetConductor(int idConductor)
        {
            return _appContext.Conductores.FirstOrDefault(p => p.Id == idConductor);
        }
    }
}