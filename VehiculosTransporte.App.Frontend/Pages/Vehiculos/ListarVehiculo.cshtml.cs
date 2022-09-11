using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiculosTransporte.App.Persistencia;
using VehiculosTransporte.App.Dominio;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace VehiculosTransporte.App.Frontend.Pages
{
    public class ListarVehiculo : PageModel
    {
        private readonly IRepositorioVehiculos repositorioVehiculos;
        public IEnumerable<Vehiculo> vehiculos {get; set;}

        public ListarVehiculo(){
            this.repositorioVehiculos = new RepositorioVehiculos(new VehiculosTransporte.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
            vehiculos = repositorioVehiculos.GetVehiculos();

        }

        public PartialViewResult OnPostEdit(string VehiculoId)
        {
            return new PartialViewResult
            {
                ViewName = "EditarVehiculo",
                ViewData = new ViewDataDictionary<Bus>(ViewData, repositorioVehiculos.GetVehiculo(Int32.Parse(VehiculoId)))
            };
        }
    }
}
