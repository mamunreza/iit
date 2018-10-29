using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PrenticeApi.Models
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Institution> Institutions { get; set; }
        public DbSet<AcademicType> AcademicTypes { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configuration();
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Configuration(this ModelBuilder modelBuilder)
        {
            // Institution
            modelBuilder.Entity<Institution>().Property(x => x.InstitutionId)
                .ValueGeneratedNever();
            modelBuilder.Entity<Institution>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Institution>().Property(x => x.ShortName)
                .IsRequired()
                .HasMaxLength(20);

            // Academic type
            modelBuilder.Entity<AcademicType>().Property(x => x.AcademicTypeId)
                .ValueGeneratedNever();
            modelBuilder.Entity<AcademicType>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<AcademicType>().Property(x => x.ShortName)
                .IsRequired()
                .HasMaxLength(3);

            // Program type
            modelBuilder.Entity<ProgramType>()
                .HasOne(x => x.AcademicType)
                .WithMany(y => y.ProgramTypes)
                .HasForeignKey(x => x.AcademicTypeId);

            modelBuilder.Entity<ProgramType>().Property(x => x.ProgramTypeId)
                .ValueGeneratedNever();
            modelBuilder.Entity<ProgramType>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<ProgramType>().Property(x => x.ShortName)
                .IsRequired()
                .HasMaxLength(10);

            // Course
            modelBuilder.Entity<Course>().Property(x =>x.CourseId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Course>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Course>().Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(10);
            

        }
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Institution
            modelBuilder.Entity<Institution>().HasData(
                new Institution
                {
                    InstitutionId = 1,
                    Name = "Institute of Information Technology, University of Dhaka",
                    ShortName = "IIT, DU",
                    Address = "IIT, University of Dhaka, Dhaka, Bangladesh",
                    PhoneNumber = "8801779482994",
                    WebSite = "http://www.iit.du.ac.bd",
                    ContactEmail = "iit@du.ac.bd"
                }
            );

            // Academic type
            AcademicType atUnderGrad = new AcademicType { AcademicTypeId = 1, Name = "Undergraduate Studies", ShortName = "U" };
            AcademicType atGrad = new AcademicType { AcademicTypeId = 2, Name = "Graduate Studies", ShortName = "G" };
            AcademicType atTraining = new AcademicType { AcademicTypeId = 3, Name = "Training Programs", ShortName = "T" };
            modelBuilder.Entity<AcademicType>().HasData(
                atUnderGrad,
                atGrad,
                atTraining
            );

            // Program type
            ProgramType programTypeBSSE = new ProgramType
            {
                ProgramTypeId = 1,
                Name = "Bachelor of Science in Software Engineering",
                ShortName = "BSSE",
                AcademicTypeId = 1
            };
            ProgramType programTypeMSSE = new ProgramType
            {
                ProgramTypeId = 2,
                Name = "Master of Science in Software Engineering",
                ShortName = "MSSE",
                AcademicTypeId = 2
            };
            ProgramType programTypeMIT = new ProgramType
            {
                ProgramTypeId = 3,
                Name = "Master in Information Technology",
                ShortName = "MIT",
                AcademicTypeId = 2
            };
            ProgramType programTypePGDIT = new ProgramType
            {
                ProgramTypeId = 4,
                Name = "Post Graduate Diploma in Information Technology",
                ShortName = "PGDIT",
                AcademicTypeId = 2
            };
            ProgramType programTypeWD = new ProgramType
            {
                ProgramTypeId = 5,
                Name = "Web Design",
                ShortName = "WD",
                AcademicTypeId = 3
            };
            ProgramType programTypeWP = new ProgramType
            {
                ProgramTypeId = 6,
                Name = "Web Programming",
                ShortName = "WP",
                AcademicTypeId = 3
            };
            ProgramType programTypeOA = new ProgramType
            {
                ProgramTypeId = 7,
                Name = "Office Applications",
                ShortName = "OA",
                AcademicTypeId = 3
            };
            ProgramType programTypeMOL = new ProgramType
            {
                ProgramTypeId = 8,
                Name = "Matlab-Origin-LaTeX",
                ShortName = "MOL",
                AcademicTypeId = 3
            };

            // modelBuilder.Entity<ProgramType>(a =>
            // {
            //     a.HasData(programTypeBSSE);
            //     a.OwnsOne(e => e.AcademicType).HasData(atUnderGrad);
            // });

            modelBuilder.Entity<ProgramType>().HasData(
                programTypeBSSE, programTypeMSSE, programTypeMIT, programTypePGDIT,
                programTypeWD, programTypeWP, programTypeOA, programTypeMOL
            );
        }
    }
}
