using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APPLICATION_INFOS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATION_INFOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WORK_TYPES",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORK_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QUESTIONS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WORK_TYPE_ID = table.Column<short>(type: "smallint", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QUESTIONS_WORK_TYPES_WORK_TYPE_ID",
                        column: x => x.WORK_TYPE_ID,
                        principalTable: "WORK_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VACANCIES",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QUESTION_COUNT = table.Column<byte>(type: "tinyint", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    WORK_TYPE_ID = table.Column<short>(type: "smallint", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VACANCIES_WORK_TYPES_WORK_TYPE_ID",
                        column: x => x.WORK_TYPE_ID,
                        principalTable: "WORK_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ANSWERS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QUESTION_ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IS_CORRECT = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANSWERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ANSWERS_QUESTIONS_QUESTION_ID",
                        column: x => x.QUESTION_ID,
                        principalTable: "QUESTIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QUESTION_BANKS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTION_BANKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QUESTION_BANKS_VACANCIES_ID",
                        column: x => x.ID,
                        principalTable: "VACANCIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ACTIONS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    QUESTION_BANK_ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    POINT = table.Column<short>(type: "smallint", nullable: false),
                    PERCENT = table.Column<byte>(type: "tinyint", nullable: false),
                    CV_PATH = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACTIONS_APPLICATION_INFOS_ID",
                        column: x => x.ID,
                        principalTable: "APPLICATION_INFOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ACTIONS_QUESTION_BANKS_QUESTION_BANK_ID",
                        column: x => x.QUESTION_BANK_ID,
                        principalTable: "QUESTION_BANKS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QUESTION_BANK_QUESTIONS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    QUESTION_BANK_ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    QUESTION_ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTION_BANK_QUESTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QUESTION_BANK_QUESTIONS_QUESTIONS_QUESTION_ID",
                        column: x => x.QUESTION_ID,
                        principalTable: "QUESTIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QUESTION_BANK_QUESTIONS_QUESTION_BANKS_QUESTION_BANK_ID",
                        column: x => x.QUESTION_BANK_ID,
                        principalTable: "QUESTION_BANKS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ACTION_ANSWERS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ACTION_ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    QUESTION_ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ANSWER_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTION_ANSWERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACTION_ANSWERS_ACTIONS_ACTION_ID",
                        column: x => x.ACTION_ID,
                        principalTable: "ACTIONS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACTION_ANSWERS_ANSWERS_ANSWER_ID",
                        column: x => x.ANSWER_ID,
                        principalTable: "ANSWERS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACTION_ANSWERS_QUESTIONS_QUESTION_ID",
                        column: x => x.QUESTION_ID,
                        principalTable: "QUESTIONS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_ANSWERS_ACTION_ID",
                table: "ACTION_ANSWERS",
                column: "ACTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_ANSWERS_ANSWER_ID",
                table: "ACTION_ANSWERS",
                column: "ANSWER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_ANSWERS_QUESTION_ID",
                table: "ACTION_ANSWERS",
                column: "QUESTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIONS_QUESTION_BANK_ID",
                table: "ACTIONS",
                column: "QUESTION_BANK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ANSWERS_QUESTION_ID",
                table: "ANSWERS",
                column: "QUESTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTION_BANK_QUESTIONS_QUESTION_BANK_ID",
                table: "QUESTION_BANK_QUESTIONS",
                column: "QUESTION_BANK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTION_BANK_QUESTIONS_QUESTION_ID",
                table: "QUESTION_BANK_QUESTIONS",
                column: "QUESTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTIONS_WORK_TYPE_ID",
                table: "QUESTIONS",
                column: "WORK_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_WORK_TYPE_ID",
                table: "VACANCIES",
                column: "WORK_TYPE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTION_ANSWERS");

            migrationBuilder.DropTable(
                name: "QUESTION_BANK_QUESTIONS");

            migrationBuilder.DropTable(
                name: "ACTIONS");

            migrationBuilder.DropTable(
                name: "ANSWERS");

            migrationBuilder.DropTable(
                name: "APPLICATION_INFOS");

            migrationBuilder.DropTable(
                name: "QUESTION_BANKS");

            migrationBuilder.DropTable(
                name: "QUESTIONS");

            migrationBuilder.DropTable(
                name: "VACANCIES");

            migrationBuilder.DropTable(
                name: "WORK_TYPES");
        }
    }
}
