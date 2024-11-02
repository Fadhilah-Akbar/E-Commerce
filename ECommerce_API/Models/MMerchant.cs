using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_merchants")]
    public partial class MMerchant
    {
        public MMerchant()
        {
            MProducts = new HashSet<MProduct>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("merchant_name")]
        [StringLength(255)]
        public string MerchantName { get; set; } = null!;
        [Column("merchant_phone")]
        [StringLength(15)]
        public string? MerchantPhone { get; set; }
        [Column("merchant_address")]
        [StringLength(255)]
        public string? MerchantAddress { get; set; }
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

        [ForeignKey("UserId")]
        [InverseProperty("MMerchants")]
        public virtual MUser? User { get; set; }
        [InverseProperty("Merchant")]
        public virtual ICollection<MProduct> MProducts { get; set; }
    }
}
