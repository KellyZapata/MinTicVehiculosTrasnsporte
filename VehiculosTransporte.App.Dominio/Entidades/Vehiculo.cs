using System;
using System.ComponentModel.DataAnnotations;

namespace VehiculosTransporte.App.Dominio
{
    public class Vehiculo
    {
        public int Id {get;set;}
        [Display(Name = "Placa")]
        [Required(ErrorMessage = "La placa es obligatoria")]
        public string Placa {get;set;}
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca {get;set;}
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo {get;set;}
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de la tecnicomecanica")]
        [Required(ErrorMessage = "La fecha de la tecnicomecanica es obligatoria")]
        public DateTime Expiracion_tenicomecanica { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de la póliza de seguro")]
        [Required(ErrorMessage = "La fecha de la póliza de seguro es obligatoria")]
        public DateTime Expiracion_soat { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha del seguro contractual")]
        [Required(ErrorMessage = "La fecha del seguro contractual es obligatoria")]
        public DateTime Expiracion_seguro_contractual { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha del seguro extra contractual")]
        [Required(ErrorMessage = "La fecha del seguro extra contractual es obligatoria")]
        public DateTime Expiracion_extra_contractual { get; set; }
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Discriminator {get;set;}
    }
}