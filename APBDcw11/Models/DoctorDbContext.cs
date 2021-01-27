using Microsoft.EntityFrameworkCore;
using System;

namespace APBDcw11.Models
{
    public class DoctorDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public DoctorDbContext() { }

        public DoctorDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Doctor>(mb =>
            {
            mb.HasKey(d => d.IdDoctor);
            mb.Property(d => d.IdDoctor).UseIdentityColumn();
            mb.Property(d => d.FirstName).HasMaxLength(100).IsRequired();
            mb.Property(d => d.LastName).HasMaxLength(100).IsRequired();
            mb.Property(d => d.Email).HasMaxLength(100).IsRequired();
            mb.ToTable("Doctor");
            mb.HasData(new Doctor[]
            {
                    new Doctor { IdDoctor = 1, FirstName = "Rafal", LastName = "Giuseppe", Email = "r.giu@pp.pl" },
					new Doctor { IdDoctor = 2, FirstName = "Tadeusz", LastName = "Pepperoni", Email = "t.pep@pp.pl" },
					new Doctor { IdDoctor = 3, FirstName = "Mariusz", LastName = "Maslanka", Email = "m.mas@pp.pl" },
					new Doctor { IdDoctor = 4, FirstName = "Lukasz", LastName = "Bulka", Email = "l.bul@pp.pl" },
					new Doctor { IdDoctor = 5, FirstName = "Edward", LastName = "Rurka", Email = "e.rur@pp.pl" },
                });
            });

            modelBuilder.Entity<Patient>(mb =>
            {
                mb.HasKey(p => p.IdPatient);
                mb.Property(p => p.IdPatient).UseIdentityColumn();
                mb.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                mb.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                mb.Property(p => p.Birthdate).IsRequired();
                mb.ToTable("Patient");
                mb.HasData(new Patient[]
                {
                    new Patient { IdPatient = 1, FirstName = "Radoslaw", LastName = "Klemba", Birthdate = new DateTime(2011,12,19) },
					new Patient { IdPatient = 2, FirstName = "Maciej", LastName = "Tomaszewski", Birthdate = new DateTime(1970, 02, 16) },
					new Patient { IdPatient = 3, FirstName = "Adrian", LastName = "Zielantewicz", Birthdate = new DateTime(1999, 12, 12) },
					new Patient { IdPatient = 4, FirstName = "Pawel", LastName = "Malecki", Birthdate = new DateTime(2000, 05, 28) },
					new Patient { IdPatient = 5, FirstName = "Arkadiusz", LastName = "Socha", Birthdate = new DateTime(2005, 09, 11) }
                });
            });

            modelBuilder.Entity<Medicament>(mb =>
            {
                mb.HasKey(m => m.IdMedicament);
                mb.Property(m => m.IdMedicament).UseIdentityColumn();
                mb.Property(m => m.Name).HasMaxLength(100).IsRequired();
                mb.Property(m => m.Description).HasMaxLength(100).IsRequired();
                mb.Property(m => m.Type).HasMaxLength(100).IsRequired();
                mb.ToTable("Medicament");
                mb.HasData(new Medicament[]
                {
                   new Medicament { IdMedicament = 1, Name="Pigulka C#", Description="Pigulka dajaca Ci +5 do zdolnosci C#", Type="Na recepte" },
                   new Medicament { IdMedicament = 2, Name = "Pigulka SQL", Description = "Pigulka dajaca Ci +5 do zdolnosci SQL", Type = "Bez recepty" }
                });
            });

            modelBuilder.Entity<Prescription>(mb =>
            {
                mb.HasKey(p => p.IdPrescription);
                mb.Property(p => p.IdPrescription).UseIdentityColumn();
                mb.Property(p => p.Date).IsRequired();
                mb.Property(p => p.DueDate).IsRequired();
                mb.HasOne(p => p.Patient)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(p => p.IdPatient)
                    .IsRequired();
                mb.HasOne(p => p.Doctor)
                    .WithMany(d => d.Prescription)
                    .HasForeignKey(p => p.IdDoctor)
                    .IsRequired();
                mb.ToTable("Prescription");
                mb.HasData(new Prescription[]
                {
                    new Prescription { IdPrescription = 1, Date = DateTime.Today, DueDate = new DateTime(2021, 02, 19), IdPatient = 1, IdDoctor = 1 },
                    new Prescription { IdPrescription = 2, Date = DateTime.Today, DueDate = new DateTime(2022, 03, 05), IdPatient = 3, IdDoctor = 5 },
                    new Prescription { IdPrescription = 3, Date = DateTime.Today, DueDate = new DateTime(2021, 02, 01), IdPatient = 4, IdDoctor = 4 },
                    new Prescription { IdPrescription = 4, Date = DateTime.Today, DueDate = new DateTime(2021, 02, 12), IdPatient = 2, IdDoctor = 4 },
                    new Prescription { IdPrescription = 5, Date = DateTime.Today, DueDate = new DateTime(2022, 01, 01), IdPatient = 1, IdDoctor = 2 }
                        });
            });

            modelBuilder.Entity<Prescription_Medicament>(mb =>
            {
                mb.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
                mb.Property(pm => pm.Details).HasMaxLength(100).IsRequired();
                mb.HasOne(pm => pm.Medicament)
                    .WithMany(ep => ep.Prescription_Medicament)
                    .HasForeignKey(pm => pm.IdMedicament);
                mb.HasOne(pm => pm.Prescription)
                    .WithMany(pe => pe.Prescription_Medicament)
                    .HasForeignKey(pm => pm.IdPrescription);
                mb.HasIndex(pm => pm.IdMedicament);
                mb.HasIndex(pm => pm.IdPrescription);
                mb.ToTable("Prescription_Medicament");
                mb.HasData(new Prescription_Medicament[]
                {
            new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose=3, Details="3 tygodniowo" },
            new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "1 dziennie" },
            new Prescription_Medicament { IdMedicament = 2, IdPrescription = 3, Dose = 1, Details = "1 dziennie" },
            new Prescription_Medicament { IdMedicament = 2, IdPrescription = 4, Dose = 5, Details = "5 dziennie" },
            new Prescription_Medicament { IdMedicament = 1, IdPrescription = 5, Dose = 2, Details = "2 tygodniowo" }
                });
            });
        }
    }
}