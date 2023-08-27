namespace VSS.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JcResource")]
    public partial class JcResource
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JcResourceId { get; set; }

        public int? EmployeeId { get; set; }

        public long? JcId { get; set; }
    }
}
