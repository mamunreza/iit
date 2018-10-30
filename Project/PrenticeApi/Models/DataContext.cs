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
        public DbSet<TermType> TermTypes { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BatchTerm> BatchTerms { get; set; }
        public DbSet<BatchTermCourse> BatchTermCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration();
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void ApplyConfiguration(this ModelBuilder modelBuilder)
        {
            InstitutionConfiguration(modelBuilder);
            AcademicTypeConfiguration(modelBuilder);
            ProgramTypeConfiguration(modelBuilder);
            CourseConfiguration(modelBuilder);
            TermTypeConfiguration(modelBuilder);
            BatchConfiguration(modelBuilder);
            StudentConfiguration(modelBuilder);
            BatchTermConfiguration(modelBuilder);
            BatchTermCourseConfiguration(modelBuilder);
        }

        private static void TermTypeConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TermType>().Property(x => x.TermTypeId)
                            .ValueGeneratedNever();
            modelBuilder.Entity<TermType>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
        }

        private static void CourseConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(x => x.CourseId)
                            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Course>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Course>().Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(10);
        }

        private static void ProgramTypeConfiguration(ModelBuilder modelBuilder)
        {
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
        }

        private static void AcademicTypeConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicType>().Property(x => x.AcademicTypeId)
                            .ValueGeneratedNever();
            modelBuilder.Entity<AcademicType>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<AcademicType>().Property(x => x.ShortName)
                .IsRequired()
                .HasMaxLength(3);
        }

        private static void InstitutionConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>().Property(x => x.InstitutionId)
                .ValueGeneratedNever();
            modelBuilder.Entity<Institution>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Institution>().Property(x => x.ShortName)
                .IsRequired()
                .HasMaxLength(20);
        }

        private static void BatchConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>()
                            .HasOne(x => x.ProgramType)
                            .WithMany(y => y.Batches)
                            .HasForeignKey(x => x.ProgramTypeId);

            modelBuilder.Entity<Batch>().Property(x => x.BatchId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Batch>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Batch>().Property(x => x.StartDate)
                .IsRequired();
            modelBuilder.Entity<Batch>().Property(x => x.EndDate)
                .IsRequired();
        }

        private static void StudentConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(x => x.StudentId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>().Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(x => x.RegistrationNo)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Student>().Property(x => x.Dob)
                .IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.RegistrationDate)
                .IsRequired();
        }
        private static void BatchTermCourseConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatchTermCourse>()
                            .HasOne(x => x.Course)
                            .WithMany(y => y.BatchTermCourses)
                            .HasForeignKey(x => x.CourseId);
            // modelBuilder.Entity<BatchCourse>()
            //                 .HasOne(x => x.Batch)
            //                 .WithMany(y => y.BatchCourses)
            //                 .HasForeignKey(x => x.BatchId);
            modelBuilder.Entity<BatchTermCourse>().Property(x => x.BatchTermCourseId)
                .ValueGeneratedOnAdd();
        }
        private static void BatchTermConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatchTerm>()
                            .HasOne(x => x.Batch)
                            .WithMany(y => y.BatchTerms)
                            .HasForeignKey(x => x.BatchId);
            modelBuilder.Entity<BatchTerm>()
                            .HasOne(x => x.TermType)
                            .WithMany(y => y.BatchTerms)
                            .HasForeignKey(x => x.TermTypeId);
            modelBuilder.Entity<BatchTerm>().Property(x => x.BatchTermId)
                .ValueGeneratedOnAdd();
        }
        public static void Seed(this ModelBuilder modelBuilder)
        {
            InstitutionSeedData(modelBuilder);
            AcademicTypeSeedData(modelBuilder);
            ProgramTypeSeedData(modelBuilder);
            TermTypeSeedData(modelBuilder);

            CourseSeedData(modelBuilder);

            // modelBuilder.Entity<ProgramType>(a =>
            // {
            //     a.HasData(programTypeBSSE);
            //     a.OwnsOne(e => e.AcademicType).HasData(atUnderGrad);
            // });


        }

        private static void TermTypeSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TermType>().HasData(
                            new TermType
                            {
                                TermTypeId = 1,
                                Name = "None"
                            },
                            new TermType
                            {
                                TermTypeId = 2,
                                Name = "Semester"
                            }
                        );
        }

        private static void ProgramTypeSeedData(ModelBuilder modelBuilder)
        {
            ProgramType programTypeBSSE = new ProgramType
            {
                ProgramTypeId = 1,
                Name = "Bachelor of Science in Software Engineering",
                ShortName = "BSSE",
                Terms = 8,
                AcademicTypeId = 1
            };
            ProgramType programTypeMSSE = new ProgramType
            {
                ProgramTypeId = 2,
                Name = "Master of Science in Software Engineering",
                ShortName = "MSSE",
                Terms = 4,
                AcademicTypeId = 2
            };
            ProgramType programTypeMIT = new ProgramType
            {
                ProgramTypeId = 3,
                Name = "Master in Information Technology",
                ShortName = "MIT",
                Terms = 4,
                AcademicTypeId = 2
            };
            ProgramType programTypePGDIT = new ProgramType
            {
                ProgramTypeId = 4,
                Name = "Post Graduate Diploma in Information Technology",
                ShortName = "PGDIT",
                Terms = 4,
                AcademicTypeId = 2
            };
            ProgramType programTypeWD = new ProgramType
            {
                ProgramTypeId = 5,
                Name = "Web Design",
                ShortName = "WD",
                Terms = 1,
                AcademicTypeId = 3
            };
            ProgramType programTypeWP = new ProgramType
            {
                ProgramTypeId = 6,
                Name = "Web Programming",
                ShortName = "WP",
                Terms = 1,
                AcademicTypeId = 3
            };
            ProgramType programTypeOA = new ProgramType
            {
                ProgramTypeId = 7,
                Name = "Office Applications",
                ShortName = "OA",
                Terms = 1,
                AcademicTypeId = 3
            };
            ProgramType programTypeMOL = new ProgramType
            {
                ProgramTypeId = 8,
                Name = "Matlab-Origin-LaTeX",
                ShortName = "MOL",
                Terms = 1,
                AcademicTypeId = 3
            };

            modelBuilder.Entity<ProgramType>().HasData(
                programTypeBSSE, programTypeMSSE, programTypeMIT, programTypePGDIT,
                programTypeWD, programTypeWP, programTypeOA, programTypeMOL
            );
        }

        private static void AcademicTypeSeedData(ModelBuilder modelBuilder)
        {
            AcademicType atUnderGrad = new AcademicType { AcademicTypeId = 1, Name = "Undergraduate Studies", ShortName = "U" };
            AcademicType atGrad = new AcademicType { AcademicTypeId = 2, Name = "Graduate Studies", ShortName = "G" };
            AcademicType atTraining = new AcademicType { AcademicTypeId = 3, Name = "Training Programs", ShortName = "T" };
            modelBuilder.Entity<AcademicType>().HasData(
                atUnderGrad,
                atGrad,
                atTraining
            );
        }

        private static void InstitutionSeedData(ModelBuilder modelBuilder)
        {
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
        }

        private static void CourseSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                            new Course
                            {
                                CourseId = 1,
                                Name = "Project Management and Business Info System",
                                Code = "MITM301"
                            },
                            new Course
                            {
                                CourseId = 2,
                                Name = "Computer Programming",
                                Code = "MITM302"
                            },
                            new Course
                            {
                                CourseId = 3,
                                Name = "Database Architecture and Administration",
                                Code = "MITM304"
                            }
                        );
        }


    }
}
