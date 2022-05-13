using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class FlightBookingApplicationDBContext : DbContext
    {
        public FlightBookingApplicationDBContext()
        {
        }

        public FlightBookingApplicationDBContext(DbContextOptions<FlightBookingApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAirlines> TblAirlines { get; set; }
        public virtual DbSet<TblBooking> TblBookings { get; set; }
        public virtual DbSet<TblDiscount> TblDiscounts { get; set; }
        public virtual DbSet<TblFlight> TblFlights { get; set; }
        public virtual DbSet<TblPassenger> TblPassengers { get; set; }
        public virtual DbSet<TblSchedule> TblSchedules { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET35;Initial Catalog=FlightBookingApplicationDB;User ID=sa;Password=pass@word1;Persist security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAirlines>(entity =>
            {
                entity.HasKey(e => e.AirlineId);

                entity.ToTable("tblAirline");

                entity.Property(e => e.AirlineId).HasMaxLength(100);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AirlineLogo)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AirlineName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblBooking>(entity =>
            {
                entity.HasKey(e => e.Pnrid);

                entity.ToTable("tblBookings");

                entity.Property(e => e.Pnrid)
                    .HasMaxLength(200)
                    .HasColumnName("PNRID");

                entity.Property(e => e.AirlineId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FlightId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModeOfPayment)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TripDate).HasColumnType("datetime");

                entity.Property(e => e.TripType)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblDiscount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("tblDiscounts");

                entity.Property(e => e.DiscountId).HasMaxLength(100);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AppliedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblFlight>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("tblFlight");

                entity.Property(e => e.FlightId).HasMaxLength(100);

                entity.Property(e => e.AirlineId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InstrumentUsed)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPassenger>(entity =>
            {
                entity.HasKey(e => e.PassengerId);

                entity.ToTable("tblPassenger");

                entity.Property(e => e.PassengerId).HasMaxLength(100);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MealPreference)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Pnrid)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("PNRID");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ScheduleId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SeatNo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SeatType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TotalPrice)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.ToTable("tblSchedules");

                entity.Property(e => e.ScheduleId).HasMaxLength(100);

                entity.Property(e => e.AirlineId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ArrivalTime).HasColumnType("datetime");

                entity.Property(e => e.BusinessTicketPrice).HasColumnType("money");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartureTime).HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FlightId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MealPreferences)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NonBusinessTicketPrice).HasColumnType("money");

                entity.Property(e => e.ScheduledDays)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUsers");

                entity.Property(e => e.UserId)
                    .HasMaxLength(200)
                    .HasColumnName("UserID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("EmailID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
