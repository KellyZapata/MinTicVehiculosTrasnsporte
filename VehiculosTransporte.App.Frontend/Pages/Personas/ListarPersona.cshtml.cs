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
        public IEnumerable<Persona> personas {get; set;}

        public ListarPersona(){
            this.repositorioPersonas = new RepositorioPersonas(new VehiculosTransporte.App.Persistencia.AppContext());
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
                ViewData = new ViewDataDictionary<Bus>(ViewData, repositorioPersonas.GetPersona(Int32.Parse(PersonaId)))
            };
        }
    }
}
