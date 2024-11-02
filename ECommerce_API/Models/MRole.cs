using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_roles")]
    [Index("RoleName", Name = "UQ__m_roles__783254B18C2E475D", IsUnique = true)]
    public partial class MRole
    {
        public MRole()
        {
            MUsers = new HashSet<MUser>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("role_name")]
        [StringLength(50)]
        public string RoleName { get; set; } = null!;
        [Column("description")]
        [StringLength(255)]
        public string? Description { get; set; }
        [Column("created_by")]
        public int? CreatedBy { get; set; }
        [Column("created_on", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("modified_by")]
        public int? ModifiedBy { get; set; }
        [Column("modified_on", TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        [Column("deleted_by")]
        public int? DeletedBy { get; set; }
        [Column("deleted_on", TypeName = "datetime")]
        public DateTime? DeletedOn { get; set; }
        [Column("is_deleted")]
        public bool? IsDeleted { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<MUser> MUsers { get; set; }
    }
}
