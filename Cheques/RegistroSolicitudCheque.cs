//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cheques
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegistroSolicitudCheque
    {
        public int Id { get; set; }
        public int NumeroSolicitud { get; set; }
        public int IDProveedor { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public int CuentaContableProveedor { get; set; }
        public int CuentaContableInterna { get; set; }
    
        public virtual Proveedores Proveedores { get; set; }
        public virtual Proveedores Proveedores1 { get; set; }
    }
}