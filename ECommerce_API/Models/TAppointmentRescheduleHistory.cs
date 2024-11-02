﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("t_appointment_reschedule_history")]
    public partial class TAppointmentRescheduleHistory
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("appointment_id")]
        public long? AppointmentId { get; set; }
        [Column("doctor_office_schedule_id")]
        public long? DoctorOfficeScheduleId { get; set; }
        [Column("doctor_office_treatment_id")]
        public long? DoctorOfficeTreatmentId { get; set; }
        [Column("appointment_date", TypeName = "date")]
        public DateTime? AppointmentDate { get; set; }
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

        [ForeignKey("AppointmentId")]
        [InverseProperty("TAppointmentRescheduleHistories")]
        public virtual TAppointment? Appointment { get; set; }
        [ForeignKey("DoctorOfficeScheduleId")]
        [InverseProperty("TAppointmentRescheduleHistories")]
        public virtual TDoctorOfficeSchedule? DoctorOfficeSchedule { get; set; }
        [ForeignKey("DoctorOfficeTreatmentId")]
        [InverseProperty("TAppointmentRescheduleHistories")]
        public virtual TDoctorOfficeTreatment? DoctorOfficeTreatment { get; set; }
    }
}