using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lesson1WebApplication.EF
{
    public partial class LearningCenterContext : DbContext
    {
        public LearningCenterContext()
            : base("name=LearningCenterContext")
        {
        }

        public virtual DbSet<CourseLocation> CourseLocation { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<CourseStream> CourseStream { get; set; }
        public virtual DbSet<Curriculum> Curriculum { get; set; }
        public virtual DbSet<Lecturers> Lecturers { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>()
                .HasMany(e => e.CourseStream)
                .WithRequired(e => e.Courses)
                .HasForeignKey(e => e.CourseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseStream>()
                .HasMany(e => e.CourseLocation)
                .WithRequired(e => e.CourseStream)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseStream>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.CourseStream)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curriculum>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Curriculum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lecturers>()
                .HasMany(e => e.Curriculum)
                .WithRequired(e => e.Lecturers)
                .HasForeignKey(e => e.LecturerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Locations>()
                .HasMany(e => e.CourseLocation)
                .WithRequired(e => e.Locations)
                .HasForeignKey(e => e.LocationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Locations>()
                .HasMany(e => e.Locations1)
                .WithOptional(e => e.Locations2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<Subjects>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Subjects>()
                .HasMany(e => e.Curriculum)
                .WithRequired(e => e.Subjects)
                .HasForeignKey(e => e.SubjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.IDNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.StudentID)
                .WillCascadeOnDelete(false);
        }
    }
}
