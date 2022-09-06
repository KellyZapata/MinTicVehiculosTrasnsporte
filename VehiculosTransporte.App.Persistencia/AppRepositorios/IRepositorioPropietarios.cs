using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioPropietarios
    {
        IEnumerable<Propietario> GetPropietarios();
        Propietario AddPropietario(Propietario propietario);
        Propietario UpdatePropietario(Propietario propietario);
        void DeletePropietario(int idPropietario);
        Propietario GetPropietario(int idPropietario);
    }
}