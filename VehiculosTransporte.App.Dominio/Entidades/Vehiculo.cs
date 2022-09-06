using System;
using System.ComponentModel.DataAnnotations;

namespace VehiculosTransporte.App.Dominio
{
    public class Vehiculo
    {
        public int Id {get;set;}
        public string Placa {get;set;}
        public string Marca {get;set;}
        public string Modelo {get;set;}

        [DataType(DataType.Date)]
        public DateTime Expiracion_tenicomecanica { get; set; }
        [DataType(DataType.Date)]
        public DateTime Expiracion_soat { get; set; }
        [DataType(DataType.Date)]
        public DateTime Expiracion_seguro_contractual { get; set; }
        [DataType(DataType.Date)]
        public DateTime Expiracion_extra_contractual { get; set; }
    }
}