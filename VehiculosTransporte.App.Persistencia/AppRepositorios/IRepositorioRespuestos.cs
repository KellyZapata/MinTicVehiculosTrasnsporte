using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioRepuestos
    {
        IEnumerable<Repuesto> GetRepuestos();

        Repuesto AddRepuesto(Repuesto repuesto);

        Repuesto UpdateRepuesto(Repuesto repuesto);

        void DeleteRepuesto(int idRepuesto);

        Repuesto GetRepuesto(int idRepuesto);
    }
}

