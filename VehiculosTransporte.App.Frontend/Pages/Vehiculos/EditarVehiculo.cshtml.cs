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
    public class EditarVehiculoModel : PageModel
    {
        private readonly IRepositorioVehiculos repositorioVehiculos;
        [BindProperty]
        public Vehiculo vehiculo {get; set;}

        public EditarVehiculoModel()
        {
            this.repositorioVehiculos = new RepositorioVehiculos(new VehiculosTransporte.App.Persistencia.AppContext());

        }
       public IActionResult OnGet(int? VehiculoId)
        {
            if(VehiculoId.HasValue)
            {
                vehiculo = this.repositorioVehiculos.GetVehiculo(VehiculoId.Value);
            }
            else
            {
                vehiculo = new Vehiculo();
            }

            if(vehiculo == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(vehiculo.Id > 0)
            {
                vehiculo = this.repositorioVehiculos.UpdateVehiculo(vehiculo);
            }
            else
            {
                this.repositorioVehiculos.AddVehiculo(vehiculo);
            }
            return RedirectToPage("./ListarVehiculo");
        }

        public IActionResult OnGetDelete(string VehiculoId)
        {
            this.repositorioVehiculos.DeleteVehiculo(int.Parse(VehiculoId));
            return RedirectToPage("./ListarVehiculo");
        }
    }
}
