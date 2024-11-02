using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_location")]
    public partial class MLocation
    {
        public MLocation()
        {
            InverseParent = new HashSet<MLocation>();
            MBiodataAddresses = new HashSet<MBiodataAddress>();
            MMedicalFacilities = new HashSet<MMedicalFacility>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("parent_id")]
        public long? ParentId { get; set; }
        [Column("location_level_id")]
        public long? LocationLevelId { get; set; }
        [Column("created_by")]
        public long CreatedBy { get; set; }
        [Column("created_on", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("modified_by")]
        public long? ModifiedBy { get; set; }
        [Column("modified_on", TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        [Column("deleted_by")]
        public long? DeletedBy { get; set; }
        [Column("deleted_on", TypeName = "datetime")]
        public DateTime? DeletedOn { get; set; }
        [Column("is_delete")]
        public bool IsDelete { get; set; }

        [ForeignKey("LocationLevelId")]
        [InverseProperty("MLocations")]
        public virtual MLocationLevel? LocationLevel { get; set; }
        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual MLocation? Parent { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<MLocation> InverseParent { get; set; }
        [InverseProperty("Location")]
        public virtual ICollection<MBiodataAddress> MBiodataAddresses { get; set; }
        [InverseProperty("Location")]
        public virtual ICollection<MMedicalFacility> MMedicalFacilities { get; set; }
    }
}
