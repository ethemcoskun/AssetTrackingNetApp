using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetTrackingAPI.Models
{
    public partial class Location
    {
        public Location()
        {
            Asset = new HashSet<Asset>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public int SiteId { get; set; }

        [ForeignKey(nameof(SiteId))]
        [InverseProperty("Location")]
        public virtual Site Site { get; set; }
        [InverseProperty("Location")]
        public virtual ICollection<Asset> Asset { get; set; }
    }
}
