using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.Operation
{
    public class JobCardVM
    {
        public long Id { get; set; }

        public int? ClientId { get; set; }

        [StringLength(200)]
        public string ClientInfo { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(25)]
        public string VehicleNo { get; set; }

        [StringLength(15)]
        public string Model { get; set; }

        [StringLength(30)]
        public string Vin { get; set; }

        public decimal? Vat { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal? GrandTotal { get; set; }

        public DateTime? ArriveDate { get; set; }

        public int? SupervisorId { get; set; }

        public int? IsDone { get; set; }

        public int? Bay { get; set; }

        [StringLength(10)]
        public string MembershipNumber { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}