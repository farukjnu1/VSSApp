namespace VSS.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BusinessPartner")]
    public partial class BusinessPartner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusinessPartner()
        {
            PayTrans = new HashSet<PayTran>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BpId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public int? BpTypeId { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }

        public bool? IsDelete { get; set; }

        public int? DeleteDate { get; set; }

        public int? DeleteBy { get; set; }

        public virtual BusinessPartnerType BusinessPartnerType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayTran> PayTrans { get; set; }
    }
}
