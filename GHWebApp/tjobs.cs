namespace GHWebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tjobs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tjobs()
        {
            temployees = new List<temployees>();
        }

        [Key]
        public int IDJobs { get; set; }

        [Required]
        [DisplayName("Job Name")]
        [StringLength(20, ErrorMessage = "Job Name must be between 3 to 20", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Risk")]
        public int IDRisk { get; set; }

        [DisplayName("Minimum  Salary")]
        [Column(TypeName = "money")]
        public decimal MinSalary { get; set; }

        [DisplayName("Maximum Salary")]
        [Column(TypeName = "money")]
        public decimal MaxSalary { get; set; }

        [DisplayName("Enable")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<temployees> temployees { get; set; }

        public virtual trisks trisks { get; set; }
    }
}
