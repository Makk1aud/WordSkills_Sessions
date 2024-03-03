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

    public virtual DbSet<Admissiontype> Admissiontypes { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Hospitalisation> Hospitalisations { get; set; }

    public virtual DbSet<Hospitalprescription> Hospitalprescriptions { get; set; }

    public virtual DbSet<Insurancepole> Insurancepoles { get; set; }

    public virtual DbSet<Medicalactivetype> Medicalactivetypes { get; set; }

    public virtual DbSet<Medicalactivite> Medicalactivites { get; set; }

    public virtual DbSet<Medicalcard> Medicalcards { get; set; }

    public virtual DbSet<Medicalhistory> Medicalhistories { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WorldSkills;Username=postgres;Password=UAZ9233");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admissiontype>(entity =>
        {
            entity.HasKey(e => e.AdmissionTypeId).HasName("admissiontypes_pkey");

            entity.ToTable("admissiontypes");

            entity.Property(e => e.AdmissionTypeId).HasColumnName("admission_type_id");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("doctors_pkey");

            entity.ToTable("doctors");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.LoginCode)
                .HasMaxLength(20)
                .HasColumnName("login_code");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .HasColumnName("middle_name");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Position).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_position_id_doctors_positions");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.HospitalId).HasName("hospitals_pkey");

            entity.ToTable("hospitals");

            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Hospitalisation>(entity =>
        {
            entity.HasKey(e => e.HospitalisationId).HasName("hospitalisations_pkey");

            entity.ToTable("hospitalisations");

            entity.Property(e => e.HospitalisationId).HasColumnName("hospitalisation_id");
            entity.Property(e => e.AdmissionTypeId).HasColumnName("admission_type_id");
            entity.Property(e => e.Diagnose)
                .HasColumnType("character varying")
                .HasColumnName("diagnose");
            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.HospitalisationCode)
                .HasMaxLength(10)
                .HasColumnName("hospitalisation_code");
            entity.Property(e => e.HospitalisationDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("hospitalisation_date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Purpose)
                .HasMaxLength(100)
                .HasColumnName("purpose");

            entity.HasOne(d => d.AdmissionType).WithMany(p => p.Hospitalisations)
                .HasForeignKey(d => d.AdmissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_admission_type_id_hospitalisations_admissiontypes");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Hospitalisations)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hospital_id_hospitalisations_hospitals");

            entity.HasOne(d => d.Patient).WithMany(p => p.Hospitalisations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patient_id_hospitalisations_patients");
        });

        modelBuilder.Entity<Hospitalprescription>(entity =>
        {
            entity.HasKey(e => e.HospitalPrescriptionId).HasName("hospitalprescriptions_pkey");

            entity.ToTable("hospitalprescriptions");

            entity.Property(e => e.HospitalPrescriptionId).HasColumnName("hospital_prescription_id");
            entity.Property(e => e.DrugTitle)
                .HasMaxLength(100)
                .HasColumnName("drug_title");
            entity.Property(e => e.MedicalActivitesId).HasColumnName("medical_activites_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");

            entity.HasOne(d => d.MedicalActivites).WithMany(p => p.Hospitalprescriptions)
                .HasForeignKey(d => d.MedicalActivitesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_medical_activites_id_hospitalprescriptions_medicalactivites");

            entity.HasOne(d => d.Patient).WithMany(p => p.Hospitalprescriptions)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patient_id_hospitalprescriptions_patients");
        });

        modelBuilder.Entity<Insurancepole>(entity =>
        {
            entity.HasKey(e => e.InsurancePolicyId).HasName("insurancepoles_pkey");

            entity.ToTable("insurancepoles");

            entity.Property(e => e.InsurancePolicyId).HasColumnName("insurance_policy_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.PolicyNum)
                .HasMaxLength(30)
                .HasColumnName("policy_num");
        });

        modelBuilder.Entity<Medicalactivetype>(entity =>
        {
            entity.HasKey(e => e.MedicalTypeId).HasName("medicalactivetypes_pkey");

            entity.ToTable("medicalactivetypes");

            entity.Property(e => e.MedicalTypeId).HasColumnName("medical_type_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Medicalactivite>(entity =>
        {
            entity.HasKey(e => e.MedicalActivitesId).HasName("medicalactivites_pkey");

            entity.ToTable("medicalactivites");

            entity.Property(e => e.MedicalActivitesId).HasColumnName("medical_activites_id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.HoldingDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("holding_date");
            entity.Property(e => e.MedicalTypeId).HasColumnName("medical_type_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Recomendation)
                .HasColumnType("character varying")
                .HasColumnName("recomendation");
            entity.Property(e => e.Result)
                .HasColumnType("character varying")
                .HasColumnName("result");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Medicalactivites)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_doctor_id_medicalactivites_doctors");

            entity.HasOne(d => d.MedicalType).WithMany(p => p.Medicalactivites)
                .HasForeignKey(d => d.MedicalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_medical_type_id_medicalactivites_medicalactivetypes");

            entity.HasOne(d => d.Patient).WithMany(p => p.Medicalactivites)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patient_id_medicalactivites_patients");
        });

        modelBuilder.Entity<Medicalcard>(entity =>
        {
            entity.HasKey(e => e.MedicalCardId).HasName("medicalcards_pkey");

            entity.ToTable("medicalcards");

            entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");
            entity.Property(e => e.InsurancePolicyId).HasColumnName("insurance_policy_id");
            entity.Property(e => e.IssueDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("issue_date");
            entity.Property(e => e.LastContactDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_contact_date");
            entity.Property(e => e.NextContactDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("next_contact_date");

            entity.HasOne(d => d.InsurancePolicy).WithMany(p => p.Medicalcards)
                .HasForeignKey(d => d.InsurancePolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_insurance_policy_id_medicalcards_insurancepoles");
        });

        modelBuilder.Entity<Medicalhistory>(entity =>
        {
            entity.HasKey(e => e.MedicalHistoryId).HasName("medicalhistories_pkey");

            entity.ToTable("medicalhistories");

            entity.Property(e => e.MedicalHistoryId).HasColumnName("medical_history_id");
            entity.Property(e => e.Diagnose)
                .HasColumnType("character varying")
                .HasColumnName("diagnose");
            entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");

            entity.HasOne(d => d.MedicalCard).WithMany(p => p.Medicalhistories)
                .HasForeignKey(d => d.MedicalCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_medical_card_id_medicalhistories_medicalcards");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("patients_pkey");

            entity.ToTable("patients");

            entity.HasIndex(e => e.Passport, "unique_passport").IsUnique();

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.MedicalCardId).HasColumnName("medical_card_id");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .HasColumnName("middle_name");
            entity.Property(e => e.Passport)
                .HasMaxLength(20)
                .HasColumnName("passport");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(100)
                .HasColumnName("photo_path");
            entity.Property(e => e.WorkPlace)
                .HasMaxLength(100)
                .HasColumnName("work_place");

            entity.HasOne(d => d.Gender).WithMany(p => p.Patients)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_gender_id_patients_genders");

            entity.HasOne(d => d.MedicalCard).WithMany(p => p.Patients)
                .HasForeignKey(d => d.MedicalCardId)
                .HasConstraintName("fk_medical_card_id_patients_medicalcards");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionTitle)
                .HasMaxLength(50)
                .HasColumnName("position_title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
