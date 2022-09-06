using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioVehiculos
    {
        IEnumerable<Vehiculo> GetVehiculos();
        Vehiculo AddVehiculo(Vehiculo vehiculo);
        Vehiculo UpdateVehiculo(Vehiculo vehiculo);
        void DeleteVehiculo(int idVehiculo);
        Vehiculo GetVehiculo(int idVehiculo);
    }
}