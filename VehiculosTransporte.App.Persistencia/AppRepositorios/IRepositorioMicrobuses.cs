using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioMicrobuses
    {
        IEnumerable<Microbus> GetAllMicrobuses();
        Microbus AddMicrobus(Microbus bus);
        Microbus UpdateMicrobus(Microbus microbus);
        void DeleteMicrobus(int idMicrobus);
        Microbus GetMicrobus(int idMicrobus);
    }
}