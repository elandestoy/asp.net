namespace GHWebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class texps
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public texps()
        {
            temployees = new List<temployees>();
        }

        [Key]
        public int IDExp { get; set; }

        [Required]
        [DisplayName("Job Name")]
        [StringLength(20, ErrorMessage = "Job name must be between 3 to 20", MinimumLength = 3)]
        public string JobName { get; set; }

        [Required]
        [DisplayName("Place")]
        [StringLength(20, ErrorMessage = "Place must be between 3 to 20", MinimumLength = 3)]
        public string Place { get; set; }

        [DisplayName("From Date")]
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }

        [DisplayName("To Date")]
        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }

        [DisplayName("Salary")]
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        [DisplayName("Enable")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<temployees> temployees { get; set; }


        //username:   
        [DisplayName("User Name")]
        [StringLength(250)]
        public string UserName { get; set; }
    }
}
