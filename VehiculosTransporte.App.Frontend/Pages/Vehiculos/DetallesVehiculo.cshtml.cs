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
    public class DetallesVehiculoModel : PageModel
    {
        private readonly IRepositorioVehiculos repositorioVehiculos;
        public Vehiculo vehiculo {get; set;}

        public DetallesVehiculoModel()
        {
            this.repositorioVehiculos = new RepositorioVehiculos(new VehiculosTransporte.App.Persistencia.AppContext());

        }
        public IActionResult OnGet(int VehiculoId)
        {
            vehiculo = this.repositorioVehiculos.GetVehiculo(VehiculoId);
            if(vehiculo == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
