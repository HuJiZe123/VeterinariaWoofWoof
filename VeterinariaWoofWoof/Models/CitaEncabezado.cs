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
    
    public partial class CitaEncabezado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CitaEncabezado()
        {
            this.CitaClientes = new HashSet<CitaCliente>();
            this.CitaDetalles = new HashSet<CitaDetalle>();
            this.ControlMembresias = new HashSet<ControlMembresia>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> Fecha_citae { get; set; }
        public string Hora_citae { get; set; }
        public Nullable<int> Codpago { get; set; }
        public Nullable<int> Codempleado { get; set; }
        public Nullable<byte> ServicioDomicilio_citae { get; set; }
        public Nullable<double> Total_citae { get; set; }
        public Nullable<double> Saldo { get; set; }
        public Nullable<byte> estatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CitaCliente> CitaClientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CitaDetalle> CitaDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlMembresia> ControlMembresias { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}
