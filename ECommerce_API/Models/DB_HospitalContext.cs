using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerce_API.Models
{
    public partial class DB_HospitalContext : DbContext
    {
        public DB_HospitalContext()
        {
        }

        public DB_HospitalContext(DbContextOptions<DB_HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MAdmin> MAdmins { get; set; } = null!;
        public virtual DbSet<MBiodataAddress> MBiodataAddresses { get; set; } = null!;
        public virtual DbSet<MBiodatum> MBiodata { get; set; } = null!;
        public virtual DbSet<MBloodGroup> MBloodGroups { get; set; } = null!;
        public virtual DbSet<MCourier> MCouriers { get; set; } = null!;
        public virtual DbSet<MCourierType> MCourierTypes { get; set; } = null!;
        public virtual DbSet<MCustomer> MCustomers { get; set; } = null!;
        public virtual DbSet<MCustomerMember> MCustomerMembers { get; set; } = null!;
        public virtual DbSet<MCustomerRelation> MCustomerRelations { get; set; } = null!;
        public virtual DbSet<MDoctor> MDoctors { get; set; } = null!;
        public virtual DbSet<MDoctorEducation> MDoctorEducations { get; set; } = null!;
        public virtual DbSet<MEducationLevel> MEducationLevels { get; set; } = null!;
        public virtual DbSet<MLocation> MLocations { get; set; } = null!;
        public virtual DbSet<MLocationLevel> MLocationLevels { get; set; } = null!;
        public virtual DbSet<MMedicalFacility> MMedicalFacilities { get; set; } = null!;
        public virtual DbSet<MMedicalFacilityCategory> MMedicalFacilityCategories { get; set; } = null!;
        public virtual DbSet<MMedicalFacilitySchedule> MMedicalFacilitySchedules { get; set; } = null!;
        public virtual DbSet<MMedicalItem> MMedicalItems { get; set; } = null!;
        public virtual DbSet<MMedicalItemCategory> MMedicalItemCategories { get; set; } = null!;
        public virtual DbSet<MMedicalItemSegmentation> MMedicalItemSegmentations { get; set; } = null!;
        public virtual DbSet<MMenu> MMenus { get; set; } = null!;
        public virtual DbSet<MMenuRole> MMenuRoles { get; set; } = null!;
        public virtual DbSet<MRole> MRoles { get; set; } = null!;
        public virtual DbSet<MSpecialization> MSpecializations { get; set; } = null!;
        public virtual DbSet<MUser> MUsers { get; set; } = null!;
        public virtual DbSet<TAppointment> TAppointments { get; set; } = null!;
        public virtual DbSet<TAppointmentCancellation> TAppointmentCancellations { get; set; } = null!;
        public virtual DbSet<TAppointmentRescheduleHistory> TAppointmentRescheduleHistories { get; set; } = null!;
        public virtual DbSet<TCurrentDoctorSpecialization> TCurrentDoctorSpecializations { get; set; } = null!;
        public virtual DbSet<TCustomerChat> TCustomerChats { get; set; } = null!;
        public virtual DbSet<TDoctorOffice> TDoctorOffices { get; set; } = null!;
        public virtual DbSet<TDoctorOfficeSchedule> TDoctorOfficeSchedules { get; set; } = null!;
        public virtual DbSet<TDoctorOfficeTreatment> TDoctorOfficeTreatments { get; set; } = null!;
        public virtual DbSet<TDoctorOfficeTreatmentPrice> TDoctorOfficeTreatmentPrices { get; set; } = null!;
        public virtual DbSet<TDoctorTreatment> TDoctorTreatments { get; set; } = null!;
        public virtual DbSet<TResetPassword> TResetPasswords { get; set; } = null!;
        public virtual DbSet<TToken> TTokens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=DB_Hospital;user id=sa;Password=P@ssw0rd; Command Timeout=300");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MAdmin>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MBiodataAddress>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Biodata)
                    .WithMany(p => p.MBiodataAddresses)
                    .HasForeignKey(d => d.BiodataId)
                    .HasConstraintName("FK_biodata_id_M_Bidoata");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.MBiodataAddresses)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_location_id_M_Location");
            });

            modelBuilder.Entity<MBiodatum>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MBloodGroup>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MCourier>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MCourierType>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.MCourierTypes)
                    .HasForeignKey(d => d.CourierId)
                    .HasConstraintName("FK_courier");
            });

            modelBuilder.Entity<MCustomer>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Biodata)
                    .WithMany(p => p.MCustomers)
                    .HasForeignKey(d => d.BiodataId)
                    .HasConstraintName("FK_m_biodata_id_m_customer");

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.MCustomers)
                    .HasForeignKey(d => d.BloodGroupId)
                    .HasConstraintName("FK_blood_group");
            });

            modelBuilder.Entity<MCustomerMember>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MCustomerMembers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_customer");

                entity.HasOne(d => d.CustomerRelation)
                    .WithMany(p => p.MCustomerMembers)
                    .HasForeignKey(d => d.CustomerRelationId)
                    .HasConstraintName("FK_customer_relation");

                entity.HasOne(d => d.ParentBiodata)
                    .WithMany(p => p.MCustomerMembers)
                    .HasForeignKey(d => d.ParentBiodataId)
                    .HasConstraintName("FK_biodata_id_m_customer_member");
            });

            modelBuilder.Entity<MCustomerRelation>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MDoctor>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Biodata)
                    .WithMany(p => p.MDoctors)
                    .HasForeignKey(d => d.BiodataId)
                    .HasConstraintName("FK_biodata");
            });

            modelBuilder.Entity<MDoctorEducation>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsLastEducation).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MDoctorEducations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_doctor");
            });

            modelBuilder.Entity<MEducationLevel>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MLocation>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.LocationLevel)
                    .WithMany(p => p.MLocations)
                    .HasForeignKey(d => d.LocationLevelId)
                    .HasConstraintName("FK_location_level");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_parent_location");
            });

            modelBuilder.Entity<MLocationLevel>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MMedicalFacility>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.MMedicalFacilities)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_location");

                entity.HasOne(d => d.MedicalFacilityCategory)
                    .WithMany(p => p.MMedicalFacilities)
                    .HasForeignKey(d => d.MedicalFacilityCategoryId)
                    .HasConstraintName("FK_medical_facility_category");
            });

            modelBuilder.Entity<MMedicalFacilityCategory>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MMedicalFacilitySchedule>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MedicalFacility)
                    .WithMany(p => p.MMedicalFacilitySchedules)
                    .HasForeignKey(d => d.MedicalFacilityId)
                    .HasConstraintName("FK_medical_facility");
            });

            modelBuilder.Entity<MMedicalItem>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MedicalItemCategory)
                    .WithMany(p => p.MMedicalItems)
                    .HasForeignKey(d => d.MedicalItemCategoryId)
                    .HasConstraintName("FK_m_medical_item_category_m_medical_item");

                entity.HasOne(d => d.MedicalItemSegmentation)
                    .WithMany(p => p.MMedicalItems)
                    .HasForeignKey(d => d.MedicalItemSegmentationId)
                    .HasConstraintName("FK_m_medical_item_segmentation_m_medical_item");
            });

            modelBuilder.Entity<MMedicalItemCategory>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MMedicalItemSegmentation>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MMenu>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Menu_Parent");
            });

            modelBuilder.Entity<MMenuRole>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MMenuRoles)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_Menu_Role");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.MMenuRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Role_Menu");
            });

            modelBuilder.Entity<MRole>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MSpecialization>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MUser>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TAppointment>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DoctorOffice)
                    .WithMany(p => p.TAppointments)
                    .HasForeignKey(d => d.DoctorOfficeId)
                    .HasConstraintName("FK_t_doctor_office_t_appointment");

                entity.HasOne(d => d.DoctorOfficeSchedule)
                    .WithMany(p => p.TAppointments)
                    .HasForeignKey(d => d.DoctorOfficeScheduleId)
                    .HasConstraintName("FK_t_doctor_office_schedule_t_appointment");

                entity.HasOne(d => d.DoctorOfficeTreatment)
                    .WithMany(p => p.TAppointments)
                    .HasForeignKey(d => d.DoctorOfficeTreatmentId)
                    .HasConstraintName("FK_t_doctor_office_treatment_t_appointment");
            });

            modelBuilder.Entity<TAppointmentCancellation>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TAppointmentCancellations)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_t_appointment_cancellation_t_appointment");
            });

            modelBuilder.Entity<TAppointmentRescheduleHistory>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TAppointmentRescheduleHistories)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_t_appointment_reschedule_history_appointment_id");

                entity.HasOne(d => d.DoctorOfficeSchedule)
                    .WithMany(p => p.TAppointmentRescheduleHistories)
                    .HasForeignKey(d => d.DoctorOfficeScheduleId)
                    .HasConstraintName("FK_t_doctor_office_schedule_t_appointment_reschedule_history");

                entity.HasOne(d => d.DoctorOfficeTreatment)
                    .WithMany(p => p.TAppointmentRescheduleHistories)
                    .HasForeignKey(d => d.DoctorOfficeTreatmentId)
                    .HasConstraintName("FK_t_doctor_office_treatment_t_appointment_reshedule_history");
            });

            modelBuilder.Entity<TCurrentDoctorSpecialization>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TCurrentDoctorSpecializations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_m_doctor_id_table_current_doctor_specialization");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.TCurrentDoctorSpecializations)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK_m_specialization");
            });

            modelBuilder.Entity<TCustomerChat>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TCustomerChats)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_m_customer");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TCustomerChats)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_m_doctor_t_customer_chat");
            });

            modelBuilder.Entity<TDoctorOffice>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TDoctorOffices)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_m_doctor");

                entity.HasOne(d => d.MedicalFacility)
                    .WithMany(p => p.TDoctorOffices)
                    .HasForeignKey(d => d.MedicalFacilityId)
                    .HasConstraintName("FK_m_medical_facility_id");
            });

            modelBuilder.Entity<TDoctorOfficeSchedule>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TDoctorOfficeSchedules)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_doctor_schedule");

                entity.HasOne(d => d.MedicalFacilitySchedule)
                    .WithMany(p => p.TDoctorOfficeSchedules)
                    .HasForeignKey(d => d.MedicalFacilityScheduleId)
                    .HasConstraintName("FK_medical_facility_schedule");
            });

            modelBuilder.Entity<TDoctorOfficeTreatment>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DoctorOffice)
                    .WithMany(p => p.TDoctorOfficeTreatments)
                    .HasForeignKey(d => d.DoctorOfficeId)
                    .HasConstraintName("FK_t_doctor_office_t_doctor_office_treatment");

                entity.HasOne(d => d.DoctorTreatment)
                    .WithMany(p => p.TDoctorOfficeTreatments)
                    .HasForeignKey(d => d.DoctorTreatmentId)
                    .HasConstraintName("FK_t_doctor_treatment_t_doctor_office_treatment");
            });

            modelBuilder.Entity<TDoctorOfficeTreatmentPrice>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DoctorOfficeTreatment)
                    .WithMany(p => p.TDoctorOfficeTreatmentPrices)
                    .HasForeignKey(d => d.DoctorOfficeTreatmentId)
                    .HasConstraintName("FK_t_doctor_office_treatment");
            });

            modelBuilder.Entity<TDoctorTreatment>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TDoctorTreatments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_m_doctor_id_t_doctor_treatment");
            });

            modelBuilder.Entity<TResetPassword>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TToken>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
