using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_biodata")]
    public partial class MBiodatum
    {
        public MBiodatum()
        {
            MBiodataAddresses = new HashSet<MBiodataAddress>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("first_name")]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;
        [Column("last_name")]
        [StringLength(100)]
        public string? LastName { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string? Gender { get; set; }
        [Column("birth_date", TypeName = "date")]
        public DateTime? BirthDate { get; set; }
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

        [ForeignKey("UserId")]
        [InverseProperty("MBiodata")]
        public virtual MUser User { get; set; } = null!;
        [InverseProperty("Biodata")]
        public virtual ICollection<MBiodataAddress> MBiodataAddresses { get; set; }
    }
}
