using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HogeBlazor.Server.Db.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "ID")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "削除日時"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "作成日時"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "更新日時"),
                    MakerName = table.Column<string>(type: "text", nullable: false, comment: "メーカー名"),
                    ModelName = table.Column<string>(type: "text", nullable: false, comment: "モデル名"),
                    GradeName = table.Column<string>(type: "text", nullable: false, comment: "グレード"),
                    ModelCode = table.Column<string>(type: "text", nullable: false, comment: "型式"),
                    Price = table.Column<int>(type: "integer", nullable: true, comment: "小売価格(税込/円)"),
                    Url = table.Column<string>(type: "text", nullable: true, comment: "URL"),
                    ImageUrl = table.Column<string>(type: "text", nullable: true, comment: "イメージURL"),
                    ModelChangeFull = table.Column<string>(type: "text", nullable: true, comment: "フルモデルチェンジ時期(日本)[yyyy-mm-dd]"),
                    ModelChangeLast = table.Column<string>(type: "text", nullable: true, comment: "最終モデルチェンジ時期(日本)[yyyy-mm-dd]"),
                    Body_Type = table.Column<int>(type: "integer", nullable: true, comment: "ボディタイプ"),
                    Body_Length = table.Column<int>(type: "integer", nullable: true, comment: "全長(mm)"),
                    Body_Width = table.Column<int>(type: "integer", nullable: true, comment: "全幅(mm)"),
                    Body_Height = table.Column<int>(type: "integer", nullable: true, comment: "全高(mm)"),
                    Body_WheelBase = table.Column<int>(type: "integer", nullable: true, comment: "ホイールベース(mm)"),
                    Body_TreadFront = table.Column<int>(type: "integer", nullable: true, comment: "トレッド前(mm)"),
                    Body_TreadRear = table.Column<int>(type: "integer", nullable: true, comment: "トレッド後(mm)"),
                    Body_MinRoadClearance = table.Column<int>(type: "integer", nullable: true, comment: "最低地上高(mm)"),
                    Body_Weight = table.Column<int>(type: "integer", nullable: true, comment: "車両重量(kg)"),
                    Body_DoorNum = table.Column<int>(type: "integer", nullable: true, comment: "ドア数"),
                    Interior_Length = table.Column<int>(type: "integer", nullable: true, comment: "室内長(mm)"),
                    Interior_Width = table.Column<int>(type: "integer", nullable: true, comment: "室内幅(mm)"),
                    Interior_Height = table.Column<int>(type: "integer", nullable: true, comment: "室内高(mm)"),
                    Interior_LuggageCap = table.Column<int>(type: "integer", nullable: true, comment: "ラゲッジルーム容量(L)"),
                    Interior_RidingCap = table.Column<int>(type: "integer", nullable: true, comment: "乗車定員(人)"),
                    Performance_MinTurningRadius = table.Column<float>(type: "real", nullable: true, comment: "最小回転半径(m)"),
                    Performance_FcrWltc = table.Column<float>(type: "real", nullable: true, comment: "燃料消費率WLTCモード(km/L)"),
                    Performance_FcrWltcL = table.Column<float>(type: "real", nullable: true, comment: "燃料消費率WLTC市街地モード(km/L)"),
                    Performance_FcrWltcM = table.Column<float>(type: "real", nullable: true, comment: "燃料消費率WLTC郊外モード(km/L)"),
                    Performance_FcrWltcH = table.Column<float>(type: "real", nullable: true, comment: "燃料消費率WLTC高速道路モード(km/L)"),
                    Performance_FcrWltcExh = table.Column<float>(type: "real", nullable: true, comment: "燃料消費率WLTC高高速道路モード(km/L)"),
                    Performance_FcrJc08 = table.Column<float>(type: "real", nullable: true, comment: "燃料消費率JC08モード(km/L)"),
                    Performance_MpcWltc = table.Column<float>(type: "real", nullable: true, comment: "一充電走行距離WLTCモード(km)"),
                    Performance_EcrWltc = table.Column<float>(type: "real", nullable: true, comment: "交流電力消費率WTLCモード(Wh/km)"),
                    Performance_EcrWltcL = table.Column<float>(type: "real", nullable: true, comment: "交流電力消費率WLTC市街地モード(Wh/km)"),
                    Performance_EcrWltcM = table.Column<float>(type: "real", nullable: true, comment: "交流電力消費率WLTC郊外モード(Wh/km)"),
                    Performance_EcrWltcH = table.Column<float>(type: "real", nullable: true, comment: "交流電力消費率WLTC高速道路モード(Wh/km)"),
                    Performance_EcrWltcExh = table.Column<float>(type: "real", nullable: true, comment: "交流電力消費率WLTC高高速道路モード(Wh/km)"),
                    Performance_EcrJc08 = table.Column<float>(type: "real", nullable: true, comment: "交流電力消費率JC08モード(Wh/km)"),
                    Performance_MpcJc08 = table.Column<float>(type: "real", nullable: true, comment: "一充電走行距離JC08モード(km)"),
                    PowerTrain = table.Column<int>(type: "integer", nullable: true, comment: "パワートレイン(ICE/StrHV/MldHV/SerHV/PHEV/BEV/RexEV/FCEV)"),
                    DriveSystem = table.Column<int>(type: "integer", nullable: true, comment: "駆動方式(FF/FR/RR/MR/AWD)"),
                    Engine_Code = table.Column<string>(type: "text", nullable: true, comment: "エンジン型式"),
                    Engine_Type = table.Column<string>(type: "text", nullable: true, comment: "エンジン種類"),
                    Engine_CylinderNum = table.Column<int>(type: "integer", nullable: true, comment: "気筒数"),
                    Engine_CylinderLayout = table.Column<int>(type: "integer", nullable: true, comment: "シリンダーレイアウト(I/V/B/W)"),
                    Engine_ValveSystem = table.Column<int>(type: "integer", nullable: true, comment: "バルブ構造(SV/OHV/SOHC/DOHC)"),
                    Engine_Displacement = table.Column<float>(type: "real", nullable: true, comment: "総排気量(L)"),
                    Engine_Bore = table.Column<float>(type: "real", nullable: true, comment: "ボア(mm)"),
                    Engine_Stroke = table.Column<float>(type: "real", nullable: true, comment: "ストローク(mm)"),
                    Engine_CompressionRatio = table.Column<float>(type: "real", nullable: true, comment: "圧縮比"),
                    Engine_MaxOutput = table.Column<float>(type: "real", nullable: true, comment: "最高出力(kW)"),
                    Engine_MaxOutputLowerRpm = table.Column<int>(type: "integer", nullable: true, comment: "最高出力回転数(低)(rpm)"),
                    Engine_MaxOutputUpperRpm = table.Column<int>(type: "integer", nullable: true, comment: "最高出力回転数(高)(rpm)"),
                    Engine_MaxTorque = table.Column<float>(type: "real", nullable: true, comment: "最大トルク(Nm)"),
                    Engine_MaxTorqueLowerRpm = table.Column<int>(type: "integer", nullable: true, comment: "最大トルク回転数(低)(rpm)"),
                    Engine_MaxTorqueUpperRpm = table.Column<int>(type: "integer", nullable: true, comment: "最大トルク回転数(高)(rpm)"),
                    Engine_FuelSystem = table.Column<string>(type: "text", nullable: true, comment: "燃料供給装置"),
                    Engine_FuelType = table.Column<int>(type: "integer", nullable: true, comment: "使用燃料種類(軽油/無鉛レギュラーガソリン/無鉛プレミアムガソリン)"),
                    Engine_FuelTankCap = table.Column<int>(type: "integer", nullable: true, comment: "燃料タンク容量(L)"),
                    MotorX_Code = table.Column<string>(type: "text", nullable: true, comment: "電動機型式"),
                    MotorX_Type = table.Column<string>(type: "text", nullable: true, comment: "電動機種類"),
                    MotorX_Purpose = table.Column<string>(type: "text", nullable: true, comment: "用途(動力前用/動力後用/発電用)"),
                    MotorX_RatedOutput = table.Column<float>(type: "real", nullable: true, comment: "定格出力(kW)"),
                    MotorX_MaxOutput = table.Column<float>(type: "real", nullable: true, comment: "最高出力(kW)"),
                    MotorX_MaxOutputLowerRpm = table.Column<int>(type: "integer", nullable: true, comment: "最高出力回転数(低)(rpm)"),
                    MotorX_MaxOutputUpperRpm = table.Column<int>(type: "integer", nullable: true, comment: "最高出力回転数(高)(rpm)"),
                    MotorX_MaxTorque = table.Column<float>(type: "real", nullable: true, comment: "最大トルク(Nm)"),
                    MotorX_MaxTorqueLowerRpm = table.Column<int>(type: "integer", nullable: true, comment: "最大トルク回転数(低)(rpm)"),
                    MotorX_MaxTorqueUpperRpm = table.Column<int>(type: "integer", nullable: true, comment: "最大トルク回転数(高)(rpm)"),
                    MotorY_Code = table.Column<string>(type: "text", nullable: true, comment: "電動機型式"),
                    MotorY_Type = table.Column<string>(type: "text", nullable: true, comment: "電動機種類"),
                    MotorY_Purpose = table.Column<string>(type: "text", nullable: true, comment: "用途(動力前用/動力後用/発電用)"),
                    MotorY_RatedOutput = table.Column<float>(type: "real", nullable: true, comment: "定格出力(kW)"),
                    MotorY_MaxOutput = table.Column<float>(type: "real", nullable: true, comment: "最高出力(kW)"),
                    MotorY_MaxOutputLowerRpm = table.Column<int>(type: "integer", nullable: true, comment: "最高出力回転数(低)(rpm)"),
                    MotorY_MaxOutputUpperRpm = table.Column<int>(type: "integer", nullable: true, comment: "最高出力回転数(高)(rpm)"),
                    MotorY_MaxTorque = table.Column<float>(type: "real", nullable: true, comment: "最大トルク(Nm)"),
                    MotorY_MaxTorqueLowerRpm = table.Column<int>(type: "integer", nullable: true, comment: "最大トルク回転数(低)(rpm)"),
                    MotorY_MaxTorqueUpperRpm = table.Column<int>(type: "integer", nullable: true, comment: "最大トルク回転数(高)(rpm)"),
                    Battery_Type = table.Column<string>(type: "text", nullable: true, comment: "バッテリー種類"),
                    Battery_Quantity = table.Column<int>(type: "integer", nullable: true, comment: "バッテリー個数"),
                    Battery_Voltage = table.Column<float>(type: "real", nullable: true, comment: "バッテリー電圧(V)"),
                    Battery_Capacity = table.Column<float>(type: "real", nullable: true, comment: "バッテリー容量(Ah)"),
                    Steering = table.Column<string>(type: "text", nullable: true, comment: "ステアリング形式"),
                    SuspensionFront = table.Column<string>(type: "text", nullable: true, comment: "サスペンション形式前"),
                    SuspensionRear = table.Column<string>(type: "text", nullable: true, comment: "サスペンション形式後"),
                    BrakeFront = table.Column<string>(type: "text", nullable: true, comment: "ブレーキ形式前"),
                    BrakeRear = table.Column<string>(type: "text", nullable: true, comment: "ブレーキ形式後"),
                    TireFront_SectionWidth = table.Column<int>(type: "integer", nullable: true, comment: "タイヤ幅(mm)"),
                    TireFront_AspectRatio = table.Column<int>(type: "integer", nullable: true, comment: "扁平率(%)"),
                    TireFront_WheelDiameter = table.Column<int>(type: "integer", nullable: true, comment: "ホイール径(インチ)"),
                    TireRear_SectionWidth = table.Column<int>(type: "integer", nullable: true, comment: "タイヤ幅(mm)"),
                    TireRear_AspectRatio = table.Column<int>(type: "integer", nullable: true, comment: "扁平率(%)"),
                    TireRear_WheelDiameter = table.Column<int>(type: "integer", nullable: true, comment: "ホイール径(インチ)"),
                    Transmission_Type = table.Column<int>(type: "integer", nullable: true, comment: "種類(AT/DCT/AMT/MT/CVT)"),
                    Transmission_GearRatiosFront = table.Column<float[]>(type: "real[]", nullable: true, comment: "変速比前進配列"),
                    Transmission_GearRatioRear = table.Column<float>(type: "real", nullable: true, comment: "変速比後退"),
                    Transmission_ReductionRatioFront = table.Column<float>(type: "real", nullable: true, comment: "減速比フロント"),
                    Transmission_ReductionRatioRear = table.Column<float>(type: "real", nullable: true, comment: "減速比リア"),
                    FuelEfficiency = table.Column<string[]>(type: "text[]", nullable: false, comment: "燃費向上対策")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Supplier = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<LocalDate>(type: "date", nullable: false),
                    Time = table.Column<LocalTime>(type: "time", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3af2775-4f6b-47e0-808b-72350b46fa5a", "de330a13-24a4-4187-a175-f25790c434b5", "Administrator", "ADMINISTRATOR" },
                    { "d971df93-6b6e-4623-bca5-d89ed44b5207", "4b4268c7-9744-408b-b040-c641df12485a", "Viewer", "VIEWER" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrakeFront", "BrakeRear", "DeletedAt", "DriveSystem", "FuelEfficiency", "GradeName", "ImageUrl", "MakerName", "ModelChangeFull", "ModelChangeLast", "ModelCode", "ModelName", "PowerTrain", "Price", "Steering", "SuspensionFront", "SuspensionRear", "Url", "Body_DoorNum", "Body_Height", "Body_Length", "Body_MinRoadClearance", "Body_TreadFront", "Body_TreadRear", "Body_Type", "Body_Weight", "Body_WheelBase", "Body_Width", "TireFront_AspectRatio", "TireFront_SectionWidth", "TireFront_WheelDiameter", "TireRear_AspectRatio", "TireRear_SectionWidth", "TireRear_WheelDiameter", "Engine_Bore", "Engine_Code", "Engine_CompressionRatio", "Engine_CylinderLayout", "Engine_CylinderNum", "Engine_Displacement", "Engine_FuelSystem", "Engine_FuelTankCap", "Engine_FuelType", "Engine_MaxOutput", "Engine_MaxOutputLowerRpm", "Engine_MaxOutputUpperRpm", "Engine_MaxTorque", "Engine_MaxTorqueLowerRpm", "Engine_MaxTorqueUpperRpm", "Engine_Stroke", "Engine_Type", "Engine_ValveSystem", "Interior_Height", "Interior_Length", "Interior_LuggageCap", "Interior_RidingCap", "Interior_Width", "Performance_EcrJc08", "Performance_EcrWltc", "Performance_EcrWltcExh", "Performance_EcrWltcH", "Performance_EcrWltcL", "Performance_EcrWltcM", "Performance_FcrJc08", "Performance_FcrWltc", "Performance_FcrWltcExh", "Performance_FcrWltcH", "Performance_FcrWltcL", "Performance_FcrWltcM", "Performance_MinTurningRadius", "Performance_MpcJc08", "Performance_MpcWltc", "Transmission_GearRatioRear", "Transmission_GearRatiosFront", "Transmission_ReductionRatioFront", "Transmission_ReductionRatioRear", "Transmission_Type" },
                values: new object[] { 1, "ベンチレーテッドディスク", "ディスク", null, 4, new[] { "ミラーサイクルエンジン", "アイドリングストップ機構", "筒内直接噴射", "可変バルブタイミング", "気筒休止", "充電制御", "ロックアップ機構付トルクコンバーター", "電動パワーステアリング" }, "25S Proactive", "https://upload.wikimedia.org/wikipedia/commons/8/85/2017_Mazda_CX-5_%28KF%29_Maxx_2WD_wagon_%282018-11-02%29_01.jpg", "マツダ", "2016-12-15", "2018-01-01", "6BA-KF5P", "CX-5", 0, 3140500, "ラック&ピニオン式", "マクファーソンストラット式", "マルチリンク式", "https://www.mazda.co.jp/cars/cx-5/", 4, 1690, 4545, 210, 1595, 1595, 8, 1620, 2700, 1840, 55, 225, 19, 55, 225, 19, 89f, "PY-RPS", 13f, 0, 4, 2.488f, "DI", 58, 1, 138f, 6000, 6000, 250f, 4000, 4000, 100f, "水冷直列4気筒DOHC16バルブ", 3, 1265, 1890, null, 5, 1540, null, null, null, null, null, null, 14.2f, 13f, null, 14.7f, 10.2f, 13.4f, 5.5f, null, null, 3.893f, new[] { 3.552f, 2.022f, 1.452f, 1f, 0.708f, 0.599f }, 4.624f, 2.928f, 0 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrakeFront", "BrakeRear", "DeletedAt", "DriveSystem", "FuelEfficiency", "GradeName", "ImageUrl", "MakerName", "ModelChangeFull", "ModelChangeLast", "ModelCode", "ModelName", "PowerTrain", "Price", "Steering", "SuspensionFront", "SuspensionRear", "Url", "Battery_Capacity", "Battery_Quantity", "Battery_Type", "Battery_Voltage", "Body_DoorNum", "Body_Height", "Body_Length", "Body_MinRoadClearance", "Body_TreadFront", "Body_TreadRear", "Body_Type", "Body_Weight", "Body_WheelBase", "Body_Width", "MotorX_Code", "MotorX_MaxOutput", "MotorX_MaxOutputLowerRpm", "MotorX_MaxOutputUpperRpm", "MotorX_MaxTorque", "MotorX_MaxTorqueLowerRpm", "MotorX_MaxTorqueUpperRpm", "MotorX_Purpose", "MotorX_RatedOutput", "MotorX_Type", "MotorY_Code", "MotorY_MaxOutput", "MotorY_MaxOutputLowerRpm", "MotorY_MaxOutputUpperRpm", "MotorY_MaxTorque", "MotorY_MaxTorqueLowerRpm", "MotorY_MaxTorqueUpperRpm", "MotorY_Purpose", "MotorY_RatedOutput", "MotorY_Type", "TireFront_AspectRatio", "TireFront_SectionWidth", "TireFront_WheelDiameter", "TireRear_AspectRatio", "TireRear_SectionWidth", "TireRear_WheelDiameter", "Engine_Bore", "Engine_Code", "Engine_CompressionRatio", "Engine_CylinderLayout", "Engine_CylinderNum", "Engine_Displacement", "Engine_FuelSystem", "Engine_FuelTankCap", "Engine_FuelType", "Engine_MaxOutput", "Engine_MaxOutputLowerRpm", "Engine_MaxOutputUpperRpm", "Engine_MaxTorque", "Engine_MaxTorqueLowerRpm", "Engine_MaxTorqueUpperRpm", "Engine_Stroke", "Engine_Type", "Engine_ValveSystem", "Interior_Height", "Interior_Length", "Interior_LuggageCap", "Interior_RidingCap", "Interior_Width", "Performance_EcrJc08", "Performance_EcrWltc", "Performance_EcrWltcExh", "Performance_EcrWltcH", "Performance_EcrWltcL", "Performance_EcrWltcM", "Performance_FcrJc08", "Performance_FcrWltc", "Performance_FcrWltcExh", "Performance_FcrWltcH", "Performance_FcrWltcL", "Performance_FcrWltcM", "Performance_MinTurningRadius", "Performance_MpcJc08", "Performance_MpcWltc", "Transmission_GearRatioRear", "Transmission_GearRatiosFront", "Transmission_ReductionRatioFront", "Transmission_ReductionRatioRear", "Transmission_Type" },
                values: new object[,]
                {
                    { 2, "ベンチレーテッドディスク", "ディスク", null, 4, new[] { "ハイブリッドシステム", "アイドリングストップ装置", "可変バルブタイミング", "電動パワーステアリング", "充電制御", "電気式無段変速機" }, "HYBRID G-X E-Four", "https://upload.wikimedia.org/wikipedia/commons/8/8a/Toyota_COROLLA_TOURING_HYBRID_W%C3%97B_2WD_%286AA-ZWE211W-AWXSB%29_front.jpg", "トヨタ", "2019-09-17", "2021-11-15", "6AA-ZWE214W-AWXNB", "カローラツーリング", 1, 2678500, null, "マクファーソンストラット式コイルスプリング", "ダブルウィッシュボーン式コイルスプリング", "https://toyota.jp/corollatouring/", 6.5f, null, "ニッケル水素電池", null, 4, 1460, 4495, 130, 1530, 1540, 7, 1410, 2640, 1745, "1NM", 53f, null, null, 163f, null, null, "動力前用", null, "交流同期電動機", "1MM", 5.3f, null, null, 55f, null, null, "動力後用", null, "交流同期電動機", 65, 195, 15, 65, 195, 15, 80.5f, "2ZR-FXE", null, 0, 4, 1.797f, "電子制御式燃料噴射装置(EFI)", 43, 1, 72f, 5200, 5200, 142f, 3600, 3600, 88.3f, "直列4気筒 DOHC 16バルブ VVT-i ミラーサイクル", 3, 1160, 1790, null, 5, 1510, null, null, null, null, null, null, 31f, 26.8f, null, 26.8f, 25.1f, 28.1f, 5f, null, null, null, null, 2.834f, 10.487f, 5 },
                    { 3, "油圧式ベンチレーテッドディスク", "油圧式ベンチレーテッドディスク", null, 4, new[] { "ハイブリッドシステム", "直噴エンジン", "可変バルブタイミング", "アイドリングストップ装置", "電動パワーステアリング" }, "Type S", "https://upload.wikimedia.org/wikipedia/commons/e/ea/2019_Honda_NSX_3.5_CAA-NC1_%2820190722%29_01.jpg", "ホンダ", "2017-02-27", "2021-08-30", "5AA-NC1", "NSX", 2, 27940000, "ラック&ピニオン式(電動パワーステアリング仕様)", "ダブルウィッシュボーン式", "ウィッシュボーン式", "https://www.honda.co.jp/NSX/types/", null, 72, "ニッケル水素電池", null, 2, 1215, 4535, 110, 1665, 1635, 6, 1790, 2630, 1940, "H3", 27f, 4000, 4000, 73f, 0, 2000, "動力前用", null, "交流同期電動機", "H2", 35f, 3000, 3000, 148f, 500, 2000, "動力後用", null, "交流同期電動機", 35, 245, 19, 30, 305, 20, 91f, "JNC", 10f, 1, 6, 3.492f, "電子制御燃料噴射式(ホンダ PGM-FI)", 59, 2, 389f, 6500, 6850, 600f, 2300, 6000, 89.5f, "水冷V型6気筒縦置", 3, null, null, null, 2, null, null, null, null, null, null, null, null, 10.6f, null, 11.4f, 7.8f, 12.1f, 5.9f, null, null, null, new[] { 3.838f, 2.433f, 1.777f, 1.427f, 1.211f, 1.038f, 0.88f, 0.747f, 0.633f }, 10.382f, 3.583f, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrakeFront", "BrakeRear", "DeletedAt", "DriveSystem", "FuelEfficiency", "GradeName", "ImageUrl", "MakerName", "ModelChangeFull", "ModelChangeLast", "ModelCode", "ModelName", "PowerTrain", "Price", "Steering", "SuspensionFront", "SuspensionRear", "Url", "Battery_Capacity", "Battery_Quantity", "Battery_Type", "Battery_Voltage", "Body_DoorNum", "Body_Height", "Body_Length", "Body_MinRoadClearance", "Body_TreadFront", "Body_TreadRear", "Body_Type", "Body_Weight", "Body_WheelBase", "Body_Width", "MotorX_Code", "MotorX_MaxOutput", "MotorX_MaxOutputLowerRpm", "MotorX_MaxOutputUpperRpm", "MotorX_MaxTorque", "MotorX_MaxTorqueLowerRpm", "MotorX_MaxTorqueUpperRpm", "MotorX_Purpose", "MotorX_RatedOutput", "MotorX_Type", "TireFront_AspectRatio", "TireFront_SectionWidth", "TireFront_WheelDiameter", "TireRear_AspectRatio", "TireRear_SectionWidth", "TireRear_WheelDiameter", "Interior_Height", "Interior_Length", "Interior_LuggageCap", "Interior_RidingCap", "Interior_Width", "Performance_EcrJc08", "Performance_EcrWltc", "Performance_EcrWltcExh", "Performance_EcrWltcH", "Performance_EcrWltcL", "Performance_EcrWltcM", "Performance_FcrJc08", "Performance_FcrWltc", "Performance_FcrWltcExh", "Performance_FcrWltcH", "Performance_FcrWltcL", "Performance_FcrWltcM", "Performance_MinTurningRadius", "Performance_MpcJc08", "Performance_MpcWltc", "Transmission_GearRatioRear", "Transmission_GearRatiosFront", "Transmission_ReductionRatioFront", "Transmission_ReductionRatioRear", "Transmission_Type" },
                values: new object[] { 4, "油圧式ベンチレーテッドディスク", "油圧式ディスク", null, 2, new[] { "電動パワーステアリング" }, "Honda e Advance", "https://upload.wikimedia.org/wikipedia/commons/9/9e/Honda_e_Advance_%28ZAA-ZC7%29_front.jpg", "ホンダ", "2020-08-27", "2020-08-27", "ZAA-ZC7", "Honda e", 5, 4950000, "ラック&ピニオン式", "マクファーソン式", "マクファーソン式", "https://www.honda.co.jp/honda-e/", 50f, 193, "リチウムイオン電池", 3.7f, 4, 1510, 3895, 145, 1510, 1505, 1, 1540, 2530, 1750, "MCF5", 113f, 3497, 10000, 315f, 0, 2000, "動力後用", 60f, "交流同期電動機", 45, 205, 17, 45, 225, 17, 1120, 1845, null, 4, 1385, 135f, 138f, null, 149f, 116f, 130f, null, null, null, null, null, null, 4.3f, 274f, 259f, null, null, 9.545f, null, null });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrakeFront", "BrakeRear", "DeletedAt", "DriveSystem", "FuelEfficiency", "GradeName", "ImageUrl", "MakerName", "ModelChangeFull", "ModelChangeLast", "ModelCode", "ModelName", "PowerTrain", "Price", "Steering", "SuspensionFront", "SuspensionRear", "Url", "Battery_Capacity", "Battery_Quantity", "Battery_Type", "Battery_Voltage", "Body_DoorNum", "Body_Height", "Body_Length", "Body_MinRoadClearance", "Body_TreadFront", "Body_TreadRear", "Body_Type", "Body_Weight", "Body_WheelBase", "Body_Width", "MotorX_Code", "MotorX_MaxOutput", "MotorX_MaxOutputLowerRpm", "MotorX_MaxOutputUpperRpm", "MotorX_MaxTorque", "MotorX_MaxTorqueLowerRpm", "MotorX_MaxTorqueUpperRpm", "MotorX_Purpose", "MotorX_RatedOutput", "MotorX_Type", "MotorY_Code", "MotorY_MaxOutput", "MotorY_MaxOutputLowerRpm", "MotorY_MaxOutputUpperRpm", "MotorY_MaxTorque", "MotorY_MaxTorqueLowerRpm", "MotorY_MaxTorqueUpperRpm", "MotorY_Purpose", "MotorY_RatedOutput", "MotorY_Type", "TireFront_AspectRatio", "TireFront_SectionWidth", "TireFront_WheelDiameter", "TireRear_AspectRatio", "TireRear_SectionWidth", "TireRear_WheelDiameter", "Engine_Bore", "Engine_Code", "Engine_CompressionRatio", "Engine_CylinderLayout", "Engine_CylinderNum", "Engine_Displacement", "Engine_FuelSystem", "Engine_FuelTankCap", "Engine_FuelType", "Engine_MaxOutput", "Engine_MaxOutputLowerRpm", "Engine_MaxOutputUpperRpm", "Engine_MaxTorque", "Engine_MaxTorqueLowerRpm", "Engine_MaxTorqueUpperRpm", "Engine_Stroke", "Engine_Type", "Engine_ValveSystem", "Interior_Height", "Interior_Length", "Interior_LuggageCap", "Interior_RidingCap", "Interior_Width", "Performance_EcrJc08", "Performance_EcrWltc", "Performance_EcrWltcExh", "Performance_EcrWltcH", "Performance_EcrWltcL", "Performance_EcrWltcM", "Performance_FcrJc08", "Performance_FcrWltc", "Performance_FcrWltcExh", "Performance_FcrWltcH", "Performance_FcrWltcL", "Performance_FcrWltcM", "Performance_MinTurningRadius", "Performance_MpcJc08", "Performance_MpcWltc", "Transmission_GearRatioRear", "Transmission_GearRatiosFront", "Transmission_ReductionRatioFront", "Transmission_ReductionRatioRear", "Transmission_Type" },
                values: new object[] { 5, "ベンチレーテッドディスク式", "リーディングトレーリング式", null, 4, new[] { "ハイブリッドシステム", "アイドリングストップ装置", "可変バルブタイミング", "ミラーサイクル", "電動パワーステアリング" }, "X FOUR", "https://upload.wikimedia.org/wikipedia/commons/0/0a/Nissan_Note_e-POWER_%28E13%29%2C_2021%2C_front-left.jpg", "日産", "2020-11-24", "2021-11-04", "6AA-SNE13", "ノート", 3, 2445300, "ラック&ピニオン式", "独立懸架ストラット式", "トーションビーム式", "https://www3.nissan.co.jp/vehicles/new/note.html", null, null, "リチウムイオン電池", null, 4, 1520, 4045, 125, 1490, 1490, 1, 1340, 2580, 1695, "EM47", 85f, 2900, 10341, 280f, 0, 2900, "発電用", null, "交流同期電動機", "MM48", 50f, 4775, 10024, 100f, 0, 4775, "動力後用", null, "交流同期電動機", 60, 185, 16, 60, 185, 16, 78f, "HR12DE", 12f, 0, 3, 1.198f, "ニッサンEGI(ECCS)電子制御燃料噴射装置", 36, 1, 60f, 6000, 6000, 103f, 4800, 4800, 83.6f, "DOHC水冷直列3気筒", 3, 1240, 2030, null, 5, 1445, null, null, null, null, null, null, 28.2f, 23.8f, null, 22.9f, 23.1f, 25.8f, 4.9f, null, null, null, null, 7.388f, 7.282f, null });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrakeFront", "BrakeRear", "DeletedAt", "DriveSystem", "FuelEfficiency", "GradeName", "ImageUrl", "MakerName", "ModelChangeFull", "ModelChangeLast", "ModelCode", "ModelName", "PowerTrain", "Price", "Steering", "SuspensionFront", "SuspensionRear", "Url", "Body_DoorNum", "Body_Height", "Body_Length", "Body_MinRoadClearance", "Body_TreadFront", "Body_TreadRear", "Body_Type", "Body_Weight", "Body_WheelBase", "Body_Width", "TireFront_AspectRatio", "TireFront_SectionWidth", "TireFront_WheelDiameter", "TireRear_AspectRatio", "TireRear_SectionWidth", "TireRear_WheelDiameter", "Engine_Bore", "Engine_Code", "Engine_CompressionRatio", "Engine_CylinderLayout", "Engine_CylinderNum", "Engine_Displacement", "Engine_FuelSystem", "Engine_FuelTankCap", "Engine_FuelType", "Engine_MaxOutput", "Engine_MaxOutputLowerRpm", "Engine_MaxOutputUpperRpm", "Engine_MaxTorque", "Engine_MaxTorqueLowerRpm", "Engine_MaxTorqueUpperRpm", "Engine_Stroke", "Engine_Type", "Engine_ValveSystem", "Interior_Height", "Interior_Length", "Interior_LuggageCap", "Interior_RidingCap", "Interior_Width", "Performance_EcrJc08", "Performance_EcrWltc", "Performance_EcrWltcExh", "Performance_EcrWltcH", "Performance_EcrWltcL", "Performance_EcrWltcM", "Performance_FcrJc08", "Performance_FcrWltc", "Performance_FcrWltcExh", "Performance_FcrWltcH", "Performance_FcrWltcL", "Performance_FcrWltcM", "Performance_MinTurningRadius", "Performance_MpcJc08", "Performance_MpcWltc", "Transmission_GearRatioRear", "Transmission_GearRatiosFront", "Transmission_ReductionRatioFront", "Transmission_ReductionRatioRear", "Transmission_Type" },
                values: new object[] { 6, "ベンチレーテッドディスク", "ベンチレーテッドディスク", null, 4, new[] { "筒内直接噴射", "電子制御式燃料噴射", "高圧噴射(コモンレール・ダイレクト・インジェクション・システム)", "過給機(可変ジオメトリー・ターボチャージャー)", "充電制御(ブレーキ・エネルギー回生システム)", "アイドリング・ストップ装置(エンジン・オート・スタート/ストップ)", "電動パワーステアリング" }, "320d xDriveツーリング Standard", null, "BMW", "2019-09-26", "2019-09-26", "3DA-6L20", "3シリーズツーリング", 0, 6340000, "ラック&ピニオン式、単速感応式パワー・ステアリング", "ダブル・ジョイント・スプリング・ストラット式、コイルスプリング", "5リンク式、コイル・スプリング", "https://www.bmw.co.jp/ja/all-models/3-series/touring/2019/bmw-3-series-touring-inspire.html", 4, 1475, 4715, 135, 1575, 1590, 7, 1730, 2850, 1825, 50, 225, 17, 50, 225, 17, null, "B47D20B", null, 0, 4, 1.995f, "デジタル・ディーゼル・エレクトロニクス(DDE/電子燃料噴射装置)", 59, 0, 140f, 4000, 4000, 400f, 1750, 2500, null, "直列4気筒DOHCディーゼル", 3, null, null, 500, 5, null, null, null, null, null, null, null, 19.6f, 15.6f, null, 18f, 12.6f, 14.9f, 5.7f, null, null, null, new[] { 5.25f, 3.36f, 2.172f, 1.72f, 1.316f, 1f, 0.822f, 0.64f }, 2.813f, null, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "Supplier" },
                values: new object[,]
                {
                    { new Guid("0102f709-1dd7-40de-af3d-23598c6bbd1f"), "https://ih1.redbubble.net/image.1062161969.4889/mug,travel,x1000,center-pad,1000x1000,f8f8f8.u2.jpg", "Travel Mug", 11.0, "Code Maze" },
                    { new Guid("2d3c2abe-85ec-4d1e-9fef-9b4bfea5f459"), "https://ih1.redbubble.net/image.1063329780.4889/mwo,x1000,ipad_2_snap-pad,1000x1000,f8f8f8.u2.jpg", "iPad Case & Skin", 45.0, "Code Maze" },
                    { new Guid("488aaa0e-aa7e-4820-b4e9-5715f0e5186e"), "https://ih1.redbubble.net/image.1062161956.4889/icr,iphone_11_soft,back,a,x1000-pad,1000x1000,f8f8f8.u2.jpg", "iPhone Case & Cover", 25.0, "Code Maze" },
                    { new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), "https://ih1.redbubble.net/image.1062161956.4889/icr,samsung_galaxy_s10_snap,back,a,x1000-pad,1000x1000,f8f8f8.1u2.jpg", "Case & Skin for Samsung Galaxy", 35.0, "Code Maze" },
                    { new Guid("54b2f952-b63e-4cad-8b38-c09955fe4c62"), "https://ih1.redbubble.net/image.1063364659.4889/ssrco,mhoodiez,mens,101010:01c5ca27c6,front,square_three_quarter,1000x1000-bg,f8f8f8.u2.jpg", "Fitted Scoop T-Shirt", 40.0, "Code Maze" },
                    { new Guid("83e0aa87-158f-4e5f-a8f7-e5a98d13e3a5"), "https://ih1.redbubble.net/image.1063364659.4889/ra,fitted_scoop,x2000,101010:01c5ca27c6,front-c,160,143,1000,1000-bg,f8f8f8.u2.jpg", "Zipped Hoodie", 55.0, "Code Maze" },
                    { new Guid("ac7de2dc-049c-4328-ab06-6cde3ebe8aa7"), "https://ih1.redbubble.net/image.1063377597.4889/ur,mug_lifestyle,square,1000x1000.u2.jpg", "Classic Mug", 22.0, "Code Maze" },
                    { new Guid("b47d4c3c-3e29-49b9-b6be-28e5ee4625be"), "https://ih1.redbubble.net/image.1063364659.4889/ssrco,mhoodie,mens,101010:01c5ca27c6,front,square_three_quarter,x1000-bg,f8f8f8.1u2.jpg", "Pullover Hoodie", 30.0, "Code Maze" },
                    { new Guid("d1f22836-6342-480a-be2f-035eeb010fd0"), "https://ih1.redbubble.net/image.1062161997.4889/clkc,bamboo,white,1000x1000-bg,f8f8f8.u2.jpg", "Wall Clock", 25.0, "Code Maze" },
                    { new Guid("d26384cb-64b9-4aca-acb0-4ebb8fc53ba2"), "https://ih1.redbubble.net/image.1063364659.4889/ra,vneck,x1900,101010:01c5ca27c6,front-c,160,70,1000,1000-bg,f8f8f8.u2.jpg", "Code Maze Logo T-Shirt", 20.0, "Code Maze" }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "Time" },
                values: new object[,]
                {
                    { 1, new NodaTime.LocalDate(2022, 5, 18), "雨", 15, new NodaTime.LocalTime(12, 34, 56) },
                    { 2, new NodaTime.LocalDate(2022, 5, 18), "晴れのち曇", 18, new NodaTime.LocalTime(12, 34, 56) },
                    { 3, new NodaTime.LocalDate(2022, 5, 18), "晴", 22, new NodaTime.LocalTime(12, 34, 56) },
                    { 4, new NodaTime.LocalDate(2022, 5, 18), "台風", 26, new NodaTime.LocalTime(12, 34, 56) },
                    { 5, new NodaTime.LocalDate(2022, 5, 18), "曇", 21, new NodaTime.LocalTime(12, 34, 56) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);
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
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
