using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace englishtrainerdal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_infos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    displayname = table.Column<string>(name: "display_name", type: "text", nullable: false),
                    languagecode = table.Column<string>(name: "language_code", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_infos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    languageid = table.Column<string>(name: "language_id", type: "character varying(3)", maxLength: 3, nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.languageid);
                });

            migrationBuilder.CreateTable(
                name: "medias",
                columns: table => new
                {
                    mediaid = table.Column<int>(name: "media_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    videocode = table.Column<string>(name: "video_code", type: "text", nullable: false),
                    filepath = table.Column<string>(name: "file_path", type: "text", nullable: false),
                    subtitless = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medias", x => x.mediaid);
                });

            migrationBuilder.CreateTable(
                name: "part_of_speeches",
                columns: table => new
                {
                    partofspeechid = table.Column<int>(name: "part_of_speech_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    info = table.Column<string>(type: "text", nullable: false),
                    languageid = table.Column<string>(name: "language_id", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_part_of_speeches", x => x.partofspeechid);
                });

            migrationBuilder.CreateTable(
                name: "translations",
                columns: table => new
                {
                    translationid = table.Column<int>(name: "translation_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    translationcode = table.Column<string>(name: "translation_code", type: "text", nullable: false),
                    translation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_translations", x => x.translationid);
                });

            migrationBuilder.CreateTable(
                name: "words",
                columns: table => new
                {
                    wordid = table.Column<int>(name: "word_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    word = table.Column<string>(type: "text", nullable: false),
                    transcription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_words", x => x.wordid);
                });

            migrationBuilder.CreateTable(
                name: "account_info_media",
                columns: table => new
                {
                    accountinfosid = table.Column<int>(name: "account_infos_id", type: "integer", nullable: false),
                    mediasid = table.Column<int>(name: "medias_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_info_media", x => new { x.accountinfosid, x.mediasid });
                    table.ForeignKey(
                        name: "fk_account_info_media_account_infos_account_infos_id",
                        column: x => x.accountinfosid,
                        principalTable: "account_infos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_info_media_medias_medias_id",
                        column: x => x.mediasid,
                        principalTable: "medias",
                        principalColumn: "media_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "languages_part_of_speech",
                columns: table => new
                {
                    languageslanguageid = table.Column<string>(name: "languages_language_id", type: "character varying(3)", nullable: false),
                    partofspeechesid = table.Column<int>(name: "part_of_speeches_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages_part_of_speech", x => new { x.languageslanguageid, x.partofspeechesid });
                    table.ForeignKey(
                        name: "fk_languages_part_of_speech_languages_languages_language_id",
                        column: x => x.languageslanguageid,
                        principalTable: "languages",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_languages_part_of_speech_part_of_speeches_part_of_speeches_",
                        column: x => x.partofspeechesid,
                        principalTable: "part_of_speeches",
                        principalColumn: "part_of_speech_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_info_translations",
                columns: table => new
                {
                    accountinfosid = table.Column<int>(name: "account_infos_id", type: "integer", nullable: false),
                    translationsid = table.Column<int>(name: "translations_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_info_translations", x => new { x.accountinfosid, x.translationsid });
                    table.ForeignKey(
                        name: "fk_account_info_translations_account_infos_account_infos_id",
                        column: x => x.accountinfosid,
                        principalTable: "account_infos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_info_translations_translations_translations_id",
                        column: x => x.translationsid,
                        principalTable: "translations",
                        principalColumn: "translation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part_of_speech_words",
                columns: table => new
                {
                    partofspeechesid = table.Column<int>(name: "part_of_speeches_id", type: "integer", nullable: false),
                    wordslistid = table.Column<int>(name: "words_list_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_part_of_speech_words", x => new { x.partofspeechesid, x.wordslistid });
                    table.ForeignKey(
                        name: "fk_part_of_speech_words_part_of_speeches_part_of_speeches_id",
                        column: x => x.partofspeechesid,
                        principalTable: "part_of_speeches",
                        principalColumn: "part_of_speech_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_part_of_speech_words_words_words_list_id",
                        column: x => x.wordslistid,
                        principalTable: "words",
                        principalColumn: "word_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "translations_words",
                columns: table => new
                {
                    translationslistid = table.Column<int>(name: "translations_list_id", type: "integer", nullable: false),
                    wordslistid = table.Column<int>(name: "words_list_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_translations_words", x => new { x.translationslistid, x.wordslistid });
                    table.ForeignKey(
                        name: "fk_translations_words_translations_translations_list_id",
                        column: x => x.translationslistid,
                        principalTable: "translations",
                        principalColumn: "translation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_translations_words_words_words_list_id",
                        column: x => x.wordslistid,
                        principalTable: "words",
                        principalColumn: "word_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_info_media_medias_id",
                table: "account_info_media",
                column: "medias_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_info_translations_translations_id",
                table: "account_info_translations",
                column: "translations_id");

            migrationBuilder.CreateIndex(
                name: "ix_languages_part_of_speech_part_of_speeches_id",
                table: "languages_part_of_speech",
                column: "part_of_speeches_id");

            migrationBuilder.CreateIndex(
                name: "ix_part_of_speech_words_words_list_id",
                table: "part_of_speech_words",
                column: "words_list_id");

            migrationBuilder.CreateIndex(
                name: "ix_translations_words_words_list_id",
                table: "translations_words",
                column: "words_list_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_info_media");

            migrationBuilder.DropTable(
                name: "account_info_translations");

            migrationBuilder.DropTable(
                name: "languages_part_of_speech");

            migrationBuilder.DropTable(
                name: "part_of_speech_words");

            migrationBuilder.DropTable(
                name: "translations_words");

            migrationBuilder.DropTable(
                name: "medias");

            migrationBuilder.DropTable(
                name: "account_infos");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "part_of_speeches");

            migrationBuilder.DropTable(
                name: "translations");

            migrationBuilder.DropTable(
                name: "words");
        }
    }
}
