using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REPETITEURLINK.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "DirectoryItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Kind = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectoryItems_DirectoryItems_CityId",
                        column: x => x.CityId,
                        principalTable: "DirectoryItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DirectoryItems_DirectoryItems_CountryId",
                        column: x => x.CountryId,
                        principalTable: "DirectoryItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessagePayloads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    TextContent = table.Column<string>(type: "text", nullable: false),
                    MediaUrl = table.Column<string>(type: "text", nullable: false),
                    MediaType = table.Column<string>(type: "text", nullable: false),
                    MediaSize = table.Column<decimal>(type: "numeric", nullable: false),
                    _ExtraJson = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagePayloads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    status = table.Column<int>(type: "integer", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AverageHourlyRate = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerificationCertifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    CertificationType = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationCertifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelSubjectEncadreurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    SubjectEncadreurId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectEncadreur = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelSubjectEncadreurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelSubjectEncadreurs_DirectoryItems_SchoolLevelId",
                        column: x => x.SchoolLevelId,
                        principalTable: "DirectoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Role = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    ParentSubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentSubjectType = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Sexe = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    EmailVerifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_DirectoryItems_CityId",
                        column: x => x.CityId,
                        principalTable: "DirectoryItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentCertifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    VerificationCertificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DocumentUrl = table.Column<string>(type: "text", nullable: false),
                    DocumentSize = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentCertifications_VerificationCertifications_Verificat~",
                        column: x => x.VerificationCertificationId,
                        principalTable: "VerificationCertifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encadreurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCertified = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encadreurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encadreurs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageRequestCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestCourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    MessagePayloadId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageRequestCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageRequestCourses_MessagePayloads_MessagePayloadId",
                        column: x => x.MessagePayloadId,
                        principalTable: "MessagePayloads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageRequestCourses_RequestCourses_RequestCourseId",
                        column: x => x.RequestCourseId,
                        principalTable: "RequestCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageRequestCourses_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageRequestCourses_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Sexe = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: false),
                    EmailVerifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_DirectoryItems_CityId",
                        column: x => x.CityId,
                        principalTable: "DirectoryItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_DirectoryItems_SchoolLevelId",
                        column: x => x.SchoolLevelId,
                        principalTable: "DirectoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectEncadreurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    EncadreurId = table.Column<Guid>(type: "uuid", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectEncadreurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectEncadreurs_Encadreurs_EncadreurId",
                        column: x => x.EncadreurId,
                        principalTable: "Encadreurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectEncadreurs_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repetitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EncadreurId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestCourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    DayOfWeeks = table.Column<int[]>(type: "integer[]", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repetitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repetitions_Encadreurs_EncadreurId",
                        column: x => x.EncadreurId,
                        principalTable: "Encadreurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repetitions_RequestCourses_RequestCourseId",
                        column: x => x.RequestCourseId,
                        principalTable: "RequestCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repetitions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectRepetitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    RepetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectRepetitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectRepetitions_Repetitions_RepetitionId",
                        column: x => x.RepetitionId,
                        principalTable: "Repetitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectRepetitions_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionRepetitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DayOfWeek = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    RepetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectRepetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionRepetitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionRepetitions_Repetitions_RepetitionId",
                        column: x => x.RepetitionId,
                        principalTable: "Repetitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionRepetitions_SubjectRepetitions_SubjectRepetitionId",
                        column: x => x.SubjectRepetitionId,
                        principalTable: "SubjectRepetitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    SessionRepetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    MessagePayloadId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageSessions_MessagePayloads_MessagePayloadId",
                        column: x => x.MessagePayloadId,
                        principalTable: "MessagePayloads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageSessions_SessionRepetitions_SessionRepetitionId",
                        column: x => x.SessionRepetitionId,
                        principalTable: "SessionRepetitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageSessions_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageSessions_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DirectoryItems",
                columns: new[] { "Id", "CityId", "CountryId", "CreatedAt", "DeletedOn", "DisplayName", "IsDeleted", "Symbol", "UpdatedAt", "Value", "Kind" },
                values: new object[,]
                {
                    { new Guid("025e1c40-4593-47de-bc4e-b389c91c45fb"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Form 1", false, null, null, "FORM_1", "SchoolClassLevel" },
                    { new Guid("18972a21-ee93-45fe-b337-8e1ec2a7657b"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Première", false, null, null, "PREMIERE", "SchoolClassLevel" },
                    { new Guid("1d54025c-b1d8-4baf-8aac-0d37a14d4e52"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Upper Sixth", false, null, null, "UPPER_SIXTH", "SchoolClassLevel" },
                    { new Guid("22398de3-c316-41ff-a09d-41f15a856ba4"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Form 4", false, null, null, "FORM_4", "SchoolClassLevel" },
                    { new Guid("262aef51-3b3e-4f52-8bb2-f912b288b7c0"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Master 1", false, null, null, "M1", "SchoolClassLevel" },
                    { new Guid("278b6e0a-f892-43e5-803e-5322c78620f3"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Class 5", false, null, null, "CLASS_5", "SchoolClassLevel" },
                    { new Guid("28a67a7d-03ef-40df-b91b-3ce45a6bcfb1"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Troisième", false, null, null, "3E", "SchoolClassLevel" },
                    { new Guid("2b4d8461-240b-4e1b-84f4-f7148b4da0d3"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Quatrième", false, null, null, "4E", "SchoolClassLevel" },
                    { new Guid("350641cf-22c4-45b6-a222-8ce2b93a1770"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Class 4", false, null, null, "CLASS_4", "SchoolClassLevel" },
                    { new Guid("399f1a29-ab8f-409a-abd8-b936c3f66f29"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Master 2", false, null, null, "M2", "SchoolClassLevel" },
                    { new Guid("4ccc720d-cb3f-4915-a268-43e6e699d3b2"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Cinquième", false, null, null, "5E", "SchoolClassLevel" },
                    { new Guid("5330d345-8ecf-4a94-8de2-742d448c52fb"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FCFA", false, "XAF", null, "XAF", "Currency" },
                    { new Guid("64478a7c-f553-4409-9b20-aa5eda6010bd"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Form 2", false, null, null, "FORM_2", "SchoolClassLevel" },
                    { new Guid("6896174a-96f1-456e-83a5-de5861d9123b"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Class 1", false, null, null, "CLASS_1", "SchoolClassLevel" },
                    { new Guid("6b4435c7-ba35-4ed4-9281-4e10092b3cfc"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Class 3", false, null, null, "CLASS_3", "SchoolClassLevel" },
                    { new Guid("8092a7e1-6773-4ead-9204-15c653bbb55a"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Form 3", false, null, null, "FORM_3", "SchoolClassLevel" },
                    { new Guid("877636e7-73a4-498a-b12a-96d78424d123"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Class 2", false, null, null, "CLASS_2", "SchoolClassLevel" },
                    { new Guid("8ff12163-8fdc-4657-80d0-c510a27b54df"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Cameroun", false, null, null, "CM", "Country" },
                    { new Guid("9d682bb1-dcb5-4ac6-be8f-5403e3880971"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Form 5", false, null, null, "FORM_5", "SchoolClassLevel" },
                    { new Guid("ac2e4a38-4d9d-460d-ab37-f4b4ea14df5e"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Licence 2", false, null, null, "L2", "SchoolClassLevel" },
                    { new Guid("ac3fdc3d-beb7-4806-9413-384a32c21e1a"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Seconde", false, null, null, "SECONDE", "SchoolClassLevel" },
                    { new Guid("b77ca2cc-fb1f-4795-a722-c2fb9ccef8aa"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Lower Sixth", false, null, null, "LOWER_SIXTH", "SchoolClassLevel" },
                    { new Guid("b8a19c5a-6a48-4143-b391-313fb95d89dd"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Licence 3", false, null, null, "L3", "SchoolClassLevel" },
                    { new Guid("c0a60a47-3d81-4a8a-8582-267410320fb7"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Terminale", false, null, null, "TERMINALE", "SchoolClassLevel" },
                    { new Guid("c2e86c42-1eb7-4cb3-9247-632ccc7960bb"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Licence 1", false, null, null, "L1", "SchoolClassLevel" },
                    { new Guid("c9f478d1-903a-4ee6-84ed-92608e293c47"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Sixième", false, null, null, "6E", "SchoolClassLevel" },
                    { new Guid("e9e7e694-63df-4e16-bb30-fc3f4437a30c"), null, null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Class 6", false, null, null, "CLASS_6", "SchoolClassLevel" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "AverageHourlyRate", "CreatedAt", "DeletedOn", "DisplayName", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), 2500m, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Anglais", false, "Anglais", null },
                    { new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), 2750m, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Physique", false, "Physique", null },
                    { new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), 2500m, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Français", false, "Francais", null },
                    { new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"), 2750m, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Chimie", false, "Chimie", null },
                    { new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), 3000m, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Informatique", false, "Informatique", null },
                    { new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), 2800m, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Mathématiques", false, "Mathematiques", null },
                    { new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), 2700m, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Physique, Chimie et Technologie", false, "PCT", null },
                    { new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"), 2600m, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "SCIENCE DE LA VIE ET DE LA TERRE", false, "SVT", null }
                });

            migrationBuilder.InsertData(
                table: "DirectoryItems",
                columns: new[] { "Id", "CityId", "CountryId", "CreatedAt", "DeletedOn", "DisplayName", "IsDeleted", "Symbol", "UpdatedAt", "Value", "Kind" },
                values: new object[,]
                {
                    { new Guid("004a71f4-0612-4926-b36c-1f845d387e61"), null, new Guid("8ff12163-8fdc-4657-80d0-c510a27b54df"), new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Garoua", false, null, null, "GAROUA", "City" },
                    { new Guid("753e4bf2-f965-4f7c-b2ff-64b34cbe7fbb"), null, new Guid("8ff12163-8fdc-4657-80d0-c510a27b54df"), new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Yaoundé", false, null, null, "YAOUNDE", "City" },
                    { new Guid("ca10411d-8f52-4ad8-aeba-1e1bd634fa61"), null, new Guid("8ff12163-8fdc-4657-80d0-c510a27b54df"), new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Bafoussam", false, null, null, "BAFOUSSAM", "City" },
                    { new Guid("d3873ec8-cb6b-482e-9ba3-90facc2b3fb1"), null, new Guid("8ff12163-8fdc-4657-80d0-c510a27b54df"), new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Douala", false, null, null, "DOUALA", "City" },
                    { new Guid("f5b9bf9f-c280-4301-99b7-4ac73cc9b167"), null, new Guid("8ff12163-8fdc-4657-80d0-c510a27b54df"), new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Bamenda", false, null, null, "BAMENDA", "City" },
                    { new Guid("15470d97-c076-4ab3-82ae-c4a6d06c2188"), new Guid("004a71f4-0612-4926-b36c-1f845d387e61"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Padama", false, null, null, "PADAMA", "Neighborhood" },
                    { new Guid("4364d167-79f2-4a03-89d2-c09ea5c8ffbe"), new Guid("f5b9bf9f-c280-4301-99b7-4ac73cc9b167"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Mankon", false, null, null, "MANKON", "Neighborhood" },
                    { new Guid("595f9ff8-953b-420f-b51c-efc964ed4843"), new Guid("ca10411d-8f52-4ad8-aeba-1e1bd634fa61"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Banengo", false, null, null, "BANENGO", "Neighborhood" },
                    { new Guid("5ae2b031-492d-4363-b10d-aa50acafaa52"), new Guid("d3873ec8-cb6b-482e-9ba3-90facc2b3fb1"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Bonabéri", false, null, null, "BONABERI", "Neighborhood" },
                    { new Guid("73ce5015-cba6-4ac1-b592-ee6cf853f2ea"), new Guid("753e4bf2-f965-4f7c-b2ff-64b34cbe7fbb"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Nkolbisson", false, null, null, "NKOLOBISSON", "Neighborhood" },
                    { new Guid("75564c79-4adf-4c72-a09e-670d4ce331fd"), new Guid("753e4bf2-f965-4f7c-b2ff-64b34cbe7fbb"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Mokolo", false, null, null, "MOKOLO", "Neighborhood" },
                    { new Guid("89574e90-4a05-45f9-9a40-dd7b201c35f4"), new Guid("d3873ec8-cb6b-482e-9ba3-90facc2b3fb1"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Bonapriso", false, null, null, "BONAPRISO", "Neighborhood" },
                    { new Guid("8f62af8c-74c2-417c-bd73-17ead0a34c44"), new Guid("f5b9bf9f-c280-4301-99b7-4ac73cc9b167"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Nkwen", false, null, null, "NKWEN", "Neighborhood" },
                    { new Guid("92585578-3805-49c7-9263-3bbd5d8a606b"), new Guid("ca10411d-8f52-4ad8-aeba-1e1bd634fa61"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Djeleng", false, null, null, "DJELENG", "Neighborhood" },
                    { new Guid("96caf3d2-bfc6-4b96-a76f-83dfb1bca49f"), new Guid("d3873ec8-cb6b-482e-9ba3-90facc2b3fb1"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Akwa", false, null, null, "AKWA", "Neighborhood" },
                    { new Guid("a8ac01dd-40ea-4b8a-b6a0-bb66f4c88275"), new Guid("753e4bf2-f965-4f7c-b2ff-64b34cbe7fbb"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Bastos", false, null, null, "BASTOS", "Neighborhood" },
                    { new Guid("b1ae7aa2-c80c-4aee-ba64-434c2d1932a9"), new Guid("004a71f4-0612-4926-b36c-1f845d387e61"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Bénoué", false, null, null, "BENUE", "Neighborhood" },
                    { new Guid("ca21bd6d-3506-4951-9c5d-192aec6356f9"), new Guid("753e4bf2-f965-4f7c-b2ff-64b34cbe7fbb"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "Biyem-Assi", false, null, null, "BIYEM_ASSI", "Neighborhood" },
                    { new Guid("d624e25c-40cf-408a-9f2c-7125a1d01079"), new Guid("d3873ec8-cb6b-482e-9ba3-90facc2b3fb1"), null, new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "New Bell", false, null, null, "NEW_BELL", "Neighborhood" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CreatedAt", "DeletedOn", "Email", "EmailAddress", "EmailVerifiedOn", "FirstName", "IsDeleted", "IsEmailVerified", "LastName", "ParentSubjectId", "ParentSubjectType", "Password", "PhoneNumber", "Role", "Sexe", "UpdatedAt" },
                values: new object[] { new Guid("c211feb2-e860-473e-8165-8bc7994a5b3c"), new Guid("d3873ec8-cb6b-482e-9ba3-90facc2b3fb1"), new DateTime(2025, 1, 16, 23, 0, 0, 0, DateTimeKind.Utc), null, "nganjienzatsi@gmail.com", null, null, "NGANJIE NZATSI", false, false, "THEDE REINEL", new Guid("00000000-0000-0000-0000-000000000000"), "None", "$2a$11$PjHAS.XYkQP7ZhwAdtVQPOzwO6e03J8Jk9z3opS7.KjUuF/fyMMKi", "679015958", "SuperAdmin", "Male", null });

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryItems_CityId",
                table: "DirectoryItems",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryItems_CountryId",
                table: "DirectoryItems",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentCertifications_VerificationCertificationId",
                table: "DocumentCertifications",
                column: "VerificationCertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Encadreurs_UserId",
                table: "Encadreurs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSubjectEncadreurs_SchoolLevelId",
                table: "LevelSubjectEncadreurs",
                column: "SchoolLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageRequestCourses_MessagePayloadId",
                table: "MessageRequestCourses",
                column: "MessagePayloadId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageRequestCourses_ReceiverId",
                table: "MessageRequestCourses",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageRequestCourses_RequestCourseId",
                table: "MessageRequestCourses",
                column: "RequestCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageRequestCourses_SenderId",
                table: "MessageRequestCourses",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSessions_MessagePayloadId",
                table: "MessageSessions",
                column: "MessagePayloadId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSessions_ReceiverId",
                table: "MessageSessions",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSessions_SenderId",
                table: "MessageSessions",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSessions_SessionRepetitionId",
                table: "MessageSessions",
                column: "SessionRepetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_UserId",
                table: "Parents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Repetitions_EncadreurId",
                table: "Repetitions",
                column: "EncadreurId");

            migrationBuilder.CreateIndex(
                name: "IX_Repetitions_RequestCourseId",
                table: "Repetitions",
                column: "RequestCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Repetitions_StudentId",
                table: "Repetitions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionRepetitions_RepetitionId",
                table: "SessionRepetitions",
                column: "RepetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionRepetitions_SubjectRepetitionId",
                table: "SessionRepetitions",
                column: "SubjectRepetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CityId",
                table: "Students",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolLevelId",
                table: "Students",
                column: "SchoolLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEncadreurs_EncadreurId",
                table: "SubjectEncadreurs",
                column: "EncadreurId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEncadreurs_SubjectId",
                table: "SubjectEncadreurs",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRepetitions_RepetitionId",
                table: "SubjectRepetitions",
                column: "RepetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRepetitions_SubjectId",
                table: "SubjectRepetitions",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentCertifications");

            migrationBuilder.DropTable(
                name: "LevelSubjectEncadreurs");

            migrationBuilder.DropTable(
                name: "MessageRequestCourses");

            migrationBuilder.DropTable(
                name: "MessageSessions");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "SubjectEncadreurs");

            migrationBuilder.DropTable(
                name: "VerificationCertifications");

            migrationBuilder.DropTable(
                name: "MessagePayloads");

            migrationBuilder.DropTable(
                name: "SessionRepetitions");

            migrationBuilder.DropTable(
                name: "SubjectRepetitions");

            migrationBuilder.DropTable(
                name: "Repetitions");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Encadreurs");

            migrationBuilder.DropTable(
                name: "RequestCourses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DirectoryItems");
        }
    }
}
