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
        public string MembershipId {get;set;}
        public string JcNo { get; set; }
        public string JobDate { get; set; }
        public int CreateBy { get; set; }
        public string Vin { get; set; }
        public decimal Mileage { get; set; }
        public decimal EstiCostTotal { get; set; }
        public decimal EstiCostJob { get; set; }
        public decimal EstiCostSpare { get; set; }
        public decimal ActualCostTotal { get; set; }
        public decimal ActualCostJob { get; set; }
        public decimal ActualCostSpare { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int ReceiveBy { get; set; }
        public DateTime JobStart { get; set; }
        public DateTime JobEnd { get; set; }
        public int Bay { get; set; }
        public string VehicleNo { get; set; }
        public string Model { get; set; }
        public int JcStatus { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public string ClientAddress { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonNo { get; set; }
        public string Description { get; set; }
        public List<JobDetailVm> JobDetails { get; set; }
        public List<JcSpareVm> JcSpares { get; set; }
    }

    public class JobDetailVm
    {
        public int JobGroupId { get; set; }
        public int JobId { get; set; }
        public int EngineSizeId { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int JobStatus { get; set; }
        public int[] Resources { get; set; }
    }

    public class JcSpareVm
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public int ItemCategoryId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string PartNoOld { get; set; }
        public string PartNoNew { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public decimal SpareAmount { get; set; }
        public int ItemStatus { get; set; }
    }

}