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
            MCustomerMembers = new HashSet<MCustomerMember>();
            MCustomers = new HashSet<MCustomer>();
            MDoctors = new HashSet<MDoctor>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("fullname")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Fullname { get; set; }
        [Column("mobile_phone")]
        [StringLength(15)]
        [Unicode(false)]
        public string? MobilePhone { get; set; }
        [Column("image")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Image { get; set; }
        [Column("image_path")]
        [StringLength(255)]
        [Unicode(false)]
        public string? ImagePath { get; set; }
        [Column("created_by")]
        public long CreatedBy { get; set; }
        [Column("created_on", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("modified_by")]
        public long? ModifiedBy { get; set; }
        [Column("modified_on", TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        [Column("deleted_by")]
        public long? DeletedBy { get; set; }
        [Column("deleted_on", TypeName = "datetime")]
        public DateTime? DeletedOn { get; set; }
        [Column("is_delete")]
        public bool IsDelete { get; set; }

        [InverseProperty("Biodata")]
        public virtual ICollection<MBiodataAddress> MBiodataAddresses { get; set; }
        [InverseProperty("ParentBiodata")]
        public virtual ICollection<MCustomerMember> MCustomerMembers { get; set; }
        [InverseProperty("Biodata")]
        public virtual ICollection<MCustomer> MCustomers { get; set; }
        [InverseProperty("Biodata")]
        public virtual ICollection<MDoctor> MDoctors { get; set; }
    }
}
