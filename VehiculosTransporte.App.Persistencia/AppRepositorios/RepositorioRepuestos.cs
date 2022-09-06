using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioRepuestos: IRepositorioRepuestos
    {
        private readonly AppContext _appContext;

        public RepositorioRepuestos(AppContext appContext)
        {
            _appContext = appContext;
        }

        Persona IRepositorioRepuestos.AddRepuesto(Repuesto repuesto)
        {
            var repuestoAdicionada = _appContext.Repuestos.Add(repuesto);
            _appContext.SaveChanges();
            return repuestoAdicionada.Entity;
        }

        void IRepositorioRepuesto.DeleteRepuesto(int idRepuesto)
        {
            var repuestoEncontrada = _appContext.Repuestos.FirstOrDefault(p => p.Id == idRepuesto);
            if (repuestoEncontrada == null)
                return;
            _appContext.Repuestos.Remove(repuestoEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Repuesto> IRepositorioRepuestos.GetRepuestos()
        {
            return _appContext.Repuestos;
        }

        Persona IRepositorioRepuestos.GetRepuesto(int idRepuesto)
        {
            return _appContext.Repuestos.FirstOrDefault(p => p.Id == idRepuesto);
        }

        Persona IRepositorioRepuestos.UpdateRepuesto(Repuesto repuesto)
        {
            var repuestoEncontrada = _appContext.Repuestos.FirstOrDefault(p => p.Id == repuesto.Id);
            if (repuestoEncontrada != null)
            {
                repuestoEncontrada.Verificacion = repuesto.Verificacion;
                repuestoEncontrada.Despcripcion = repuesto.Despcripcion;
                repuestoEncontrada.Precio = repuesto.Precio;
                
                _appContext.SaveChanges();
            }
            return repuestoEncontrada;
        }
    }
}
