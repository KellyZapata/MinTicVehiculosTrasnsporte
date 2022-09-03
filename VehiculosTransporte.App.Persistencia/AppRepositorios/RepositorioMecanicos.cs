using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioMecanicos: IRepositorioMecanicos
    {
        private readonly AppContext _appContext;

        public RepositorioMecanicos(AppContext appContext)
        {
            _appContext = appContext;
        }

        Mecanico IRepositorioMecanicos.AddMecanico(Mecanico mecanico)
        {
            var mecanicoAdicionado = _appContext.Mecanicos.Add(mecanico);
            _appContext.SaveChanges();
            return mecanicoAdicionado.Entity;
        }

        void IRepositorioMecanicos.DeleteMecanico(int idMecanico)
        {
            var mecanicoEncontrado = _appContext.Mecanicos.FirstOrDefault(m => m.Id == idMecanico);
            if (mecanicoEncontrado == null)
                return;
            _appContext.Mecanicos.Remove(mecanicoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Mecanico> IRepositorioMecanicos.GetMecanicos()
        {
            return _appContext.Mecanicos;
        }

        Mecanico IRepositorioMecanicos.GetMecanico(int idMecanico)
        {
            return _appContext.Mecanicos.FirstOrDefault(m => m.Id == idMecanico);
        }

        Mecanico IRepositorioMecanicos.UpdateMecanico(Mecanico mecanico)
        {
            var mecanicoEncontrado = _appContext.Mecanicos.FirstOrDefault(m => m.Id == mecanico.Id);
            if (mecanicoEncontrado != null)
            {
                mecanicoEncontrado.Nombres = mecanico.Nombres;
                mecanicoEncontrado.Apellidos = mecanico.Apellidos;
                mecanicoEncontrado.Cedula = mecanico.Cedula;
                mecanicoEncontrado.Numero_Telefono = mecanico.Numero_Telefono;
                mecanicoEncontrado.Direccion = mecanico.Direccion;
                _appContext.SaveChanges();
            }
            return mecanicoEncontrado;
        }
    }
}