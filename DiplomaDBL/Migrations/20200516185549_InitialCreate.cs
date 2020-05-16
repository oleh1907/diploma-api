using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomaDBL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualitys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualitys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialName = table.Column<string>(nullable: true),
                    NameToDisplay = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    QualityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodInfos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodInfos_Qualitys_QualityId",
                        column: x => x.QualityId,
                        principalTable: "Qualitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(nullable: true),
                    WhenOccured = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    FoodInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_FoodInfos_FoodInfoId",
                        column: x => x.FoodInfoId,
                        principalTable: "FoodInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Гриби" });

            migrationBuilder.InsertData(
                table: "Qualitys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Можна споживати" },
                    { 2, "Можна споживати за умови правильної обробки" },
                    { 3, "Не можна споживати" }
                });

            migrationBuilder.InsertData(
                table: "FoodInfos",
                columns: new[] { "Id", "CategoryId", "Description", "NameToDisplay", "OfficialName", "QualityId" },
                values: new object[,]
                {
                    { 1, 1, "Характерною ознакою роду печериць від інших печерицевих є колір пластинок: від рожевуватих у молодих плодових тіл, до темно-коричневих у зрілих грибів, темно-коричневим, бурувато-чорним споровим порошком та прирослим до ніжки кільцем. Шапинка куляста, конусовидна або дзвониковидна, м'ясиста, щільна, поврехня гладка, луската, білувата, рідше коричнювата. Пластинки вільні, тонкі, вузькі, при дозріванні розпливаються. Ніжка зазвичай центральна, рівна, щільна.", "Печериця", "Agarius", 1 },
                    { 3, 1, "Плодове тіло цих грибів велике, м'ясисте. Ніжка товста, особливо у молодих грибів, з характерним рельєфним малюнком, рідше ворсиста або гладка.", "Білий гриб", "Boletus", 1 },
                    { 7, 1, "Шапка 3-10(12) см у діаметрі, м'ясиста, увігнута, іноді майже лійкоподібна, сірувато-оранжево-руда, з темнішими, більш або менш виразними концентричними смугами, гола, клейкувата. Пластинки оранжево-жовті або вохряні, від дотику зеленіють. Спори 7-9 Х 6-7 мкм, бородавчасті. Ніжка кольору шапки або світліша, 3-7 Х 1-2,5 см, щільна, згодом з порожниною. М'якуш у шапці жовтий, у ніжці білий (всередині), у периферичній частині шапки та особливо ніжки оранжево-червоний, при розрізуванні на повітрі поволі зеленіє. Молочний сік оранжево-червоний, з приємним (гоструватим) смаком і запахом, на повітрі не змінюється (лише через кілька годин стає сіро-зеленим).", "Рижик", "Lactarius", 1 },
                    { 8, 1, "Шапинка їх опукло-плеската або ввігнуто-розпроста, яскраво забарвлена, м'якуш крихкий, солодкий або пекучоїдкий. В Україні — бл. 50 видів, їстівні.Ростуть у мішаних, рідше в шпилькових(хвойних) лісах.Найпоширеніші: Сироїжка біла(R.delica Fr.) і Сироїжка їстівна(R.vesca L.).Сироїжки становлять не менш однієї третини врожаю всіх їстівних грибів.", "Сироїжка", "Russula", 1 },
                    { 9, 1, "Шапка 3-8 (10-12) см у діаметрі, брудно-рожевуватокоричнювата, червонувато- або жовтувата-коричнювата, здебільшого нерівно забарвлена, до краю світліша, гола, клейкувата, при підсиханні блискуча. Шкірка знімається. Пори великі, кутасті, з нерівними краями, сірувато.-жовті, згодом зеленуватожовті, пізніше оливкувато-коричневі. Спори жовтуваті, 6-10 Х 3-4 мкм. Ніжка 4-8 Х 1-2 см, часто зігнута, щільна, кольору шапки або світліша, донизу здебільшого червонувато. М'якуш щільний, жовтувата-червонувато-коричнюватий, при розрізуванні на повітрі не змінюється, без особливого запаху.", "Маслюк", "Suillus", 1 },
                    { 2, 1, "Шапка 5-12(20) см у діаметрі, напівсферична, згодом опукло-тугого плоска, з тонким рубчастим краєм, цегляно-червона різних відтінків, жовто-червона, червоно-помаранчева, з численними білими пластівцями, які іноді зникають після дощу . Пластинки густі, тонкі, білі. Спорова маса біла. Спори 9-11 Х 6-8 мкм, широкоовальні. Ніжка 5-13 × 1-3 см, циліндрична, з великою бульбою, щільна, пізніше з порожниною, гола з широким білим (по краю жовтим) кільцем, з прирослою у вигляді концентричних, бородавчастолускатих смуг піхвою. М'якуш білий, у периферичному шарі тканини шапки жовтуватий без особливого запаху. Отруйний гриб.", "Мухомор", "Amanita", 3 },
                    { 4, 1, "Шапка 3-8 см у діаметрі, тупоконусоподібна, з жовтою кортиною, згодом опуклорозпростерта, з тупим горбом у центрі, з опущеним, тріщинуватим краєм, руда, оранжево-руда, цегляно-коричнювата, у центрі темніша, тонкоповстиста, темноволокнисто-луската. Пластинки рідкі, широкі, оранжуваті, потім червонувато-руді. Спорова маса іржаво-коричнева. Спори 8,5-11 Х 5,5-7,7 мкм, еліпсоподібні, дрібнобородавчасті. Ніжка 3-9 Х 0,4-1,5 см, часто До основи трохи звужується і переходить у коренеподібний виріст, щільна, золотисто-жовта (або вохряна), внизу руда-коричнева, гола. М'якуш у шапці червонувато-коричнюватий, у ніжці жовтий, трохи пахне редькою. Розчин соди забарвлює шкірку шапки та ніжки у чорний колір. В Україні поширений у західному Поліссі.Росте у листяних та хвойних лісах у вересні — жовтні. Дуже небезпечний отруйний гриб.Містить токсин ореланін.Спричиняє тяжке, іноді смертельне отруєння.", "Павутинник", "Cortinarius", 3 },
                    { 5, 1, "Шапка 4—10(11) см у діаметрі, опукло-, плоско- або увігнуторозпростерта, часом з горбом, сріблясто-сіра, оливкувато- або іноді жовтувато-сіра, при зволоженні темніє, при підсиханні світлішає, гола, блискуча. Пластинки прирослі, іноді злегка переходять на ніжку, білі, рожеві. Спори 8—10,5 X 7—8 мкм, кутасто-кулясті або кутасто-широкоовальні. Ніжка 5—11 X 0,5—1,5 см, щільна, з віком порожня, біла, згодом сірувата, гола. М'якуш щільний, білий, спочатку пахне борошном, при підсиханні з неприємним запахом. В Україні поширений у Прикарпатті, на Поліссі та в Лісостепу.Росте у листяних(дубових, букових) лісах; часто; у серпні — вересні. Отруйний гриб.", "Ентолома", "Entoloma", 3 },
                    { 6, 1, "Капелюшок ∅ 0,5-12 см, конічна, колокольчатая або полушаровидная, потім розпростерта, іноді з горбком або вдавлені в центрі, гладка або луската, волокниста, суха, волога або слизова, зазвичай яскраво забарвлені, червона, оранжево-жовта, іноді темніють або чорніючий з віком. Платівки приросли або низхідні, товсті, рідкісні, від білих до яркоокрашенних - червоні, рожеві, жовті.Ніжка циліндрична, часто звужена до основи, суха або клейка, гладка або волокниста, часто перекручена, одноколірна з капелюшком, порожниста. Споровий порошок білого кольору.", "Вологоголовка", "Hygrocybe", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodInfos_CategoryId",
                table: "FoodInfos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInfos_QualityId",
                table: "FoodInfos",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FoodInfoId",
                table: "Requests",
                column: "FoodInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "FoodInfos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Qualitys");
        }
    }
}
