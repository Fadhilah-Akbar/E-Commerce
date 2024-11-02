using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_token")]
    [Index("Token", Name = "UQ__m_token__CA90DA7A32EA91A1", IsUnique = true)]
    public partial class MToken
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("token")]
        [StringLength(255)]
        public string Token { get; set; } = null!;
        [Column("is_expired")]
        public bool? IsExpired { get; set; }
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
