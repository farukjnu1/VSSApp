using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.System
{
    public class UserVM
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserCode { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(20)]
        public string MobileNo { get; set; }

        [StringLength(40)]
        public string PhoneNo { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? DeleteBy { get; set; }

        public bool? IsDelete { get; set; }
    }
}