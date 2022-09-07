using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculosTransporte.App.Dominio
{


public class Persona{
    public int Id {get;set;}
    public string Nombres {get;set;}
    public string Apellidos {get;set;}
    public string Cedula {get;set;}
    public string Numero_Telefono {get;set;}
    public string Direccion {get;set;}
    [ForeignKey("Vehiculo")]
    public virtual int VehiculoId {get;set;}
    public virtual Vehiculo Vehiculo {get;set;}
}

}