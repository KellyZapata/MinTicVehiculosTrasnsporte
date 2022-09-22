using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehiculosTransporte.App.Dominio
{
    public class Verificacion
    {
    public int Id {get;set;}
    [ForeignKey("Mecanico")]
    [Display(Name = "Mecanico")]
    [Required(ErrorMessage = "El mecánico es obligatorio")]
    public virtual int MecanicoId {get;set;}
    public virtual Mecanico Mecanico {get;set;}
    [ForeignKey("Vehiculo")]
    [Display(Name = "Vehiculo")]
    [Required(ErrorMessage = "El vehículo es obligatorio")]
    public virtual int VehiculoId {get;set;}
    public virtual Vehiculo Vehiculo {get;set;}
    [Display(Name = "Nivel de aceite")]
    [Required(ErrorMessage = "El nivel de aceite es obligatorio")]
    public string Nivel_Aceite {get;set;}
    [Display(Name = "Nivel de liquido de frenos")]
    [Required(ErrorMessage = "El nivel de liquido de frenos es obligatorio")]
    public string Nivel_Liquido_frenos {get;set;}
    [Display(Name = "Nivel de liquido refrigerante")]
    [Required(ErrorMessage = "El nivel de liquido refrigerante es obligatorio")]
    public string Nivel_Refrigerante {get;set;}
    [Display(Name = "Nivel de liquido de direccion hidraulica")]
    [Required(ErrorMessage = "El nivel de liquido de direccion hidraulica es obligatorio")]
    public string Nivel_Liquido_direccion {get;set;}
    }
}

