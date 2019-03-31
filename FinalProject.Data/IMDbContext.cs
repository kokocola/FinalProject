using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FinalProject.Domain;

namespace FinalProject.Data
{
    public partial class IMDbContext : DbContext
    {
		public static string CONNECTION_STRING = "";
        public IMDbContext()
        {
			CONNECTION_STRING = "";
		}

        public IMDbContext(DbContextOptions<IMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(CONNECTION_STRING);
                //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=IMDb;Integrated Security=True;");
                optionsBuilder.UseSqlServer("Server=AUGUSTO-PC\\WINDOWSSERVER;Database=IMDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("titles", "dbo");

                entity.Property(e => e.TitleId)
                    .HasColumnName("titleId")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EndYear).HasColumnName("endYear");

                entity.Property(e => e.Genres)
                    .HasColumnName("genres")
                    .HasMaxLength(50);

                entity.Property(e => e.IsAdult).HasColumnName("isAdult");

                entity.Property(e => e.OriginalTitle)
                    .HasColumnName("originalTitle")
                    .HasMaxLength(1000);

                entity.Property(e => e.PrimaryTitle)
                    .HasColumnName("primaryTitle")
                    .HasMaxLength(1000);

                entity.Property(e => e.RuntimeMinutes).HasColumnName("runtimeMinutes");

                entity.Property(e => e.StartYear).HasColumnName("startYear");

                entity.Property(e => e.TitleType)
                    .HasColumnName("titleType")
                    .HasMaxLength(20);
            });
        }
    }
}
