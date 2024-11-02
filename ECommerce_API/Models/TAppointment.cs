using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("t_appointment")]
    public partial class TAppointment
    {
        public TAppointment()
        {
            TAppointmentCancellations = new HashSet<TAppointmentCancellation>();
            TAppointmentRescheduleHistories = new HashSet<TAppointmentRescheduleHistory>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("customer_id")]
        public long? CustomerId { get; set; }
        [Column("doctor_office_id")]
        public long? DoctorOfficeId { get; set; }
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

        [ForeignKey("DoctorOfficeId")]
        [InverseProperty("TAppointments")]
        public virtual TDoctorOffice? DoctorOffice { get; set; }
        [ForeignKey("DoctorOfficeScheduleId")]
        [InverseProperty("TAppointments")]
        public virtual TDoctorOfficeSchedule? DoctorOfficeSchedule { get; set; }
        [ForeignKey("DoctorOfficeTreatmentId")]
        [InverseProperty("TAppointments")]
        public virtual TDoctorOfficeTreatment? DoctorOfficeTreatment { get; set; }
        [InverseProperty("Appointment")]
        public virtual ICollection<TAppointmentCancellation> TAppointmentCancellations { get; set; }
        [InverseProperty("Appointment")]
        public virtual ICollection<TAppointmentRescheduleHistory> TAppointmentRescheduleHistories { get; set; }
    }
}
