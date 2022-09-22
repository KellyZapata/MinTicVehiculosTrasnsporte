using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehiculosTransporte.App.Dominio
{
    public class Repuesto
    {
    public int Id {get;set;}
    [ForeignKey("Verificacion")]
    public virtual int VerificacionId {get;set;}
    public virtual Verificacion Verificacion {get;set;}
    [Display(Name = "Descripcion")]
    [Required(ErrorMessage = "La descripcion es obligatoria")]
    public string Descripcion {get;set;}
    [Display(Name = "Costo")]
    [Required(ErrorMessage = "El costo es obligatorio")]
    [Range(0, 100000000)]
    public int Precio {get;set;}
    }
}
