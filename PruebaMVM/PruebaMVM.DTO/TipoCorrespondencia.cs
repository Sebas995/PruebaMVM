//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaMVM.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoCorrespondencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoCorrespondencia()
        {
            this.Comunicacions = new HashSet<Comunicacion>();
        }
    
        public int TipoCorrespondenciaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comunicacion> Comunicacions { get; set; }
    }
}
