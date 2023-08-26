namespace VSS.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        public int? UserId { get; set; }

        [StringLength(150)]
        public string FirstName { get; set; }

        [StringLength(150)]
        public string MiddleName { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string NID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(35)]
        public string Mobile { get; set; }

        [StringLength(15)]
        public string Nationality { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfJoining { get; set; }

        public bool? IsConfirm { get; set; }

        public DateTime? DateOfConfirm { get; set; }

        public DateTime? DateOfQuit { get; set; }

        public DateTime? DateOfLeaving { get; set; }

        public int? MaritalStatus { get; set; }

        public int? Gender { get; set; }

        public int? ReligionId { get; set; }

        public int? DesignateId { get; set; }

        public int? BloodGroup { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }

        public virtual BloodGroup BloodGroup1 { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Employee Employee2 { get; set; }

        public virtual Gender Gender1 { get; set; }

        public virtual MaritalStatu MaritalStatu { get; set; }

        public virtual Religion Religion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
