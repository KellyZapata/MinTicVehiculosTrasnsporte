using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioBus
    {
        IEnumerable<Bus> GetAllBuses();
        Bus AddBus(Bus bus);
        Bus UpdateBus(Bus bus);
        void DeleteBus(int idBus);
        Bus GetBus(int idBus);
    }
}