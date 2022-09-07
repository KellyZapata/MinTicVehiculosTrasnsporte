using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioBus: IRepositorioBus
    {
        private readonly AppContext _appContext = new AppContext();

        public RepositorioBus(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Bus> GetAllBuses(){
            return _appContext.Buses;
        }

        public Bus AddBus(Bus bus){
            var busAdicionado = _appContext.Buses.Add(bus);
            _appContext.SaveChanges();
            return busAdicionado.Entity;
        }

        public Bus UpdateBus(Bus bus){
            var busEncontrado = _appContext.Buses.FirstOrDefault(p => p.Id == bus.Id);
            if (busEncontrado != null){
                busEncontrado.Placa = bus.Placa;
                busEncontrado.Marca = bus.Marca;
                busEncontrado.Modelo = bus.Modelo;
                busEncontrado.Expiracion_tenicomecanica = bus.Expiracion_tenicomecanica;
                busEncontrado.Expiracion_soat = bus.Expiracion_soat;
                busEncontrado.Expiracion_seguro_contractual = bus.Expiracion_seguro_contractual;
                busEncontrado.Expiracion_extra_contractual = bus.Expiracion_extra_contractual;
                _appContext.SaveChanges();
            }
            return busEncontrado;
        }

        public void DeleteBus(int idBus){
            var busEncontrado = _appContext.Buses.FirstOrDefault(p => p.Id == idBus);
            if (busEncontrado == null)
                return;
            _appContext.Buses.Remove(busEncontrado);
            _appContext.SaveChanges();
        }

        public Bus GetBus(int idBus){
            return _appContext.Buses.FirstOrDefault(p => p.Id == idBus);
        }
    }
}