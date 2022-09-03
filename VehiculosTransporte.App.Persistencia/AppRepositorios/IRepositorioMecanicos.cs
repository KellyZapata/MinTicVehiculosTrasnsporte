using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioMecanicos
    {
        IEnumerable<Mecanico> GetMecanicos();
        Mecanico AddMecanico(Mecanico mecanico);
        Mecanico UpdateMecanico(Mecanico mecanico);
        void DeleteMecanico(int idMecanico);
        Mecanico GetMecanico(int idMecanico);
    }
}