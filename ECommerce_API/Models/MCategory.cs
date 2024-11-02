using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_categories")]
    public partial class MCategory
    {
        public MCategory()
        {
            MProducts = new HashSet<MProduct>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("category_name")]
        [StringLength(100)]
        public string CategoryName { get; set; } = null!;
        [Column("description")]
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

        [InverseProperty("Category")]
        public virtual ICollection<MProduct> MProducts { get; set; }
    }
}
