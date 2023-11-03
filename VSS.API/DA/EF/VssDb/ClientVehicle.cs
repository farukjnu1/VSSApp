namespace VSS.API.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientVehicle")]
    public partial class ClientVehicle
    {
        public long Id { get; set; }

        [StringLength(25)]
        public string VehicleNo { get; set; }

        [StringLength(15)]
        public string Model { get; set; }

        [StringLength(30)]
        public string Vin { get; set; }

        public int? ClientId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }
    }
}
