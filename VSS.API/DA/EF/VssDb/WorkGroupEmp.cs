namespace VSS.API.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkGroupEmp")]
    public partial class WorkGroupEmp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? WgId { get; set; }

        public int? EmpId { get; set; }
    }
}
