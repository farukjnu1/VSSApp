namespace VSS.API.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamMember")]
    public partial class TeamMember
    {
        public int Id { get; set; }

        public int? TeamId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
