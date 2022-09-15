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
    public class DetallesPersonaModel : PageModel
    {
        private readonly IRepositorioPersonas repositorioPersonas;
        public Persona persona { get; set; }

        public DetallesPersonaModel()
        {
            this.repositorioPersonas = new RepositorioPersonas(new VehiculosTransporte.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(string personaId)
        {
            persona = repositorioPersonas.GetPersona(Int32.Parse(personaId));
            if (persona == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
    }
}
