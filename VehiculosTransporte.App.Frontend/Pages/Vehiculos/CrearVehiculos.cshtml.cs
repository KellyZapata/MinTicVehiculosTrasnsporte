using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiculosTransporte.App.Persistencia;
using VehiculosTransporte.App.Dominio;

namespace VehiculosTransporte.App.Frontend.Pages
{
    public class CrearVehiculosModel : PageModel
    {
        private readonly IRepositorioVehiculos repositorioVehiculos;
        public IEnumerable<Vehiculo> vehiculos {get; set;}

        public CrearVehiculosModel(){
            this.repositorioVehiculos = new RepositorioVehiculos(new VehiculosTransporte.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
            vehiculos = repositorioVehiculos.GetVehiculos();

        }
    }
}
