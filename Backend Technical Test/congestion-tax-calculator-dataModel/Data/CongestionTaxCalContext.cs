using System;
using congestion_tax_calculator_dataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace congestion_tax_calculator_dataModel.Data
{
    public partial class CongestionTaxCalContext : DbContext
    {
        public CongestionTaxCalContext()
        {
        }

        public CongestionTaxCalContext(DbContextOptions<CongestionTaxCalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CityDaysTaxNotCharged> CityDaysTaxNotCharged { get; set; }
        public virtual DbSet<CityExceptionVehicle> CityExceptionVehicle { get; set; }
        public virtual DbSet<CityHourTaxChargedAmount> CityHourTaxChargedAmount { get; set; }
        public virtual DbSet<CityMonthNotCharged> CityMonthNotCharged { get; set; }
        public virtual DbSet<CityOtherRule> CityOtherRule { get; set; }
        public virtual DbSet<CityPublicHolidays> CityPublicHolidays { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IKJUHBV;Database=CongestionTaxCal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity);

                entity.Property(e => e.CityName).HasMaxLength(50);
            });

            modelBuilder.Entity<CityDaysTaxNotCharged>(entity =>
            {
                entity.HasKey(e => e.IdCityDaysTaxNotCharged);

                entity.Property(e => e.DayInAweek).HasComment(@"1=Sunday
2=Monday
3=Tuesday
4=Wensday
5=Thursday
6=Friday
7=Saturday");

                entity.Property(e => e.Fkcity).HasColumnName("FKCity");

                entity.HasOne(d => d.FkcityNavigation)
                    .WithMany(p => p.CityDaysTaxNotCharged)
                    .HasForeignKey(d => d.Fkcity)
                    .HasConstraintName("FK_CityDaysTaxNotCharged_City");
            });

            modelBuilder.Entity<CityExceptionVehicle>(entity =>
            {
                entity.HasKey(e => e.IdCityExceptVehicle);

                entity.HasOne(d => d.CityFkNavigation)
                    .WithMany(p => p.CityExceptionVehicle)
                    .HasForeignKey(d => d.CityFk)
                    .HasConstraintName("FK_CityExceptionVehicle_City");

                entity.HasOne(d => d.VehicleFkNavigation)
                    .WithMany(p => p.CityExceptionVehicle)
                    .HasForeignKey(d => d.VehicleFk)
                    .HasConstraintName("FK_CityExceptionVehicle_Vehicle");
            });

            modelBuilder.Entity<CityHourTaxChargedAmount>(entity =>
            {
                entity.HasKey(e => e.IdHourTaxCharged)
                    .HasName("PK_HourTaxChargedAmount");

                entity.Property(e => e.CityFk).HasColumnName("CityFK");

                entity.HasOne(d => d.CityFkNavigation)
                    .WithMany(p => p.CityHourTaxChargedAmount)
                    .HasForeignKey(d => d.CityFk)
                    .HasConstraintName("FK_HourTaxChargedAmount_City");
            });

            modelBuilder.Entity<CityMonthNotCharged>(entity =>
            {
                entity.HasKey(e => e.IdCityMonthTaxNotCharged);

                entity.Property(e => e.Fkcity).HasColumnName("FKCity");

                entity.Property(e => e.MonthTaxNotCharged).HasComment(@"1=Jan
2=Feb
3=Mar
4=Apr
5=May
,.......");

                entity.HasOne(d => d.FkcityNavigation)
                    .WithMany(p => p.CityMonthNotCharged)
                    .HasForeignKey(d => d.Fkcity)
                    .HasConstraintName("FK_CityMonthNotCharged_City");
            });

            modelBuilder.Entity<CityOtherRule>(entity =>
            {
                entity.HasKey(e => e.IdOtherRules)
                    .HasName("PK_RuleType");

                entity.Property(e => e.RuleDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CityFkNavigation)
                    .WithMany(p => p.CityOtherRule)
                    .HasForeignKey(d => d.CityFk)
                    .HasConstraintName("FK_RuleType_City");
            });

            modelBuilder.Entity<CityPublicHolidays>(entity =>
            {
                entity.HasKey(e => e.IdCityPublicHolidays);

                entity.Property(e => e.CityFk).HasColumnName("CityFK");

                entity.Property(e => e.Holiday).HasColumnType("date");

                entity.HasOne(d => d.CityFkNavigation)
                    .WithMany(p => p.CityPublicHolidays)
                    .HasForeignKey(d => d.CityFk)
                    .HasConstraintName("FK_CityPublicHolidays_City");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.IdVehicle);

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
