using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("t_payments")]
    public partial class TPayment
    {
        [Key]
        [Column("payment_id")]
        public int PaymentId { get; set; }
        [Column("order_id")]
        public int? OrderId { get; set; }
        [Column("payment_method")]
        [StringLength(100)]
        public string? PaymentMethod { get; set; }
        [Column("payment_status")]
        [StringLength(50)]
        public string? PaymentStatus { get; set; }
        [Column("amount", TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Column("payment_date", TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }
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
        [InverseProperty("TPayments")]
        public virtual TOrder? Order { get; set; }
    }
}
