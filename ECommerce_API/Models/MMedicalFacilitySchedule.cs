﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("m_medical_facility_schedule")]
    public partial class MMedicalFacilitySchedule
    {
        public MMedicalFacilitySchedule()
        {
            TDoctorOfficeSchedules = new HashSet<TDoctorOfficeSchedule>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("medical_facility_id")]
        public long? MedicalFacilityId { get; set; }
        [Column("day")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Day { get; set; }
        [Column("time_schedule_start")]
        [StringLength(10)]
        [Unicode(false)]
        public string? TimeScheduleStart { get; set; }
        [Column("time_schedule_end")]
        [StringLength(10)]
        [Unicode(false)]
        public string? TimeScheduleEnd { get; set; }
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

        [ForeignKey("MedicalFacilityId")]
        [InverseProperty("MMedicalFacilitySchedules")]
        public virtual MMedicalFacility? MedicalFacility { get; set; }
        [InverseProperty("MedicalFacilitySchedule")]
        public virtual ICollection<TDoctorOfficeSchedule> TDoctorOfficeSchedules { get; set; }
    }
}
