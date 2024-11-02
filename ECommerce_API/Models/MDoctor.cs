using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_doctor")]
    public partial class MDoctor
    {
        public MDoctor()
        {
            MDoctorEducations = new HashSet<MDoctorEducation>();
            TCurrentDoctorSpecializations = new HashSet<TCurrentDoctorSpecialization>();
            TCustomerChats = new HashSet<TCustomerChat>();
            TDoctorOfficeSchedules = new HashSet<TDoctorOfficeSchedule>();
            TDoctorOffices = new HashSet<TDoctorOffice>();
            TDoctorTreatments = new HashSet<TDoctorTreatment>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("biodata_id")]
        public long? BiodataId { get; set; }
        [Column("str")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Str { get; set; }
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

        [ForeignKey("BiodataId")]
        [InverseProperty("MDoctors")]
        public virtual MBiodatum? Biodata { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<MDoctorEducation> MDoctorEducations { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<TCurrentDoctorSpecialization> TCurrentDoctorSpecializations { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<TCustomerChat> TCustomerChats { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<TDoctorOfficeSchedule> TDoctorOfficeSchedules { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<TDoctorOffice> TDoctorOffices { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<TDoctorTreatment> TDoctorTreatments { get; set; }
    }
}
