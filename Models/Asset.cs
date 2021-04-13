using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetTrackingAPI.Models
{
    public partial class Asset
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime EntryDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }
        [Column("PONumber")]
        [StringLength(50)]
        public string Ponumber { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DisposalDate { get; set; }
        [Column("QRCode")]
        [StringLength(50)]
        public string Qrcode { get; set; }
        [StringLength(50)]
        public string PhotoPath { get; set; }
        public double SalvageValue { get; set; }
        public int Quantity { get; set; }
        [Required]
        [StringLength(50)]
        public string AssetTag { get; set; }
        [Column("isBroken")]
        public int? IsBroken { get; set; }
        [Column("isLost")]
        public int? IsLost { get; set; }
        public int LocationId { get; set; }
        public int VendorId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Asset")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(LocationId))]
        [InverseProperty("Asset")]
        public virtual Location Location { get; set; }
        [ForeignKey(nameof(VendorId))]
        [InverseProperty("Asset")]
        public virtual Vendor Vendor { get; set; }
    }
}
