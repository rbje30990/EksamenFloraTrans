using Microsoft.EntityFrameworkCore.Migrations;

namespace FloraTransAPI.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    KID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    navn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobtitel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVRNR = table.Column<int>(type: "int", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.KID);
                });

            migrationBuilder.CreateTable(
                name: "Lager",
                columns: table => new
                {
                    LID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lejeDato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udløbsDato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brugsretten = table.Column<float>(type: "real", nullable: false),
                    ledighed = table.Column<bool>(type: "bit", nullable: false),
                    bundramme = table.Column<int>(type: "int", nullable: false),
                    antalhylder = table.Column<int>(type: "int", nullable: false),
                    antalsøjlerør = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lager", x => x.LID);
                });

            migrationBuilder.CreateTable(
                name: "Bevægelser",
                columns: table => new
                {
                    BID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sendtBundramme = table.Column<int>(type: "int", nullable: false),
                    sendtAntalHylder = table.Column<int>(type: "int", nullable: false),
                    sendtAntalSøjlerør = table.Column<int>(type: "int", nullable: false),
                    afleveretDato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tilbagemodtagetDato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KundeID = table.Column<int>(type: "int", nullable: false),
                    LagerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bevægelser", x => x.BID);
                    table.ForeignKey(
                        name: "FK_Bevægelser_Kunder_KundeID",
                        column: x => x.KundeID,
                        principalTable: "Kunder",
                        principalColumn: "KID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bevægelser_Lager_LagerID",
                        column: x => x.LagerID,
                        principalTable: "Lager",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fejlmeldinger",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeltTabt = table.Column<bool>(type: "bit", nullable: false),
                    manglerBundramme = table.Column<int>(type: "int", nullable: false),
                    manglerAntalHylder = table.Column<int>(type: "int", nullable: false),
                    manglerAntalSøjlerør = table.Column<int>(type: "int", nullable: false),
                    BevægelserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fejlmeldinger", x => x.FID);
                    table.ForeignKey(
                        name: "FK_Fejlmeldinger_Bevægelser_BevægelserID",
                        column: x => x.BevægelserID,
                        principalTable: "Bevægelser",
                        principalColumn: "BID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kunder",
                columns: new[] { "KID", "CVRNR", "adresse", "email", "jobtitel", "navn", "telefon" },
                values: new object[,]
                {
                    { 1, 436734278, "Landmarksgade 43", "MarkMail@hotmail.com", "Landmand", "Mark", "45 63 27 18" },
                    { 2, 736734278, "Pcvejle 42", "JohnMail@hotmail.com", "Youtuber", "John", "Ukendt" },
                    { 3, 436734278, "Landmarksgade 43", "JulieMail@hotmail.com", "Forfatter", "Julie", "47 43 97 98" }
                });

            migrationBuilder.InsertData(
                table: "Lager",
                columns: new[] { "LID", "antalhylder", "antalsøjlerør", "brugsretten", "bundramme", "ledighed", "lejeDato", "udløbsDato" },
                values: new object[,]
                {
                    { 1, 5, 4, 1500.49f, 1, true, "16/08/2021", "16/08/2022" },
                    { 2, 5, 4, 1500.49f, 1, false, "15/03/2021", "15/03/2022" },
                    { 3, 5, 4, 1500.49f, 1, false, "03/01/2021", "03/01/2022" },
                    { 4, 2, 4, 1500.49f, 1, false, "01/01/2021", "01/01/2022" },
                    { 5, 0, 0, 1500.49f, 0, false, "01/01/2021", "01/01/2022" }
                });

            migrationBuilder.InsertData(
                table: "Bevægelser",
                columns: new[] { "BID", "KundeID", "LagerID", "afleveretDato", "sendtAntalHylder", "sendtAntalSøjlerør", "sendtBundramme", "tilbagemodtagetDato" },
                values: new object[,]
                {
                    { 2, 1, 2, "05/06/2021", 5, 4, 1, "05/07/2021" },
                    { 3, 2, 2, "18/08/2021", 3, 4, 1, "18/09/2021" },
                    { 5, 3, 3, "15/08/2021", 5, 4, 1, "15/09/2021" },
                    { 1, 1, 4, "24/04/2021", 5, 4, 1, "20/05/2021" },
                    { 4, 2, 5, "18/04/2021", 5, 4, 1, "18/05/2021" }
                });

            migrationBuilder.InsertData(
                table: "Fejlmeldinger",
                columns: new[] { "FID", "BevægelserID", "HeltTabt", "manglerAntalHylder", "manglerAntalSøjlerør", "manglerBundramme" },
                values: new object[] { 2, 1, false, 3, 0, 0 });

            migrationBuilder.InsertData(
                table: "Fejlmeldinger",
                columns: new[] { "FID", "BevægelserID", "HeltTabt", "manglerAntalHylder", "manglerAntalSøjlerør", "manglerBundramme" },
                values: new object[] { 3, 4, true, 5, 4, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Bevægelser_KundeID",
                table: "Bevægelser",
                column: "KundeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bevægelser_LagerID",
                table: "Bevægelser",
                column: "LagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Fejlmeldinger_BevægelserID",
                table: "Fejlmeldinger",
                column: "BevægelserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fejlmeldinger");

            migrationBuilder.DropTable(
                name: "Bevægelser");

            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropTable(
                name: "Lager");
        }
    }
}
