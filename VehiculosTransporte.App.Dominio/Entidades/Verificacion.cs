using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculosTransporte.App.Dominio
{
    public class Verificacion
    {
    public int Id {get;set;}
    [ForeignKey("Mecanico")]
    public virtual int MecanicoId {get;set;}
    public virtual Mecanico Mecanico {get;set;}
    public int Vehiculo {get;set;}
    public string Nivel_Aceite {get;set;}
    public string Nivel_Liquido_frenos {get;set;}
    public string Nivel_Refrigerante {get;set;}
    public string Nivel_Liquido_direccion {get;set;}
    }
}

