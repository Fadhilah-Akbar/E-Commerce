using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_users")]
    public partial class MUser
    {
        public MUser()
        {
            MBiodata = new HashSet<MBiodatum>();
            MMerchants = new HashSet<MMerchant>();
            TCarts = new HashSet<TCart>();
            TOrders = new HashSet<TOrder>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; } = null!;
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; } = null!;
        [Column("role_id")]
        public int RoleId { get; set; }
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

        [ForeignKey("RoleId")]
        [InverseProperty("MUsers")]
        public virtual MRole Role { get; set; } = null!;
        [InverseProperty("User")]
        public virtual ICollection<MBiodatum> MBiodata { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<MMerchant> MMerchants { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TCart> TCarts { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TOrder> TOrders { get; set; }
    }
}
