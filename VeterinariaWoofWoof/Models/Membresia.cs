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
    
    public partial class Membresia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Membresia()
        {
            this.CitaDetalles = new HashSet<CitaDetalle>();
            this.ControlMembresias = new HashSet<ControlMembresia>();
            this.MembresiaClientes = new HashSet<MembresiaCliente>();
            this.Tarifas = new HashSet<Tarifa>();
        }
    
        public int id { get; set; }
        public Nullable<int> NoMembresia_membresia { get; set; }
        public Nullable<System.DateTime> FechaAdquisicion_membresia { get; set; }
        public Nullable<System.DateTime> FechaVencimiento_membresia { get; set; }
        public Nullable<double> Tarifa_membresia { get; set; }
        public Nullable<int> NumServicios_membresia { get; set; }
        public Nullable<byte> Gratis_membresia { get; set; }
        public Nullable<byte> estatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CitaDetalle> CitaDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlMembresia> ControlMembresias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MembresiaCliente> MembresiaClientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarifa> Tarifas { get; set; }
    }
}
