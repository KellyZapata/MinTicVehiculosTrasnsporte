using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculosTransporte.App.Dominio
{
    public class Repuesto
    {
    public int Id {get;set;}
    [ForeignKey("Verificacion")]
    public virtual int VerificacionId {get;set;}
    public virtual Verificacion Verificacion {get;set;}
    public string Descripcion {get;set;}
    public int Precio {get;set;}
    }
}
