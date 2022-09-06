using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioVerificaciones
    {
        IEnumerable<Verificacion> GetVerificaciones();

        Verificacion AddVerificacion(Verificacion verificacion);

        Verificacion UpdateVerificacion(Verificacion verificacion);

        void DeleteVerificacion(int idVerificacion);

        Verificacion GetVerificacion(int idVerificacion);
    }
}
