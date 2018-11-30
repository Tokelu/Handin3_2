using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Handin3_2.Models
{
    public partial class PersonKartotekDBContext : DbContext
    {
        public PersonKartotekDBContext()
        {
        }

        public PersonKartotekDBContext(DbContextOptions<PersonKartotekDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<EmailAddr> EmailAddr { get; set; }
        public virtual DbSet<LivesOn> LivesOn { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAddressRelations> PersonAddressRelations { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PersonKartotekDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsRegisteredAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoadName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("fk_Address");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailAddr>(entity =>
            {
                entity.HasKey(e => e.EmailId);

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailAddr1)
                    .IsRequired()
                    .HasColumnName("EmailAddr")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.EmailAddr)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EmailAddr");
            });

            modelBuilder.Entity<LivesOn>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.AddressId });

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.LivesOn)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_LivesOn2");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.LivesOn)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LivesOn");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteId)
                    .HasColumnName("NoteID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Note1).HasColumnName("Note");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fk_Note");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ContactType)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonAddressRelations>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.AddressId });

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PersonAddressRelations)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonAddressRelations_Address");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAddressRelations)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonAddressRelations_Person");
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.HasKey(e => e.PhoneId);

                entity.Property(e => e.PhoneId)
                    .HasColumnName("PhoneID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PhoneNumber1).HasColumnName("PhoneNumber");

                entity.Property(e => e.PhoneType)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Provider)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PhoneNumber)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PhoneNumber");
            });
        }
    }
}
