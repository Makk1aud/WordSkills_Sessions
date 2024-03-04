using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public partial class WorldSkillsContext : DbContext
{
    public WorldSkillsContext()
    {
    }

    public WorldSkillsContext(DbContextOptions<WorldSkillsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdmissionType> AdmissionTypes { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<HospitalPrescription> HospitalPrescriptions { get; set; }

    public virtual DbSet<Hospitalisation> Hospitalisations { get; set; }

    public virtual DbSet<InsurancePole> InsurancePoles { get; set; }

    public virtual DbSet<MedicalActiveType> MedicalActiveTypes { get; set; }

    public virtual DbSet<MedicalActivite> MedicalActivites { get; set; }

    public virtual DbSet<MedicalCard> MedicalCards { get; set; }

    public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=WorldSkills;Trusted_Connection=True;user id=makklaud;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdmissionType>(entity =>
        {
            entity.HasKey(e => e.AdmissionTypeId).HasName("PK__Admissio__6B8CDF313030ACDE");

            entity.Property(e => e.AdmissionTypeId).HasColumnName("admission_type_id");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__F3993564CDDF0A03");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LoginCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("login_code");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Position).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_position_id_Doctors_Positions");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__Genders__9DF18F87D9A4F129");

            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.HospitalId).HasName("PK__Hospital__DFF4167F03FB4842");

            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<HospitalPrescription>(entity =>
        {
            entity.HasKey(e => e.HospitalPrescriptionId).HasName("PK__Hospital__612299115481244F");

            entity.Property(e => e.HospitalPrescriptionId).HasColumnName("hospital_prescription_id");
            entity.Property(e => e.DrugTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("drug_title");
            entity.Property(e => e.MedicalActivitesId).HasColumnName("medical_activites_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");

            entity.HasOne(d => d.MedicalActivites).WithMany(p => p.HospitalPrescriptions)
                .HasForeignKey(d => d.MedicalActivitesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_medical_activites_id_HospitalPrescriptions_MedicalActivites");

            entity.HasOne(d => d.Patient).WithMany(p => p.HospitalPrescriptions)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_patient_id_HospitalPrescriptions_Patients");
        });

        modelBuilder.Entity<Hospitalisation>(entity =>
        {
            entity.HasKey(e => e.HospitalisationId).HasName("PK__Hospital__2D37E20D0348A747");

            entity.Property(e => e.HospitalisationId).HasColumnName("hospitalisation_id");
            entity.Property(e => e.AdmissionTypeId).HasColumnName("admission_type_id");
            entity.Property(e => e.Diagnose)
                .IsUnicode(false)
                .HasColumnName("diagnose");
            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.HospitalisationCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("hospitalisation_code");
            entity.Property(e => e.HospitalisationDate)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("hospitalisation_date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Purpose)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("purpose");

            entity.HasOne(d => d.AdmissionType).WithMany(p => p.Hospitalisations)
                .HasForeignKey(d => d.AdmissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_admission_type_id_Hospitalisations_AdmissionTypes");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Hospitalisations)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hospital_id_Hospitalisations_Hospitals");

            entity.HasOne(d => d.Patient).WithMany(p => p.Hospitalisations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_patient_id_Hospitalisations_Patients");
        });

        modelBuilder.Entity<InsurancePole>(entity =>
        {
            entity.HasKey(e => e.InsurancePolicyId).HasName("PK__Insuranc__3054ABE9C413B1A1");

            entity.Property(e => e.InsurancePolicyId).HasColumnName("insurance_policy_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.PolicyNum)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("policy_num");
        });

        modelBuilder.Entity<MedicalActiveType>(entity =>
        {
            entity.HasKey(e => e.MedicalTypeId).HasName("PK__MedicalA__B0186A20879A6F78");

            entity.Property(e => e.MedicalTypeId).HasColumnName("medical_type_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<MedicalActivite>(entity =>
        {
            entity.HasKey(e => e.MedicalActivitesId).HasName("PK__MedicalA__F7FECAC679D23509");

            entity.Property(e => e.MedicalActivitesId).HasColumnName("medical_activites_id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.HoldingDate)
                .HasColumnType("datetime")
                .HasColumnName("holding_date");
            entity.Property(e => e.MedicalTypeId).HasColumnName("medical_type_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Recomendation)
                .IsUnicode(false)
                .HasColumnName("recomendation");
            entity.Property(e => e.Result)
                .IsUnicode(false)
                .HasColumnName("result");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Doctor).WithMany(p => p.MedicalActivites)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctor_id_MedicalActivites_Doctors");

            entity.HasOne(d => d.MedicalType).WithMany(p => p.MedicalActivites)
                .HasForeignKey(d => d.MedicalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_medical_type_id_MedicalActivites_MedicalActiveTypes");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalActivites)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_patient_id_MedicalActivites_Patients");
        });

        modelBuilder.Entity<MedicalCard>(entity =>
        {
            entity.HasKey(e => e.MedicalCardId).HasName("PK__MedicalC__7916D8E7660AA421");

            entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");
            entity.Property(e => e.InsurancePolicyId).HasColumnName("insurance_policy_id");
            entity.Property(e => e.IssueDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("issue_date");
            entity.Property(e => e.LastContactDate)
                .HasColumnType("datetime")
                .HasColumnName("last_contact_date");
            entity.Property(e => e.NextContactDate)
                .HasColumnType("datetime")
                .HasColumnName("next_contact_date");

            entity.HasOne(d => d.InsurancePolicy).WithMany(p => p.MedicalCards)
                .HasForeignKey(d => d.InsurancePolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_insurance_policy_id_MedicalCards_InsurancePoles");
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.MedicalHistoryId).HasName("PK__MedicalH__32ACF8B1CEDC2384");

            entity.Property(e => e.MedicalHistoryId).HasColumnName("medical_history_id");
            entity.Property(e => e.Diagnose)
                .IsUnicode(false)
                .HasColumnName("diagnose");
            entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");

            entity.HasOne(d => d.MedicalCard).WithMany(p => p.MedicalHistories)
                .HasForeignKey(d => d.MedicalCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_medical_card_id_MedicalHistories_MedicalCards");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__4D5CE476886E49F0");

            entity.HasIndex(e => e.Passport, "UQ__Patients__5E2A0857A698071D").IsUnique();

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.Passport)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("passport");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("photo_path");
            entity.Property(e => e.WorkPlace)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("work_place");

            entity.HasOne(d => d.Gender).WithMany(p => p.Patients)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gender_id_Patients_Genders");

            entity.HasOne(d => d.MedicalCard).WithMany(p => p.Patients)
                .HasForeignKey(d => d.MedicalCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_medical_card_id_Patients_MedicalCards");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__99A0E7A4EC943F1C");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position_title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
