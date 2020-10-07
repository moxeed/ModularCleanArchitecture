using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Infrastructure.Persistence.Migrations
{
    public partial class DatabaseRelationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    TypeEnName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    TypeEnName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Philanthropists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<bool>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    StudyField = table.Column<string>(nullable: true),
                    StudyUniversity = table.Column<string>(nullable: true),
                    StudyGrade = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    OccupationAddress = table.Column<string>(nullable: true),
                    FavoriteField = table.Column<string>(nullable: true),
                    CharityActivitiesHistory = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Philanthropists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Philanthropists_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Fund = table.Column<long>(nullable: false),
                    SurfaceArea = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(nullable: false),
                    ActualEndDate = table.Column<DateTime>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    PhilanthropistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Philanthropists_PhilanthropistId",
                        column: x => x.PhilanthropistId,
                        principalTable: "Philanthropists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDynamicDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDynamicDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDynamicDatas_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadedFiles_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadedFiles_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadedFiles_FileTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "FileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] { "Id", "TypeEnName", "TypeName" },
                values: new object[] { 1, "Image", "عکس" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "Deleted", "DeletedBy", "LastModified", "LastModifiedBy", "Summary", "Title" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Risus ultricies tristique nulla aliquet enim tortor. Vel risus commodo viverra maecenas accumsan lacus. Duis ultricies lacus sed turpis tincidunt id aliquet. Felis donec et odio pellentesque diam volutpat commodo sed egestas. Sem integer vitae justo eget magna fermentum iaculis eu. Eget arcu dictum varius duis. Arcu dui vivamus arcu felis bibendum. Placerat duis ultricies lacus sed turpis tincidunt id. Elit sed vulputate mi sit amet mauris commodo quis imperdiet. Non blandit massa enim nec dui nunc mattis. Nibh cras pulvinar mattis nunc sed blandit libero volutpat sed. Turpis cursus in hac habitasse platea dictumst.", new DateTime(2020, 10, 6, 11, 46, 52, 333, DateTimeKind.Local).AddTicks(8275), null, null, null, null, null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut", "PostTitle" });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "Id", "TypeEnName", "TypeName" },
                values: new object[,]
                {
                    { 1, "School", "مدرسه" },
                    { 2, "Library", "کتابخانه" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "تهران" },
                    { 2, "تبریز" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 1, "تهران", 1 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 2, "تبریز", 2 });

            migrationBuilder.InsertData(
                table: "UploadedFiles",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "FileName", "FilePath", "LastModified", "LastModifiedBy", "PostId", "ProjectId", "TypeId" },
                values: new object[] { 1, new DateTime(2020, 10, 6, 11, 46, 52, 330, DateTimeKind.Local).AddTicks(8605), null, null, null, "defaultProgImg.png", "Images/default.png", null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Philanthropists",
                columns: new[] { "Id", "CharityActivitiesHistory", "CityId", "Created", "CreatedBy", "Deleted", "DeletedBy", "Email", "FavoriteField", "FirstName", "ImageId", "LastModified", "LastModifiedBy", "LastName", "NationalCode", "Occupation", "OccupationAddress", "PhoneNumber", "Sex", "StudyField", "StudyGrade", "StudyUniversity", "Tel" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Risus ultricies tristique nulla aliquet enim tortor. Vel risus commodo viverra maecenas accumsan lacus. Duis ultricies lacus sed turpis tincidunt id aliquet. Felis donec et odio pellentesque diam volutpat commodo sed egestas. Sem integer vitae justo eget magna fermentum iaculis eu. Eget arcu dictum varius duis. Arcu dui vivamus arcu felis bibendum. Placerat duis ultricies lacus sed turpis tincidunt id. Elit sed vulputate mi sit amet mauris commodo quis imperdiet. Non blandit massa enim nec dui nunc mattis. Nibh cras pulvinar mattis nunc sed blandit libero volutpat sed. Turpis cursus in hac habitasse platea dictumst.", 1, new DateTime(2020, 10, 6, 11, 46, 52, 334, DateTimeKind.Local).AddTicks(4590), null, null, null, "p1@gmail.com", "School", "john", 1, null, null, "due", "0021122334", "Teacher", "Street St.", "093728371", true, "Computer", "advance", "UT", "829327832" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ActualEndDate", "CityId", "Created", "CreatedBy", "Deleted", "DeletedBy", "Description", "EstimatedEndDate", "Fund", "LastModified", "LastModifiedBy", "PhilanthropistId", "StartDate", "SurfaceArea", "Title", "TypeId" },
                values: new object[] { 1, new DateTime(2020, 10, 6, 11, 46, 52, 334, DateTimeKind.Local).AddTicks(8852), 2, new DateTime(2020, 10, 6, 11, 46, 52, 335, DateTimeKind.Local).AddTicks(195), null, null, null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Risus ultricies tristique nulla aliquet enim tortor.Vel risus commodo viverra maecenas accumsan lacus.Duis ultricies lacus sed turpis tincidunt id aliquet. Felis donec et odio pellentesque diam volutpat commodo sed egestas. Sem integer vitae justo eget magna fermentum iaculis eu.Eget arcu dictum varius duis.Arcu dui vivamus arcu felis bibendum. Placerat duis ultricies lacus sed turpis tincidunt id. Elit sed vulputate mi sit amet mauris commodo quis imperdiet. Non blandit massa enim nec dui nunc mattis. Nibh cras pulvinar mattis nunc sed blandit libero volutpat sed. Turpis cursus in hac habitasse platea dictumst.", new DateTime(2020, 9, 6, 11, 46, 52, 334, DateTimeKind.Local).AddTicks(8419), 1939828738L, null, null, 1, new DateTime(2019, 10, 6, 11, 46, 52, 334, DateTimeKind.Local).AddTicks(7936), 2000000, "Project Title", 1 });

            migrationBuilder.InsertData(
                table: "ProjectDynamicDatas",
                columns: new[] { "Id", "Name", "ProjectId", "Value" },
                values: new object[] { 1, "school", 1, "4" });

            migrationBuilder.InsertData(
                table: "UploadedFiles",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "FileName", "FilePath", "LastModified", "LastModifiedBy", "PostId", "ProjectId", "TypeId" },
                values: new object[] { 2, new DateTime(2020, 10, 6, 11, 46, 52, 333, DateTimeKind.Local).AddTicks(5675), null, null, null, "defaultProgImg.png", "Images/kanoonlogo.png", null, null, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "UploadedFiles",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "FileName", "FilePath", "LastModified", "LastModifiedBy", "PostId", "ProjectId", "TypeId" },
                values: new object[] { 3, new DateTime(2020, 10, 6, 11, 46, 52, 333, DateTimeKind.Local).AddTicks(6596), null, null, null, "defaultProgImg.png", "Images/kanoonlogo.png", null, null, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Philanthropists_CityId",
                table: "Philanthropists",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDynamicDatas_ProjectId",
                table: "ProjectDynamicDatas",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CityId",
                table: "Projects",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PhilanthropistId",
                table: "Projects",
                column: "PhilanthropistId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TypeId",
                table: "Projects",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_PostId",
                table: "UploadedFiles",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_ProjectId",
                table: "UploadedFiles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_TypeId",
                table: "UploadedFiles",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDynamicDatas");

            migrationBuilder.DropTable(
                name: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropTable(
                name: "Philanthropists");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
