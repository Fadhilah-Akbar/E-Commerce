using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("t_orders")]
    public partial class TOrder
    {
        public TOrder()
        {
            TOrderItems = new HashSet<TOrderItem>();
            TPayments = new HashSet<TPayment>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("total_amount", TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
        [Column("order_status")]
        [StringLength(50)]
        public string? OrderStatus { get; set; }
        [Column("order_date", TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column("shipping_address_id")]
        public int? ShippingAddressId { get; set; }
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

        [ForeignKey("ShippingAddressId")]
        [InverseProperty("TOrders")]
        public virtual MBiodataAddress? ShippingAddress { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("TOrders")]
        public virtual MUser? User { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<TOrderItem> TOrderItems { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<TPayment> TPayments { get; set; }
    }
}
