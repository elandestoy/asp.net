namespace GHWebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class trisks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trisks()
        {
            tjobs = new List<tjobs>();
        }

        [Key]
        public int IDRisk { get; set; }

        [Required]
        [DisplayName("Risk")]
        [StringLength(20, ErrorMessage = "Risks must be between 3 to 20", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Enable")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<tjobs> tjobs { get; set; }
    }
}
