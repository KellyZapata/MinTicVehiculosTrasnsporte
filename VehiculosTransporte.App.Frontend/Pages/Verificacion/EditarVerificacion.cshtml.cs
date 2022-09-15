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
    public class EditarVerificacionModel : PageModel
    {
        private readonly IRepositorioVerificaciones repositorioVerificaciones;
        [BindProperty]
        public Verificacion verificacion {get; set;}

        public EditarVerificacionModel()
        {
            this.repositorioVerificaciones = new RepositorioVerificaciones(new VehiculosTransporte.App.Persistencia.AppContext());

        }
       public IActionResult OnGet(int? VerificacionId)
        {
            if(VerificacionId.HasValue)
            {
                verificacion = this.repositorioVerificaciones.GetVerificacion(VerificacionId.Value);
            }
            else
            {
                verificacion = new Verificacion();
            }

            if(verificacion == null)
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
            if(verificacion.Id > 0)
            {
                verificacion = this.repositorioVerificaciones.UpdateVerificacion(verificacion);
            }
            else
            {
                this.repositorioVerificaciones.AddVerificacion(verificacion);
            }
            return RedirectToPage("./ListarVerificacion");
        }

        public IActionResult OnGetDelete(string VerificacionId)
        {
            this.repositorioVerificaciones.DeleteVerificacion(int.Parse(VerificacionId));
            return RedirectToPage("./ListarVerificacion");
        }
    }
}
