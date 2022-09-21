using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioVerificaciones: IRepositorioVerificaciones
    {
        private readonly AppContext _appContext;

        public RepositorioVerificaciones(AppContext appContext)
        {
            _appContext = appContext;
        }

        Verificacion IRepositorioVerificaciones.AddVerificacion(Verificacion verificacion)
        {
            var verificacionAdicionada = _appContext.Verificaciones.Add(verificacion);
            _appContext.SaveChanges();
            return verificacionAdicionada.Entity;
        }

        void IRepositorioVerificaciones.DeleteVerificacion(int idVerificacion)
        {
            var verificacionEncontrada = _appContext.Verificaciones.FirstOrDefault(p => p.Id == idVerificacion);
            if (verificacionEncontrada == null)
                return;
            _appContext.Verificaciones.Remove(verificacionEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Verificacion> IRepositorioVerificaciones.GetVerificaciones()
        {
            return _appContext.Verificaciones.Include("Vehiculo").Include("Mecanico");
        }

        Verificacion IRepositorioVerificaciones.GetVerificacion(int idVerificacion)
        {
            return _appContext.Verificaciones.FirstOrDefault(p => p.Id == idVerificacion);
        }

        Verificacion IRepositorioVerificaciones.UpdateVerificacion(Verificacion verificacion)
        {
            var verificacionEncontrada = _appContext.Verificaciones.FirstOrDefault(p => p.Id == verificacion.Id);
            if (verificacionEncontrada != null)
            {
                verificacionEncontrada.VehiculoId = verificacion.VehiculoId;
                verificacionEncontrada.MecanicoId = verificacion.MecanicoId;
                verificacionEncontrada.Nivel_Aceite = verificacion.Nivel_Aceite;
                verificacionEncontrada.Nivel_Liquido_frenos = verificacion.Nivel_Liquido_frenos;
                verificacionEncontrada.Nivel_Refrigerante = verificacion.Nivel_Refrigerante;
                verificacionEncontrada.Nivel_Liquido_direccion = verificacion.Nivel_Liquido_direccion;
                _appContext.SaveChanges();
            }
            return verificacionEncontrada;
        }
    }
}
