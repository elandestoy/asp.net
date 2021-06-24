namespace GHWebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ttrainings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ttrainings()
        {
            temployees = new List<temployees>();
        }

        [Key]
        public int IDTraining { get; set; }

        [Required]
        [DisplayName("Training Name")]
        [StringLength(20, ErrorMessage = "Training Name must be between 3 to 20", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Level")]
        public int IDLevel { get; set; }

        [DisplayName("From Date")]
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }

        [DisplayName("To Date")]
        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }

        [Required]
        [DisplayName("Place")]
        [StringLength(20, ErrorMessage = "Place Name must be between 3 to 20", MinimumLength = 3)]
        public string Place { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<temployees> temployees { get; set; }

        public virtual tlevel tlevel { get; set; }
    }
}
