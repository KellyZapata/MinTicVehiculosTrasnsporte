using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioAuxiliares
    {
        private readonly AppContext _appContext = new AppContext();

        public RepositorioAuxiliares(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Auxiliar> GetAllAuxiliares(){
            return _appContext.Auxiliares;
        }

        public Auxiliar AddAuxiliar(Auxiliar auxiliar){
            var auxiliarAdicionado = _appContext.Auxiliares.Add(auxiliar);
            _appContext.SaveChanges();
            return auxiliarAdicionado.Entity;
        }

        public Auxiliar UpdateAuxiliar(Auxiliar auxiliar){
            var auxiliarEncontrado = _appContext.Auxiliares.FirstOrDefault(p => p.Id == auxiliar.Id);
            if (auxiliarEncontrado != null){
                auxiliarEncontrado.Nombres = auxiliar.Nombres;
                auxiliarEncontrado.Apellidos = auxiliar.Apellidos;
                auxiliarEncontrado.Cedula = auxiliar.Cedula;
                auxiliarEncontrado.Numero_Telefono = auxiliar.Numero_Telefono;
                auxiliarEncontrado.Direccion = auxiliar.Direccion;
                _appContext.SaveChanges();
            }
            return auxiliarEncontrado;
        }

        public void DeleteAuxiliar(int idAuxiliar){
            var auxiliarEncontrado = _appContext.Auxiliares.FirstOrDefault(p => p.Id == idAuxiliar);
            if (auxiliarEncontrado == null)
                return;
            _appContext.Auxiliares.Remove(auxiliarEncontrado);
            _appContext.SaveChanges();
        }

        public Auxiliar GetAuxiliar(int idAuxiliar){
            return _appContext.Auxiliares.FirstOrDefault(p => p.Id == idAuxiliar);
        }
    }
}