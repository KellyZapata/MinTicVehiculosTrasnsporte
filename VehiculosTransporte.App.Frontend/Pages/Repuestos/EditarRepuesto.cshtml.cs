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
    public class EditarRepuestoModel : PageModel
    {
        private readonly IRepositorioRepuestos repositorioRepuestos;
        [BindProperty]
        public Repuesto repuesto {get; set;}

        public EditarRepuestoModel()
        {
            this.repositorioRepuestos = new RepositorioRepuestos(new VehiculosTransporte.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? RepuestoId, int? VerificacionId)
        {
            if(RepuestoId.HasValue)
            {
                repuesto = this.repositorioRepuestos.GetRepuesto(RepuestoId.Value);
            }
            else
            {
                repuesto = new Repuesto();
                repuesto.VerificacionId = VerificacionId.Value;
            }

            if(repuesto == null)
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
            if(repuesto.Id > 0)
            {
                repuesto = this.repositorioRepuestos.UpdateRepuesto(repuesto);
            }
            else
            {
                this.repositorioRepuestos.AddRepuesto(repuesto);
            }
            return RedirectToPage("../Verificacion/ListarVerificacion");
        }

        public IActionResult OnGetDelete(string RepuestoId)
        {
            this.repositorioRepuestos.DeleteRepuesto(int.Parse(RepuestoId));
            return RedirectToPage("../Verificacion/ListarVerificacion");
        }
    }
}
