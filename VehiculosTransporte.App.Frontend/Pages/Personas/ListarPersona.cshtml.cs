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
    public class ListarPersona : PageModel
    {
        private readonly IRepositorioPersonas repositorioPersonas;
        public IEnumerable<Persona> persona {get; set;}

        public ListarPersona(){
            this.repositorioPersonas = new RepositorioPersonas(new PersonasTransporte.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
            personas = repositorioPersonas.GetPersonas();

        }

        public PartialViewResult OnPostEdit(string PersonaId)
        {
            return new PartialViewResult
            {
                ViewName = "EditarPersona",
                ViewData = new ViewDataDictionary<Bus>(ViewData, repositorioPersonas.GetVehiculo(Int32.Parse(VehiculoId)))
            };
        }
    }
}
