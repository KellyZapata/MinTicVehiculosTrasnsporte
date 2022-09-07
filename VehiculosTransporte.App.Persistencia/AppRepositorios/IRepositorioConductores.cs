using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioConductores
    {
        IEnumerable<Conductor> GetConductores();
        Conductor AddConductor(Conductor conductor);
        Conductor UpdateConductor(Conductor conductor);
        void DeleteConductor(int idConductor);
        Conductor GetConductor(int idConductor);
    }
}