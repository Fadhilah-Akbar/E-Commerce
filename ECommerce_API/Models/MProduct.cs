using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_products")]
    public partial class MProduct
    {
        public MProduct()
        {
            TCarts = new HashSet<TCart>();
            TOrderItems = new HashSet<TOrderItem>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("merchant_id")]
        public int? MerchantId { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
        [Column("product_name")]
        [StringLength(255)]
        public string ProductName { get; set; } = null!;
        [Column("product_description")]
        public string? ProductDescription { get; set; }
        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column("stock")]
        public int? Stock { get; set; }
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

        [ForeignKey("CategoryId")]
        [InverseProperty("MProducts")]
        public virtual MCategory? Category { get; set; }
        [ForeignKey("MerchantId")]
        [InverseProperty("MProducts")]
        public virtual MMerchant? Merchant { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<TCart> TCarts { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<TOrderItem> TOrderItems { get; set; }
    }
}
