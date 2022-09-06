using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioVerificaciones
    {
        IEnumerable<Verificacion> GetVerificaciones();

        Persona AddVerificacion(Verificacion verificacion);

        Persona UpdateVerificacion(Verificacion verificacion);

        void DeleteVerificacion(int idVerificacion);

        Persona GetVerificacion(int idVerificacion);
    }
}
