using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiculosTransporte.App.Persistencia.AppRepositorios;

namespace VehiculosTransporte.App.Frontend.Pages
{
    public class CrearVehiculosModel : PageModel
    {
        private readonly IRepositorioVehiculos repositorioVehiculos;
        public IEnumerable<Vehiculo> vehiculos {get; set;}

        public ListModel(IRepositorioVehiculos repositorioVehiculos){
            this.repositorioVehiculos = repositorioVehiculos;
        }

        public void OnGet()
        {
            vehiculos.repositorioVehiculos.GetVehiculos();

        }
    }
}
