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
        public class ListarVerificacion : PageModel

    {
        private readonly IRepositorioVerificaciones repositorioVerificaciones;
        public IEnumerable<Verificacion> verificaciones {get; set;}

        public ListarVerificacion(){
            this.repositorioVerificaciones = new RepositorioVerificaciones(new VehiculosTransporte.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
            verificaciones = repositorioVerificaciones.GetVerificaciones();

        }

        public PartialViewResult OnPostEdit(string VerificacionId)
        {
            return new PartialViewResult
            {
                ViewName = "EditarVerificacion",
                ViewData = new ViewDataDictionary<Bus>(ViewData, repositorioVerificaciones.GetVerificacion(Int32.Parse(VerificacionId)))
            };
        }
    }
}
