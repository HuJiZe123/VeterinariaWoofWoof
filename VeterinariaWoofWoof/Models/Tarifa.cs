//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VeterinariaWoofWoof.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tarifa
    {
        public int id { get; set; }
        public string Condicional_tarifa { get; set; }
        public Nullable<double> Precio_tarifa { get; set; }
        public Nullable<int> Codmembresia { get; set; }
    
        public virtual Membresia Membresia { get; set; }
    }
}
