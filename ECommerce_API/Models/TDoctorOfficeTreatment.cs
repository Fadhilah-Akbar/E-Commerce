using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Models
{
    [Table("t_doctor_office_treatment")]
    public partial class TDoctorOfficeTreatment
    {
        public TDoctorOfficeTreatment()
        {
            TAppointmentRescheduleHistories = new HashSet<TAppointmentRescheduleHistory>();
            TAppointments = new HashSet<TAppointment>();
            TDoctorOfficeTreatmentPrices = new HashSet<TDoctorOfficeTreatmentPrice>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("doctor_treatment_id")]
        public long? DoctorTreatmentId { get; set; }
        [Column("doctor_office_id")]
        public long? DoctorOfficeId { get; set; }
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
        [InverseProperty("TDoctorOfficeTreatments")]
        public virtual TDoctorOffice? DoctorOffice { get; set; }
        [ForeignKey("DoctorTreatmentId")]
        [InverseProperty("TDoctorOfficeTreatments")]
        public virtual TDoctorTreatment? DoctorTreatment { get; set; }
        [InverseProperty("DoctorOfficeTreatment")]
        public virtual ICollection<TAppointmentRescheduleHistory> TAppointmentRescheduleHistories { get; set; }
        [InverseProperty("DoctorOfficeTreatment")]
        public virtual ICollection<TAppointment> TAppointments { get; set; }
        [InverseProperty("DoctorOfficeTreatment")]
        public virtual ICollection<TDoctorOfficeTreatmentPrice> TDoctorOfficeTreatmentPrices { get; set; }
    }
}
