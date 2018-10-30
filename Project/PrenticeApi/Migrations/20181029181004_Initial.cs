using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrenticeApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicTypes",
                columns: table => new
                {
                    AcademicTypeId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicTypes", x => x.AcademicTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    ShortName = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    RegistrationNo = table.Column<string>(maxLength: 20, nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    RollNo = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "TermTypes",
                columns: table => new
                {
                    TermTypeId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermTypes", x => x.TermTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramTypes",
                columns: table => new
                {
                    ProgramTypeId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(maxLength: 10, nullable: false),
                    Terms = table.Column<byte>(nullable: false),
                    AcademicTypeId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTypes", x => x.ProgramTypeId);
                    table.ForeignKey(
                        name: "FK_ProgramTypes_AcademicTypes_AcademicTypeId",
                        column: x => x.AcademicTypeId,
                        principalTable: "AcademicTypes",
                        principalColumn: "AcademicTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    BatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    ProgramTypeId = table.Column<short>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_Batches_ProgramTypes_ProgramTypeId",
                        column: x => x.ProgramTypeId,
                        principalTable: "ProgramTypes",
                        principalColumn: "ProgramTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatchTerms",
                columns: table => new
                {
                    BatchTermId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatchId = table.Column<int>(nullable: false),
                    TermTypeId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchTerms", x => x.BatchTermId);
                    table.ForeignKey(
                        name: "FK_BatchTerms_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchTerms_TermTypes_TermTypeId",
                        column: x => x.TermTypeId,
                        principalTable: "TermTypes",
                        principalColumn: "TermTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatchTermCourses",
                columns: table => new
                {
                    BatchTermCourseId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatchTermId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchTermCourses", x => x.BatchTermCourseId);
                    table.ForeignKey(
                        name: "FK_BatchTermCourses_BatchTerms_BatchTermId",
                        column: x => x.BatchTermId,
                        principalTable: "BatchTerms",
                        principalColumn: "BatchTermId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchTermCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicTypes",
                columns: new[] { "AcademicTypeId", "Name", "ShortName" },
                values: new object[,]
                {
                    { (short)1, "Undergraduate Studies", "U" },
                    { (short)2, "Graduate Studies", "G" },
                    { (short)3, "Training Programs", "T" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "MITM301", "Project Management and Business Info System" },
                    { 2, "MITM302", "Computer Programming" },
                    { 3, "MITM304", "Database Architecture and Administration" }
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "InstitutionId", "Address", "ContactEmail", "Name", "PhoneNumber", "ShortName", "WebSite" },
                values: new object[] { (short)1, "IIT, University of Dhaka, Dhaka, Bangladesh", "iit@du.ac.bd", "Institute of Information Technology, University of Dhaka", "8801779482994", "IIT, DU", "http://www.iit.du.ac.bd" });

            migrationBuilder.InsertData(
                table: "TermTypes",
                columns: new[] { "TermTypeId", "Name" },
                values: new object[,]
                {
                    { (short)1, "None" },
                    { (short)2, "Semester" }
                });

            migrationBuilder.InsertData(
                table: "ProgramTypes",
                columns: new[] { "ProgramTypeId", "AcademicTypeId", "Name", "ShortName", "Terms" },
                values: new object[,]
                {
                    { (short)1, (short)1, "Bachelor of Science in Software Engineering", "BSSE", (byte)8 },
                    { (short)2, (short)2, "Master of Science in Software Engineering", "MSSE", (byte)4 },
                    { (short)3, (short)2, "Master in Information Technology", "MIT", (byte)4 },
                    { (short)4, (short)2, "Post Graduate Diploma in Information Technology", "PGDIT", (byte)4 },
                    { (short)5, (short)3, "Web Design", "WD", (byte)1 },
                    { (short)6, (short)3, "Web Programming", "WP", (byte)1 },
                    { (short)7, (short)3, "Office Applications", "OA", (byte)1 },
                    { (short)8, (short)3, "Matlab-Origin-LaTeX", "MOL", (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ProgramTypeId",
                table: "Batches",
                column: "ProgramTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTermCourses_BatchTermId",
                table: "BatchTermCourses",
                column: "BatchTermId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTermCourses_CourseId",
                table: "BatchTermCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTerms_BatchId",
                table: "BatchTerms",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchTerms_TermTypeId",
                table: "BatchTerms",
                column: "TermTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTypes_AcademicTypeId",
                table: "ProgramTypes",
                column: "AcademicTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BatchTermCourses");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BatchTerms");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "TermTypes");

            migrationBuilder.DropTable(
                name: "ProgramTypes");

            migrationBuilder.DropTable(
                name: "AcademicTypes");
        }
    }
}
