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
    public class DetallesVerificacionModel : PageModel
    {
        private readonly IRepositorioVerificaciones repositorioVerificaciones;
        private readonly IRepositorioRepuestos repositorioRepuestos;
        public Verificacion verificacion {get; set;}
        public IEnumerable<Repuesto> repuestos {get; set;}

        public DetallesVerificacionModel()
        {
            this.repositorioVerificaciones = new RepositorioVerificaciones(new VehiculosTransporte.App.Persistencia.AppContext());
            this.repositorioRepuestos = new RepositorioRepuestos(new VehiculosTransporte.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int VerificacionId)
        {
            verificacion = this.repositorioVerificaciones.GetVerificacion(VerificacionId);
            repuestos = this.repositorioRepuestos.GetRepuestos().Where(r => r.VerificacionId == VerificacionId);
            if(verificacion == null)
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
