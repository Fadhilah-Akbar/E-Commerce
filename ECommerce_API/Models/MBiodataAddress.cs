using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_biodata_address")]
    public partial class MBiodataAddress
    {
        public MBiodataAddress()
        {
            TOrders = new HashSet<TOrder>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("biodata_id")]
        public int BiodataId { get; set; }
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; } = null!;
        [Column("city")]
        [StringLength(100)]
        public string? City { get; set; }
        [Column("postal_code")]
        [StringLength(10)]
        public string? PostalCode { get; set; }
        [Column("country")]
        [StringLength(100)]
        public string? Country { get; set; }
        [Column("phone_number")]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
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

        [ForeignKey("BiodataId")]
        [InverseProperty("MBiodataAddresses")]
        public virtual MBiodatum Biodata { get; set; } = null!;
        [InverseProperty("ShippingAddress")]
        public virtual ICollection<TOrder> TOrders { get; set; }
    }
}
