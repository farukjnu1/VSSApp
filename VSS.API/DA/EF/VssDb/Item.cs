namespace VSS.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
            ItemPrices = new HashSet<ItemPrice>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string ItemCode { get; set; }

        [StringLength(250)]
        public string ItemName { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        public int? UnitId { get; set; }

        public int? ItemGroupId { get; set; }

        public int? ItemCategoryId { get; set; }

        public int? BrandId { get; set; }

        [StringLength(150)]
        public string Model { get; set; }

        [StringLength(100)]
        public string Dimension { get; set; }

        [StringLength(100)]
        public string Weight { get; set; }

        public int? ColorId { get; set; }

        public int? SizeId { get; set; }

        public int? ManufacturerId { get; set; }

        [StringLength(50)]
        public string PartNo { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public int? Duration { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateAt { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int? DeleteBy { get; set; }

        public DateTime? DeleteAt { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Color Color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }

        public virtual ItemGroup ItemGroup { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Size Size { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemPrice> ItemPrices { get; set; }
    }
}