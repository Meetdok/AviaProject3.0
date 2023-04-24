using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebProject.WebModels;

namespace WebProject.Database
{
    public partial class user05_1Context : DbContext
    {
        public user05_1Context()
        {
        }

        public user05_1Context(DbContextOptions<user05_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Airplane> Airplanes { get; set; } = null!;
        public virtual DbSet<AirplaneClassFlight> AirplaneClassFlights { get; set; } = null!;
        public virtual DbSet<AirplanesClass> AirplanesClasses { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<FlightCompany> FlightCompanys { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServicesTicket> ServicesTickets { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.200.35;database=user05_1;user=user05;password=44084");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.HasKey(e => e.AirplanesId);

                entity.Property(e => e.AirplanesId).HasColumnName("AirplanesID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Airplanes)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Airplanes_AirplanesClass");
            });

            modelBuilder.Entity<AirplaneClassFlight>(entity =>
            {
                entity.HasKey(e => e.Idflight);

                entity.Property(e => e.Idflight).HasColumnName("IDFlight");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AirplaneClassFlights)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_AirplaneClassFlights_AirplanesClass1");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.AirplaneClassFlights)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_AirplaneClassFlights_Flights");
            });

            modelBuilder.Entity<AirplanesClass>(entity =>
            {
                entity.HasKey(e => e.AirplaneClassId);

                entity.ToTable("AirplanesClass");

                entity.Property(e => e.AirplaneClassId).HasColumnName("AirplaneClassID");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightsId);

                entity.Property(e => e.FlightsId).HasColumnName("FlightsID");

                entity.Property(e => e.FlightDate).HasColumnType("datetime");

                entity.Property(e => e.NumberOfSeats).HasColumnName("Number_of_seats");

                entity.HasOne(d => d.Airplane)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirplaneId)
                    .HasConstraintName("FK_Flights_Airplanes");

                entity.HasOne(d => d.FlightCompany)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.FlightCompanyId)
                    .HasConstraintName("FK_Flights_FlightCompanys");
            });

            modelBuilder.Entity<FlightCompany>(entity =>
            {
                entity.HasKey(e => e.FlightCompanysId);

                entity.Property(e => e.FlightCompanysId).HasColumnName("FlightCompanysID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.FlightCompanies)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_FlightCompanys_Services");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId)
                    .ValueGeneratedNever()
                    .HasColumnName("PostID");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ServiceCost).HasColumnType("money");
            });

            modelBuilder.Entity<ServicesTicket>(entity =>
            {
                entity.HasKey(e => e.ServiceTicketsId);

                entity.Property(e => e.ServiceTicketsId)
                    .ValueGeneratedNever()
                    .HasColumnName("ServiceTicketsID");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.ServicesTickets)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicesTickets_Services1");

                entity.HasOne(d => d.ItTicketNavigation)
                    .WithMany(p => p.ServicesTickets)
                    .HasForeignKey(d => d.ItTicket)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicesTickets_Tickets1");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.TicketCost).HasColumnType("money");

                entity.Property(e => e.TicketDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Users_Posts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
