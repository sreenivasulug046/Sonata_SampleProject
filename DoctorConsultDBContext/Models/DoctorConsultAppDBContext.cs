using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoctorConsultDBContext.Models
{
    public partial class DoctorConsultAppDBContext : DbContext
    {
        public DoctorConsultAppDBContext()
        {
        }

        public DoctorConsultAppDBContext(DbContextOptions<DoctorConsultAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=DESKTOP-OG209QT\\SQLEXPRESS; initial catalog=DoctorConsultAppDB; integrated security=True; MultipleActiveResultSets=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndTime).HasColumnName("End_Time");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Problem)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnName("Start_Time");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorId");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.Age).HasColumnName("Age");

                //entity.HasOne(d => d.Doctor)
                //    .WithMany()
                //    .HasForeignKey(d => d.DoctorId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("FK__Booking__DoctorI__00200768");

                //entity.HasOne(d => d.User)
                //    .WithMany()
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("FK__Booking__UserId__7F2BE32F");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.HasIndex(e => e.Email, "UQ__Doctor__A9D105347BD35D48")
                    .IsUnique();

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhNo).HasMaxLength(10);

                entity.Property(e => e.Specilization)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Prescription");

                entity.Property(e => e.AdditionalSuggestion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Additional_Suggestion");

                entity.Property(e => e.PrescriptionId).ValueGeneratedOnAdd();

                entity.Property(e => e.PrescriptionImage).HasColumnName("Prescription_Image");

                //entity.HasOne(d => d.Doctor)
                //    .WithMany()
                //    .HasForeignKey(d => d.DoctorId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("FK__Prescript__Docto__1ED998B2");      //[FK__Booking__DoctorI__267ABA7A]

                //entity.HasOne(d => d.User)
                //    .WithMany()
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("FK__Prescript__UserI__1FCDBCEB");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Slot");

                entity.Property(e => e.SlotAvailability)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SDate).HasColumnType("SDate");

                entity.Property(e => e.EndTime).HasColumnName("End_Time");

                entity.Property(e => e.SlotId).ValueGeneratedOnAdd();

                entity.Property(e => e.StartTime).HasColumnName("Start_Time");

                //entity.HasOne(d => d.Doctor)
                //    .WithMany()
                //    .HasForeignKey(d => d.DoctorId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("FK__Slot__DoctorId__1CF15040");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534A70E1196")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhNo).HasMaxLength(10);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
