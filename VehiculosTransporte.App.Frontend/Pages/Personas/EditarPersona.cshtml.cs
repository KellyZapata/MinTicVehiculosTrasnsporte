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
    public class EditarPersonaModel : PageModel
    {
        private readonly IRepositorioPersonas repositorioPersonas;
        private readonly IRepositorioVehiculos repositorioVehiculos;
        [BindProperty]
        public Persona persona {get; set;}
        public IEnumerable<Vehiculo> vehiculos {get; set;}

        public EditarPersonaModel()
        {
            this.repositorioPersonas = new RepositorioPersonas(new VehiculosTransporte.App.Persistencia.AppContext());
            this.repositorioVehiculos = new RepositorioVehiculos(new VehiculosTransporte.App.Persistencia.AppContext());
        }
       public IActionResult OnGet(int? PersonaId)
        {
            if(PersonaId.HasValue)
            {
                persona = this.repositorioPersonas.GetPersona(PersonaId.Value);
            }
            else
            {
                persona = new Persona();
            }
            vehiculos = repositorioVehiculos.GetVehiculos();
            if(persona == null)
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
            if(persona.Id > 0)
            {
                persona = this.repositorioPersonas.UpdatePersona(persona);
            }
            else
            {
                this.repositorioPersonas.AddPersona(persona);
            }
            return RedirectToPage("./ListarPersona");
        }

        public IActionResult OnGetDelete(string PersonaId)
        {
            this.repositorioPersonas.DeletePersona(int.Parse(PersonaId));
            return RedirectToPage("./ListarPersona");
        }
    }
}
