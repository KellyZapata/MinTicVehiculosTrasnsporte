using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioVehiculos: IRepositorioVehiculos{
        private readonly AppContext _appContext;

        public RepositorioVehiculos(AppContext appContext){
            _appContext = appContext;
        }

        Vehiculo IRepositorioVehiculos.AddVehiculo(Vehiculo vehiculo){
            var vehiculoAdicionado = _appContext.Vehiculos.Add(vehiculo);
            _appContext.SaveChanges();
            return vehiculoAdicionado.Entity;
        }

        void IRepositorioVehiculos.DeleteVehiculo(int idVehiculo){
            var vehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(p => p.Id == idVehiculo);
            if (vehiculoEncontrado == null)
                return;
            _appContext.Vehiculos.Remove(vehiculoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Vehiculo> IRepositorioVehiculos.GetVehiculos(){
            return _appContext.Vehiculos;
        }

        Vehiculo IRepositorioVehiculos.GetVehiculo(int idVehiculo){
            return _appContext.Vehiculos.FirstOrDefault(p => p.Id == idVehiculo);
        }

        Vehiculo IRepositorioVehiculos.UpdateVehiculo(Vehiculo vehiculo){
            var vehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(p => p.Id == vehiculo.Id);
            if (vehiculoEncontrado != null){
                vehiculoEncontrado.Placa = vehiculo.Placa;
                vehiculoEncontrado.Marca = vehiculo.Marca;
                vehiculoEncontrado.Modelo = vehiculo.Modelo;
                vehiculoEncontrado.Expiracion_tenicomecanica = vehiculo.Expiracion_tenicomecanica;
                vehiculoEncontrado.Expiracion_soat = vehiculo.Expiracion_soat;
                vehiculoEncontrado.Expiracion_seguro_contractual = vehiculo.Expiracion_seguro_contractual;
                vehiculoEncontrado.Expiracion_extra_contractual = vehiculo.Expiracion_extra_contractual;
                _appContext.SaveChanges();
            }
            return vehiculoEncontrado;
        }
    }
}