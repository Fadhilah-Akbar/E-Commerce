using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("t_order_items")]
    public partial class TOrderItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_id")]
        public int? OrderId { get; set; }
        [Column("product_id")]
        public int? ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column("total_price", TypeName = "decimal(29, 2)")]
        public decimal? TotalPrice { get; set; }
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

        [ForeignKey("OrderId")]
        [InverseProperty("TOrderItems")]
        public virtual TOrder? Order { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("TOrderItems")]
        public virtual MProduct? Product { get; set; }
    }
}
