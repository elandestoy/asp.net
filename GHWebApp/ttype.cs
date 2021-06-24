namespace GHWebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ttype")]
    public partial class ttype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ttype()
        {
            temployees = new List<temployees>();
        }

        [Key]
        public int IDType { get; set; }

        [Required]
        [DisplayName("Type")]
        [StringLength(20, ErrorMessage = "Type must be between 3 to 20", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Enable")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<temployees> temployees { get; set; }
    }
}
