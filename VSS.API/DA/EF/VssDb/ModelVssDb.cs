using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VSS.API.DA.EF.VssDb
{
    public partial class ModelVssDb : DbContext
    {
        public ModelVssDb()
            : base("name=ModelVssDb")
        {
        }

        public virtual DbSet<BloodGroup> BloodGroups { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BrandModel> BrandModels { get; set; }
        public virtual DbSet<BusinessPartner> BusinessPartners { get; set; }
        public virtual DbSet<BusinessPartnerBalance> BusinessPartnerBalances { get; set; }
        public virtual DbSet<BusinessPartnerType> BusinessPartnerTypes { get; set; }
        public virtual DbSet<ClientVehicle> ClientVehicles { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyLogo> CompanyLogoes { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EngineSize> EngineSizes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<ItemPrice> ItemPrices { get; set; }
        public virtual DbSet<JcHR> JcHRs { get; set; }
        public virtual DbSet<JcJob> JcJobs { get; set; }
        public virtual DbSet<JcSpare> JcSpares { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobCard> JobCards { get; set; }
        public virtual DbSet<JobGroup> JobGroups { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<MaritalStatu> MaritalStatus { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<PayMethod> PayMethods { get; set; }
        public virtual DbSet<PaySettle> PaySettles { get; set; }
        public virtual DbSet<PayStatu> PayStatus { get; set; }
        public virtual DbSet<PayTran> PayTrans { get; set; }
        public virtual DbSet<RecType> RecTypes { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<ReqStatu> ReqStatus { get; set; }
        public virtual DbSet<ReqUrgent> ReqUrgents { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SalesPrice> SalesPrices { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StoreRec> StoreRecs { get; set; }
        public virtual DbSet<StoreReq> StoreReqs { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WorkGroup> WorkGroups { get; set; }
        public virtual DbSet<WorkGroupEmp> WorkGroupEmps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<BrandModel>()
                .Property(e => e.ModelCode)
                .IsUnicode(false);

            modelBuilder.Entity<BrandModel>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessPartner>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessPartner>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessPartner>()
                .Property(e => e.MembershipNo)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessPartner>()
                .Property(e => e.ContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessPartner>()
                .Property(e => e.ContactPersonNo)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessPartner>()
                .HasMany(e => e.PayTrans)
                .WithOptional(e => e.BusinessPartner)
                .HasForeignKey(e => e.BusinessPartnerId);

            modelBuilder.Entity<BusinessPartnerBalance>()
                .Property(e => e.BalanceAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BusinessPartnerType>()
                .HasMany(e => e.BusinessPartners)
                .WithOptional(e => e.BusinessPartnerType)
                .HasForeignKey(e => e.BpTypeId);

            modelBuilder.Entity<ClientVehicle>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<ClientVehicle>()
                .Property(e => e.Vin)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyCode)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.DateFormat)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Vat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Company>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyLogo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DocType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.NID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<EngineSize>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<EngineSize>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EngineSize>()
                .Property(e => e.CC)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.GrandTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.Qty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.Tax)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.Discount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.TpAfterDiscount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.Vat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.TotalVat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Barcode)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.PartNoOld)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.PartNoNew)
                .IsUnicode(false);

            modelBuilder.Entity<ItemCategory>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ItemPrice>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JcJob>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JcSpare>()
                .Property(e => e.SalePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JcSpare>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JcSpare>()
                .Property(e => e.SpareAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Job>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.JcNo)
                .IsUnicode(false);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.Vin)
                .IsUnicode(false);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.Mileage)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.EstiCostJob)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.EstiCostSpare)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.EstiCostTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.ActualCostJob)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.ActualCostSpare)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.ActualCostTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.ContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<JobCard>()
                .Property(e => e.ContactPersonNo)
                .IsUnicode(false);

            modelBuilder.Entity<JobGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.MenuCode)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.MenuIcon)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.ModuleCode)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.ModuleIcon)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.ModuleColor)
                .IsUnicode(false);

            modelBuilder.Entity<PayMethod>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PayMethod>()
                .HasOptional(e => e.PayMethod1)
                .WithRequired(e => e.PayMethod2);

            modelBuilder.Entity<PayMethod>()
                .HasMany(e => e.PaySettles)
                .WithOptional(e => e.PayMethod)
                .HasForeignKey(e => e.PaymentMethod);

            modelBuilder.Entity<PayMethod>()
                .HasMany(e => e.PayTrans)
                .WithOptional(e => e.PayMethod)
                .HasForeignKey(e => e.PayMethodId);

            modelBuilder.Entity<PaySettle>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PayTran>()
                .Property(e => e.TrxId)
                .IsUnicode(false);

            modelBuilder.Entity<PayTran>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PayTran>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<PayTran>()
                .Property(e => e.BankAccNo)
                .IsUnicode(false);

            modelBuilder.Entity<PayTran>()
                .Property(e => e.BranchName)
                .IsUnicode(false);

            modelBuilder.Entity<PayTran>()
                .Property(e => e.ChequeNo)
                .IsUnicode(false);

            modelBuilder.Entity<RecType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ReqStatu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ReqUrgent>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<SalesPrice>()
                .Property(e => e.SalePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SalesPrice>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .Property(e => e.Size1)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .Property(e => e.Qty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreRec>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreRec>()
                .Property(e => e.Qty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreReq>()
                .Property(e => e.Qty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPass)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MobileNo)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Latitude)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Longitude)
                .HasPrecision(18, 6);

            modelBuilder.Entity<WorkGroup>()
                .Property(e => e.WgName)
                .IsUnicode(false);
        }
    }
}
