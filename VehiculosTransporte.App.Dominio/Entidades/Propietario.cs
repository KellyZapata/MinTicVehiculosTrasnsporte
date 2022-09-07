using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculosTransporte.App.Dominio
{

public class Propietario: Persona{
    [ForeignKey("Vehiculo")]
    public virtual int VehiculoId {get;set;}
    public virtual Vehiculo Vehiculo {get;set;}
}
}