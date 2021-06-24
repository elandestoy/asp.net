namespace GHWebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tdepts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tdepts()
        {
            temployees = new List<temployees>();
        }

        [Key]
        public int IDDept { get; set; }

        [Required]
        [DisplayName("Department")]
        [StringLength(50, ErrorMessage = "Department must be between 3 to 50", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Enable")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<temployees> temployees { get; set; }
    }
}
