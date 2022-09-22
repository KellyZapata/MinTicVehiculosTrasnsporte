using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculosTransporte.App.Dominio
{
    public class Persona{
        public int Id {get;set;}
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombres {get;set;}
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellidos {get;set;}
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es obligatoria")]
        [StringLength(10, ErrorMessage = "La cédula debe tener 10 caracteres")]
        public string Cedula {get;set;}
        [Display(Name = "Número de Teléfono")]
        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [StringLength(10, ErrorMessage = "El número de teléfono debe tener 10 dígitos")]
        public string Numero_Telefono {get;set;}
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(50, ErrorMessage = "La dirección no puede tener más de 50 caracteres")]
        public string Direccion {get;set;}
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Discriminator {get;set;}
        [ForeignKey("Vehiculo")]
        [Display(Name = "Vehículo")]
        public virtual int? VehiculoId {get;set;}
        public virtual Vehiculo Vehiculo {get;set;}
    }
}