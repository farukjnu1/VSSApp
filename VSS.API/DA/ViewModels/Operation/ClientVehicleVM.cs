using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.Operation
{
    public class ClientVehicleVM
    {
        public long Id { get; set; }

        [StringLength(25)]
        public string VehicleNo { get; set; }

        [StringLength(15)]
        public string Model { get; set; }

        [StringLength(30)]
        public string Vin { get; set; }

        public int? ClientId { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
    }
}