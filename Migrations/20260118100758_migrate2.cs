using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REPETITEURLINK.Migrations
{
    /// <inheritdoc />
    public partial class migrate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectRepetitions_Subject_SubjectId",
                table: "SubjectRepetitions");

            migrationBuilder.DropTable(
                name: "SubjectEncadreurs");

            migrationBuilder.DropColumn(
                name: "SubjectEncadreur",
                table: "LevelSubjectEncadreurs");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "SubjectRepetitions",
                newName: "LevelSubjectEncadreurId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectRepetitions_SubjectId",
                table: "SubjectRepetitions",
                newName: "IX_SubjectRepetitions_LevelSubjectEncadreurId");

            migrationBuilder.RenameColumn(
                name: "SubjectEncadreurId",
                table: "LevelSubjectEncadreurs",
                newName: "SubjectId");

            migrationBuilder.AddColumn<Guid>(
                name: "EncadreurId",
                table: "RequestCourses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "RequestCourses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EncadreurId",
                table: "LevelSubjectEncadreurs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "HourlyRate",
                table: "LevelSubjectEncadreurs",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "DirectoryItems",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsNative",
                table: "DirectoryItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("004a71f4-0612-4926-b36c-1f845d387e61"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("025e1c40-4593-47de-bc4e-b389c91c45fb"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("15470d97-c076-4ab3-82ae-c4a6d06c2188"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("18972a21-ee93-45fe-b337-8e1ec2a7657b"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("1d54025c-b1d8-4baf-8aac-0d37a14d4e52"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("22398de3-c316-41ff-a09d-41f15a856ba4"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("262aef51-3b3e-4f52-8bb2-f912b288b7c0"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("278b6e0a-f892-43e5-803e-5322c78620f3"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("28a67a7d-03ef-40df-b91b-3ce45a6bcfb1"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("2b4d8461-240b-4e1b-84f4-f7148b4da0d3"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("350641cf-22c4-45b6-a222-8ce2b93a1770"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("399f1a29-ab8f-409a-abd8-b936c3f66f29"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("4364d167-79f2-4a03-89d2-c09ea5c8ffbe"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("4ccc720d-cb3f-4915-a268-43e6e699d3b2"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("5330d345-8ecf-4a94-8de2-742d448c52fb"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("595f9ff8-953b-420f-b51c-efc964ed4843"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("5ae2b031-492d-4363-b10d-aa50acafaa52"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("64478a7c-f553-4409-9b20-aa5eda6010bd"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("6896174a-96f1-456e-83a5-de5861d9123b"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("6b4435c7-ba35-4ed4-9281-4e10092b3cfc"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("73ce5015-cba6-4ac1-b592-ee6cf853f2ea"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("753e4bf2-f965-4f7c-b2ff-64b34cbe7fbb"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("75564c79-4adf-4c72-a09e-670d4ce331fd"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("8092a7e1-6773-4ead-9204-15c653bbb55a"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("877636e7-73a4-498a-b12a-96d78424d123"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("89574e90-4a05-45f9-9a40-dd7b201c35f4"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("8f62af8c-74c2-417c-bd73-17ead0a34c44"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("8ff12163-8fdc-4657-80d0-c510a27b54df"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("92585578-3805-49c7-9263-3bbd5d8a606b"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("96caf3d2-bfc6-4b96-a76f-83dfb1bca49f"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("9d682bb1-dcb5-4ac6-be8f-5403e3880971"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("a8ac01dd-40ea-4b8a-b6a0-bb66f4c88275"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("ac2e4a38-4d9d-460d-ab37-f4b4ea14df5e"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("ac3fdc3d-beb7-4806-9413-384a32c21e1a"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("b1ae7aa2-c80c-4aee-ba64-434c2d1932a9"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("b77ca2cc-fb1f-4795-a722-c2fb9ccef8aa"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("b8a19c5a-6a48-4143-b391-313fb95d89dd"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("c0a60a47-3d81-4a8a-8582-267410320fb7"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("c2e86c42-1eb7-4cb3-9247-632ccc7960bb"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("c9f478d1-903a-4ee6-84ed-92608e293c47"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("ca10411d-8f52-4ad8-aeba-1e1bd634fa61"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("ca21bd6d-3506-4951-9c5d-192aec6356f9"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("d3873ec8-cb6b-482e-9ba3-90facc2b3fb1"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("d624e25c-40cf-408a-9f2c-7125a1d01079"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("e9e7e694-63df-4e16-bb30-fc3f4437a30c"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "DirectoryItems",
                keyColumn: "Id",
                keyValue: new Guid("f5b9bf9f-c280-4301-99b7-4ac73cc9b167"),
                column: "IsNative",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c211feb2-e860-473e-8165-8bc7994a5b3c"),
                column: "Password",
                value: "$2a$11$BIrjrQzPsdN05QtYBWOr..LNGCHtN8A5RQ7xiTAjN9ssC2Swde.ZC");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCourses_EncadreurId",
                table: "RequestCourses",
                column: "EncadreurId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCourses_UserId",
                table: "RequestCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSubjectEncadreurs_EncadreurId",
                table: "LevelSubjectEncadreurs",
                column: "EncadreurId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSubjectEncadreurs_SubjectId",
                table: "LevelSubjectEncadreurs",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubjectEncadreurs_Encadreurs_EncadreurId",
                table: "LevelSubjectEncadreurs",
                column: "EncadreurId",
                principalTable: "Encadreurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubjectEncadreurs_Subject_SubjectId",
                table: "LevelSubjectEncadreurs",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestCourses_Encadreurs_EncadreurId",
                table: "RequestCourses",
                column: "EncadreurId",
                principalTable: "Encadreurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestCourses_Users_UserId",
                table: "RequestCourses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectRepetitions_LevelSubjectEncadreurs_LevelSubjectEncad~",
                table: "SubjectRepetitions",
                column: "LevelSubjectEncadreurId",
                principalTable: "LevelSubjectEncadreurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubjectEncadreurs_Encadreurs_EncadreurId",
                table: "LevelSubjectEncadreurs");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubjectEncadreurs_Subject_SubjectId",
                table: "LevelSubjectEncadreurs");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestCourses_Encadreurs_EncadreurId",
                table: "RequestCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestCourses_Users_UserId",
                table: "RequestCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectRepetitions_LevelSubjectEncadreurs_LevelSubjectEncad~",
                table: "SubjectRepetitions");

            migrationBuilder.DropIndex(
                name: "IX_RequestCourses_EncadreurId",
                table: "RequestCourses");

            migrationBuilder.DropIndex(
                name: "IX_RequestCourses_UserId",
                table: "RequestCourses");

            migrationBuilder.DropIndex(
                name: "IX_LevelSubjectEncadreurs_EncadreurId",
                table: "LevelSubjectEncadreurs");

            migrationBuilder.DropIndex(
                name: "IX_LevelSubjectEncadreurs_SubjectId",
                table: "LevelSubjectEncadreurs");

            migrationBuilder.DropColumn(
                name: "EncadreurId",
                table: "RequestCourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RequestCourses");

            migrationBuilder.DropColumn(
                name: "EncadreurId",
                table: "LevelSubjectEncadreurs");

            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "LevelSubjectEncadreurs");

            migrationBuilder.DropColumn(
                name: "IsNative",
                table: "DirectoryItems");

            migrationBuilder.RenameColumn(
                name: "LevelSubjectEncadreurId",
                table: "SubjectRepetitions",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectRepetitions_LevelSubjectEncadreurId",
                table: "SubjectRepetitions",
                newName: "IX_SubjectRepetitions_SubjectId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "LevelSubjectEncadreurs",
                newName: "SubjectEncadreurId");

            migrationBuilder.AddColumn<string>(
                name: "SubjectEncadreur",
                table: "LevelSubjectEncadreurs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "DirectoryItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "SubjectEncadreurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    EncadreurId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HourlyRate = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c211feb2-e860-473e-8165-8bc7994a5b3c"),
                column: "Password",
                value: "$2a$11$PjHAS.XYkQP7ZhwAdtVQPOzwO6e03J8Jk9z3opS7.KjUuF/fyMMKi");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEncadreurs_EncadreurId",
                table: "SubjectEncadreurs",
                column: "EncadreurId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEncadreurs_SubjectId",
                table: "SubjectEncadreurs",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectRepetitions_Subject_SubjectId",
                table: "SubjectRepetitions",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
