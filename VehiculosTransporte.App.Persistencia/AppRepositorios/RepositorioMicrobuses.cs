using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Persistencia
{
    public class RepositorioMicrobuses: IRepositorioMicrobuses
    {
        private readonly AppContext _appContext = new AppContext();

        public RepositorioMicrobuses(AppContext appContext)
        {
            _appContext = appContext;
        }
        public Microbus AddMicrobus(Microbus microbus)
        {
            var microbusAdicionado = _appContext.Microbuses.Add(microbus);
            _appContext.SaveChanges();
            return microbusAdicionado.Entity;
        }
        public Microbus UpdateMicrobus(Microbus microbus)
        {
            var microbusEncontrado = _appContext.Microbuses.FirstOrDefault(m => m.Id == microbus.Id);
            if (microbusEncontrado != null)
            {
                microbusEncontrado.Placa = microbus.Placa;
                microbusEncontrado.Marca = microbus.Marca;
                microbusEncontrado.Modelo = microbus.Modelo;
                microbusEncontrado.Expiracion_tenicomecanica = microbus.Expiracion_tenicomecanica;
                microbusEncontrado.Expiracion_soat = microbus.Expiracion_soat;
                microbusEncontrado.Expiracion_seguro_contractual = microbus.Expiracion_seguro_contractual;
                microbusEncontrado.Expiracion_extra_contractual = microbus.Expiracion_extra_contractual;
                _appContext.SaveChanges();
            }
            return microbusEncontrado;
        }
        public void DeleteMicrobus(int idMicrobus)
        {
            var microbusEncontrado = _appContext.Microbuses.FirstOrDefault(m => m.Id == idMicrobus);
            if (microbusEncontrado == null)
                return;
            _appContext.Microbuses.Remove(microbusEncontrado);
            _appContext.SaveChanges();
        }
        public Microbus GetMicrobus(int idMicrobus)
        {
            return _appContext.Microbuses.FirstOrDefault(m => m.Id == idMicrobus);
        }
        public IEnumerable<Microbus> GetAllMicrobuses()
        {
            return _appContext.Microbuses;
        }
    }
}