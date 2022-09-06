using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public interface IRepositorioJefeOperaciones
    
        
    {
        IEnumerable<JefeOperaciones> GetAllJefesOperaciones();
        JefeOperaciones AddJefeOperaciones(JefeOperaciones jefeoperaciones);
        JefeOperaciones UpdataJefeOperaciones(JefeOperaciones jefeoperaciones);
        void DeleteJefeOperaciones(int idJefeOperaciones);
        JefeOperaciones GetJefeOperaciones(int idJefeOperaciones);
    }

        
    
}
