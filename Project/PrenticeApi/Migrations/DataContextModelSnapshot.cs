﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrenticeApi.Models;

namespace PrenticeApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PrenticeApi.Models.AcademicType", b =>
                {
                    b.Property<short>("AcademicTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.HasKey("AcademicTypeId");

                    b.ToTable("AcademicTypes");

                    b.HasData(
                        new { AcademicTypeId = (short)1, Name = "Undergraduate Studies", ShortName = "U" },
                        new { AcademicTypeId = (short)2, Name = "Graduate Studies", ShortName = "G" },
                        new { AcademicTypeId = (short)3, Name = "Training Programs", ShortName = "T" }
                    );
                });

            modelBuilder.Entity("PrenticeApi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PrenticeApi.Models.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<short>("ProgramTypeId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("UserId");

                    b.HasKey("BatchId");

                    b.HasIndex("ProgramTypeId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("PrenticeApi.Models.BatchTerm", b =>
                {
                    b.Property<int>("BatchTermId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchId");

                    b.Property<short>("TermTypeId");

                    b.HasKey("BatchTermId");

                    b.HasIndex("BatchId");

                    b.HasIndex("TermTypeId");

                    b.ToTable("BatchTerms");
                });

            modelBuilder.Entity("PrenticeApi.Models.BatchTermCourse", b =>
                {
                    b.Property<short>("BatchTermCourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchTermId");

                    b.Property<int>("CourseId");

                    b.Property<decimal>("CreditPoint")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("BatchTermCourseId");

                    b.HasIndex("BatchTermId");

                    b.HasIndex("CourseId");

                    b.ToTable("BatchTermCourses");
                });

            modelBuilder.Entity("PrenticeApi.Models.BatchTermStudent", b =>
                {
                    b.Property<short>("BatchTermStudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchTermId");

                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.HasKey("BatchTermStudentId");

                    b.HasIndex("BatchTermId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("BatchTermStudents");
                });

            modelBuilder.Entity("PrenticeApi.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new { CourseId = 1, Code = "MITM301", Name = "Project Management and Business Info System" },
                        new { CourseId = 2, Code = "MITM302", Name = "Computer Programming" },
                        new { CourseId = 3, Code = "MITM304", Name = "Database Architecture and Administration" }
                    );
                });

            modelBuilder.Entity("PrenticeApi.Models.Institution", b =>
                {
                    b.Property<short>("InstitutionId");

                    b.Property<string>("Address");

                    b.Property<string>("ContactEmail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("WebSite");

                    b.HasKey("InstitutionId");

                    b.ToTable("Institutions");

                    b.HasData(
                        new { InstitutionId = (short)1, Address = "IIT, University of Dhaka, Dhaka, Bangladesh", ContactEmail = "iit@du.ac.bd", Name = "Institute of Information Technology, University of Dhaka", PhoneNumber = "8801779482994", ShortName = "IIT, DU", WebSite = "http://www.iit.du.ac.bd" }
                    );
                });

            modelBuilder.Entity("PrenticeApi.Models.ProgramType", b =>
                {
                    b.Property<short>("ProgramTypeId");

                    b.Property<short>("AcademicTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<byte>("Terms");

                    b.HasKey("ProgramTypeId");

                    b.HasIndex("AcademicTypeId");

                    b.ToTable("ProgramTypes");

                    b.HasData(
                        new { ProgramTypeId = (short)1, AcademicTypeId = (short)1, Name = "Bachelor of Science in Software Engineering", ShortName = "BSSE", Terms = (byte)8 },
                        new { ProgramTypeId = (short)2, AcademicTypeId = (short)2, Name = "Master of Science in Software Engineering", ShortName = "MSSE", Terms = (byte)4 },
                        new { ProgramTypeId = (short)3, AcademicTypeId = (short)2, Name = "Master in Information Technology", ShortName = "MIT", Terms = (byte)4 },
                        new { ProgramTypeId = (short)4, AcademicTypeId = (short)2, Name = "Post Graduate Diploma in Information Technology", ShortName = "PGDIT", Terms = (byte)4 },
                        new { ProgramTypeId = (short)5, AcademicTypeId = (short)3, Name = "Web Design", ShortName = "WD", Terms = (byte)1 },
                        new { ProgramTypeId = (short)6, AcademicTypeId = (short)3, Name = "Web Programming", ShortName = "WP", Terms = (byte)1 },
                        new { ProgramTypeId = (short)7, AcademicTypeId = (short)3, Name = "Office Applications", ShortName = "OA", Terms = (byte)1 },
                        new { ProgramTypeId = (short)8, AcademicTypeId = (short)3, Name = "Matlab-Origin-LaTeX", ShortName = "MOL", Terms = (byte)1 }
                    );
                });

            modelBuilder.Entity("PrenticeApi.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dob");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("RegistrationNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("RollNo");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("PrenticeApi.Models.TermType", b =>
                {
                    b.Property<short>("TermTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("TermTypeId");

                    b.ToTable("TermTypes");

                    b.HasData(
                        new { TermTypeId = (short)1, Name = "None" },
                        new { TermTypeId = (short)2, Name = "Semester" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PrenticeApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PrenticeApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PrenticeApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PrenticeApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PrenticeApi.Models.Batch", b =>
                {
                    b.HasOne("PrenticeApi.Models.ProgramType", "ProgramType")
                        .WithMany("Batches")
                        .HasForeignKey("ProgramTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PrenticeApi.Models.BatchTerm", b =>
                {
                    b.HasOne("PrenticeApi.Models.Batch", "Batch")
                        .WithMany("BatchTerms")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PrenticeApi.Models.TermType", "TermType")
                        .WithMany("BatchTerms")
                        .HasForeignKey("TermTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PrenticeApi.Models.BatchTermCourse", b =>
                {
                    b.HasOne("PrenticeApi.Models.BatchTerm", "BatchTerm")
                        .WithMany("BatchCourses")
                        .HasForeignKey("BatchTermId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PrenticeApi.Models.Course", "Course")
                        .WithMany("BatchTermCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PrenticeApi.Models.BatchTermStudent", b =>
                {
                    b.HasOne("PrenticeApi.Models.BatchTerm", "BatchTerm")
                        .WithMany("BatchTermStudents")
                        .HasForeignKey("BatchTermId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PrenticeApi.Models.Course", "Course")
                        .WithMany("BatchTermStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PrenticeApi.Models.Student", "Student")
                        .WithMany("BatchTermStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PrenticeApi.Models.ProgramType", b =>
                {
                    b.HasOne("PrenticeApi.Models.AcademicType", "AcademicType")
                        .WithMany("ProgramTypes")
                        .HasForeignKey("AcademicTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
