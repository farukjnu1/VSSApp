using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.System
{
    public class UserPayload
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int TokenExpire { get; set; }
        public DateTime CreateDate { get; set; }
    }
}