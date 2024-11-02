using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_shipping_methods")]
    public partial class MShippingMethod
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("method_name")]
        [StringLength(100)]
        public string MethodName { get; set; } = null!;
        [Column("cost", TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
        [Column("estimated_delivery_time")]
        [StringLength(100)]
        public string? EstimatedDeliveryTime { get; set; }
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
    }
}
