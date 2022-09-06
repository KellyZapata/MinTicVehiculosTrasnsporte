using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioJefeOperaciones
    {
        private readonly AppContext _appContext = new AppContext();

        public IEnumerable<JefeOperaciones> GetAllJefesOperaciones(){
            return _appContext.JefesOperaciones;
        }

        public JefeOperaciones AddJefeOperaciones(JefeOperaciones jefeoperaciones){
            var JefeOperacionesAdicionado = _appContext.JefesOperaciones.Add(jefeoperaciones);
            _appContext.SaveChanges();
            return JefeOperacionesAdicionado.Entity;
        }

        public JefeOperaciones UpdateAuxiliar(JefeOperaciones jefeoperaciones){
            var jefeoperacionesEncontrado = _appContext.JefesOperaciones.FirstOrDefault(p => p.Id == jefeoperaciones.Id);
            if (jefeoperacionesEncontrado != null){
                jefeoperacionesEncontrado.Nombres = jefeoperaciones.Nombres;
                jefeoperacionesEncontrado.Apellidos = jefeoperaciones.Apellidos;
                jefeoperacionesEncontrado.Cedula = jefeoperaciones.Cedula;
                jefeoperacionesEncontrado.Numero_Telefono = jefeoperaciones.Numero_Telefono;
                jefeoperacionesEncontrado.Direccion = jefeoperaciones.Direccion;
                _appContext.SaveChanges();
            }
            return jefeoperacionesEncontrado;
        }

        public void DeleteJefeOperaciones(int idJefeOperaciones){
            var jefeoperacionesEncontrado = _appContext.JefesOperaciones.FirstOrDefault(p => p.Id == idJefeOperaciones);
            if (jefeoperacionesEncontrado == null)
                return;
            _appContext.JefesOperaciones.Remove(jefeoperacionesEncontrado);
            _appContext.SaveChanges();
        }

        public JefeOperaciones GetJefeOperaciones(int idJefeOperaciones){
            return _appContext.JefesOperaciones.FirstOrDefault(p => p.Id == idJefeOperaciones);
        }
        
    }
}