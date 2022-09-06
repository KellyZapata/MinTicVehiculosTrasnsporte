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

        Repuesto IRepositorioRepuestos.AddRepuesto(Repuesto repuesto)
        {
            var repuestoAdicionada = _appContext.Repuestos.Add(repuesto);
            _appContext.SaveChanges();
            return repuestoAdicionada.Entity;
        }

        void IRepositorioRepuestos.DeleteRepuesto(int idRepuesto)
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

        Repuesto IRepositorioRepuestos.GetRepuesto(int idRepuesto)
        {
            return _appContext.Repuestos.FirstOrDefault(p => p.Id == idRepuesto);
        }

        Repuesto IRepositorioRepuestos.UpdateRepuesto(Repuesto repuesto)
        {
            var repuestoEncontrada = _appContext.Repuestos.FirstOrDefault(p => p.Id == repuesto.Id);
            if (repuestoEncontrada != null)
            {
                repuestoEncontrada.Verificacion = repuesto.Verificacion;
                repuestoEncontrada.Descripcion = repuesto.Descripcion;
                repuestoEncontrada.Precio = repuesto.Precio;
                _appContext.SaveChanges();
            }
            return repuestoEncontrada;
        }
    }
}
