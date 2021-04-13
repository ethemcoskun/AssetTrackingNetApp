using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AssetTrackingAPI.Models
{
    public partial class Site
    {
        public Site()
        {
            Location = new HashSet<Location>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Notes { get; set; }
        [StringLength(50)]
        public string Website { get; set; }

        [InverseProperty("Site")]
        public virtual ICollection<Location> Location { get; set; }
    }
}
