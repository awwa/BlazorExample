using HogeBlazor.Shared.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HogeBlazor.Server.Db.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        ConfigureCx5(builder);
        ConfigureCorolla(builder);
        ConfigureNsx(builder);
        ConfigureHondaE(builder);
        ConfigureNote(builder);
        ConfigureThree(builder);
    }

    private void ConfigureCx5(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(new Car
        {
            Id = 1,
            MakerName = "マツダ",
            ModelName = "CX-5",
            GradeName = "25S Proactive",
            ModelCode = "6BA-KF5P",
            Price = 3140500,
            Url = "https://www.mazda.co.jp/cars/cx-5/",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/85/2017_Mazda_CX-5_%28KF%29_Maxx_2WD_wagon_%282018-11-02%29_01.jpg",
            ModelChangeFull = "2016-12-15",
            ModelChangeLast = "2018-01-01",
            PowerTrain = PowerTrain.ICE,
            DriveSystem = DriveSystem.AWD,
            Steering = "ラック&ピニオン式",
            SuspensionFront = "マクファーソンストラット式",
            SuspensionRear = "マルチリンク式",
            BrakeFront = "ベンチレーテッドディスク",
            BrakeRear = "ディスク",
            FuelEfficiency = new string[]
            {
                "ミラーサイクルエンジン",
                "アイドリングストップ機構",
                "筒内直接噴射",
                "可変バルブタイミング",
                "気筒休止",
                "充電制御",
                "ロックアップ機構付トルクコンバーター",
                "電動パワーステアリング",
            }
        });
        builder.OwnsOne(e => e.Body).HasData(
            new
            {
                CarId = 1,
                Type = BodyType.SUV,
                Length = 4545,
                Width = 1840,
                Height = 1690,
                WheelBase = 2700,
                TreadFront = 1595,
                TreadRear = 1595,
                MinRoadClearance = 210,
                Weight = 1620,
                DoorNum = 4,
            }
        );
        // MotorX: Motor{},
        // MotorY: Motor{},
        // Battery: Battery{},
        builder.OwnsOne(e => e.Interior).HasData(
            new
            {
                CarId = 1,
                Length = 1890,
                Width = 1540,
                Height = 1265,
                // LuggageCap
                RidingCap = 5,
            }
        );
        builder.OwnsOne(e => e.Performance).HasData(
            new
            {
                CarId = 1,
                MinTurningRadius = 5.5f,
                FcrWltc = 13.0f,
                FcrWltcL = 10.2f,
                FcrWltcM = 13.4f,
                FcrWltcH = 14.7f,
                // FcrWltcExh
                FcrJc08 = 14.2f,
                // MpcWltc
                // EcrWltc
                // EcrWltcL
                // EcrWltcM
                // EcrWltcH
                // EcrWltcExh
                // EcrJc08
                // MpcJc08
            }
        );
        builder.OwnsOne(e => e.Engine).HasData(
            new
            {
                CarId = 1,
                Code = "PY-RPS",
                Type = "水冷直列4気筒DOHC16バルブ",
                CylinderNum = 4,
                CylinderLayout = CylinderLayout.I,
                ValveSystem = ValveSystem.DOHC,
                Displacement = 2.488f,
                Bore = 89.0f,
                Stroke = 100.0f,
                CompressionRatio = 13.0f,
                MaxOutput = 138f,
                MaxOutputLowerRpm = 6000,
                MaxOutputUpperRpm = 6000,
                MaxTorque = 250f,
                MaxTorqueLowerRpm = 4000,
                MaxTorqueUpperRpm = 4000,
                FuelSystem = "DI",
                FuelType = FuelType.REGULAR,
                FuelTankCap = 58,
            }
        );
        builder.OwnsOne(e => e.TireFront).HasData(
            new
            {
                CarId = 1,
                SectionWidth = 225,
                AspectRatio = 55,
                WheelDiameter = 19,
            }
        );
        builder.OwnsOne(e => e.TireRear).HasData(
            new
            {
                CarId = 1,
                SectionWidth = 225,
                AspectRatio = 55,
                WheelDiameter = 19,
            }
        );
        builder.OwnsOne(e => e.Transmission).HasData(
            new
            {
                CarId = 1,
                Type = TransmissionType.AT,
                GearRatiosFront = new float[]
                    {
                        3.552f,
                        2.022f,
                        1.452f,
                        1.000f,
                        0.708f,
                        0.599f,
                        //Ratio7
                        //Ratio8
                        //Ratio9
                        //Ratio10
                    },
                GearRatioRear = 3.893f,
                ReductionRatioFront = 4.624f,
                ReductionRatioRear = 2.928f,
            }
        );
    }

    private void ConfigureCorolla(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(new Car
        {
            Id = 2,
            MakerName = "トヨタ",
            ModelName = "カローラツーリング",
            GradeName = "HYBRID G-X E-Four",
            ModelCode = "6AA-ZWE214W-AWXNB",
            Price = 2678500,
            Url = "https://toyota.jp/corollatouring/",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8a/Toyota_COROLLA_TOURING_HYBRID_W%C3%97B_2WD_%286AA-ZWE211W-AWXSB%29_front.jpg",
            ModelChangeFull = "2019-09-17",
            ModelChangeLast = "2021-11-15",
            PowerTrain = PowerTrain.StrHV,
            DriveSystem = DriveSystem.AWD,
            // Steering
            SuspensionFront = "マクファーソンストラット式コイルスプリング",
            SuspensionRear = "ダブルウィッシュボーン式コイルスプリング",
            BrakeFront = "ベンチレーテッドディスク",
            BrakeRear = "ディスク",
            FuelEfficiency = new string[] {
                "ハイブリッドシステム",
                "アイドリングストップ装置",
                "可変バルブタイミング",
                "電動パワーステアリング",
                "充電制御",
                "電気式無段変速機",
            },
        });
        builder.OwnsOne(e => e.Body).HasData(
            new
            {
                CarId = 2,
                Type = BodyType.STATION_WAGON,
                Length = 4495,
                Width = 1745,
                Height = 1460,
                WheelBase = 2640,
                TreadFront = 1530,
                TreadRear = 1540,
                MinRoadClearance = 130,
                Weight = 1410,
                DoorNum = 4,
            }
        );
        builder.OwnsOne(e => e.Interior).HasData(
            new
            {
                CarId = 2,
                Length = 1790,
                Width = 1510,
                Height = 1160,
                // LuggageCap
                RidingCap = 5,
            }
        );
        builder.OwnsOne(e => e.Performance).HasData(
            new
            {
                CarId = 2,
                MinTurningRadius = 5.0f,
                FcrWltc = 26.8f,
                FcrWltcL = 25.1f,
                FcrWltcM = 28.1f,
                FcrWltcH = 26.8f,
                // FcrWltcExh
                FcrJc08 = 31.0f,
                // MpcWltc
                // EcrWltc
                // EcrWltcL
                // EcrWltcM
                // EcrWltcH
                // EcrWltcExh
                // EcrJc08
                // MpcJc08
            }
        );
        builder.OwnsOne(e => e.Engine).HasData(
            new
            {
                CarId = 2,
                Code = "2ZR-FXE",
                Type = "直列4気筒 DOHC 16バルブ VVT-i ミラーサイクル",
                CylinderNum = 4,
                CylinderLayout = CylinderLayout.I,
                ValveSystem = ValveSystem.DOHC,
                Displacement = 1.797f,
                Bore = 80.5f,
                Stroke = 88.3f,
                // CompRatio
                MaxOutput = 72f,
                MaxOutputLowerRpm = 5200,
                MaxOutputUpperRpm = 5200,
                MaxTorque = 142f,
                MaxTorqueLowerRpm = 3600,
                MaxTorqueUpperRpm = 3600,
                FuelSystem = "電子制御式燃料噴射装置(EFI)",
                FuelType = FuelType.REGULAR,
                FuelTankCap = 43,
            }
        );
        builder.OwnsOne(e => e.MotorX).HasData(
            new
            {
                CarId = 2,
                Code = "1NM",
                Type = "交流同期電動機",
                Purpose = "動力前用",
                // RatedOutput
                MaxOutput = 53f,
                // MaxOutputLowerRpm
                // MaxOutputUpperRpm
                MaxTorque = 163f,
                // MaxTorqueLowerRpm
                // MaxTorqueUpperRpm
            }
        );
        builder.OwnsOne(e => e.MotorY).HasData(
            new
            {
                CarId = 2,
                Code = "1MM",
                Type = "交流同期電動機",
                Purpose = "動力後用",
                // RatedOutput
                MaxOutput = 5.3f,
                // MaxOutputLowerRpm
                // MaxOutputUpperRpm
                MaxTorque = 55f,
                // MaxTorqueLowerRpm
                // MaxTorqueUpperRpm
            }
        );
        builder.OwnsOne(e => e.Battery).HasData(
            new
            {
                CarId = 2,
                Type = "ニッケル水素電池",
                // Quantity
                // Voltage
                Capacity = 6.5f,
            }
        );
        builder.OwnsOne(e => e.TireFront).HasData(
            new
            {
                CarId = 2,
                SectionWidth = 195,
                AspectRatio = 65,
                WheelDiameter = 15,
            }
        );
        builder.OwnsOne(e => e.TireRear).HasData(
            new
            {
                CarId = 2,
                SectionWidth = 195,
                AspectRatio = 65,
                WheelDiameter = 15,
            }
        );
        builder.OwnsOne(e => e.Transmission).HasData(
            new
            {
                CarId = 2,
                Type = TransmissionType.PG,
                // GearRatiosFront
                // RatioRear
                ReductionRatioFront = 2.834f,
                ReductionRatioRear = 10.487f,
            }
        );
    }

    private void ConfigureNsx(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(new Car
        {
            Id = 3,
            MakerName = "ホンダ",
            ModelName = "NSX",
            GradeName = "Type S",
            ModelCode = "5AA-NC1",
            Price = 27940000,
            Url = "https://www.honda.co.jp/NSX/types/",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ea/2019_Honda_NSX_3.5_CAA-NC1_%2820190722%29_01.jpg",
            ModelChangeFull = "2017-02-27",
            ModelChangeLast = "2021-08-30",
            PowerTrain = PowerTrain.MldHV,
            DriveSystem = DriveSystem.AWD,
            Steering = "ラック&ピニオン式(電動パワーステアリング仕様)",
            SuspensionFront = "ダブルウィッシュボーン式",
            SuspensionRear = "ウィッシュボーン式",
            BrakeFront = "油圧式ベンチレーテッドディスク",
            BrakeRear = "油圧式ベンチレーテッドディスク",
            FuelEfficiency = new string[] {
                "ハイブリッドシステム",
                "直噴エンジン",
                "可変バルブタイミング",
                "アイドリングストップ装置",
                "電動パワーステアリング",
            }
        });
        builder.OwnsOne(e => e.Body).HasData(
            new
            {
                CarId = 3,
                Type = BodyType.COUPE,
                Length = 4535,
                Width = 1940,
                Height = 1215,
                WheelBase = 2630,
                TreadFront = 1665,
                TreadRear = 1635,
                MinRoadClearance = 110,
                Weight = 1790,
                DoorNum = 2,
            }
        );
        builder.OwnsOne(e => e.Interior).HasData(
            new
            {
                CarId = 3,
                // Length
                // Width
                // Height
                // LuggageCap
                RidingCap = 2,
            }
        );
        builder.OwnsOne(e => e.Performance).HasData(
            new
            {
                CarId = 3,
                MinTurningRadius = 5.9f,
                FcrWltc = 10.6f,
                FcrWltcL = 7.8f,
                FcrWltcM = 12.1f,
                FcrWltcH = 11.4f,
                // FcrWltcExh
                // FcrJc08
                // MpcWltc
                // EcrWltc
                // EcrWltcL
                // EcrWltcM
                // EcrWltcH
                // EcrWltcExh
                // EcrJc08
                // MpcJc08
            }
        );
        builder.OwnsOne(e => e.Engine).HasData(
            new
            {
                CarId = 3,
                Code = "JNC",
                Type = "水冷V型6気筒縦置",
                CylinderNum = 6,
                CylinderLayout = CylinderLayout.V,
                ValveSystem = ValveSystem.DOHC,
                Displacement = 3.492f,
                Bore = 91.0f,
                Stroke = 89.5f,
                CompressionRatio = 10.0f,
                MaxOutput = 389f,
                MaxOutputLowerRpm = 6500,
                MaxOutputUpperRpm = 6850,
                MaxTorque = 600f,
                MaxTorqueLowerRpm = 2300,
                MaxTorqueUpperRpm = 6000,
                FuelSystem = "電子制御燃料噴射式(ホンダ PGM-FI)",
                FuelType = FuelType.PREMIUM,
                FuelTankCap = 59,
            }
        );
        builder.OwnsOne(e => e.MotorX).HasData(
            new
            {
                CarId = 3,
                Code = "H3",
                Type = "交流同期電動機",
                Purpose = "動力前用",
                // RatedOutput
                MaxOutput = 27f,
                MaxOutputLowerRpm = 4000,
                MaxOutputUpperRpm = 4000,
                MaxTorque = 73f,
                MaxTorqueLowerRpm = 0,
                MaxTorqueUpperRpm = 2000,
            }
        );
        builder.OwnsOne(e => e.MotorY).HasData(
            new
            {
                CarId = 3,
                Code = "H2",
                Type = "交流同期電動機",
                Purpose = "動力後用",
                // RatedOutput
                MaxOutput = 35f,
                MaxOutputLowerRpm = 3000,
                MaxOutputUpperRpm = 3000,
                MaxTorque = 148f,
                MaxTorqueLowerRpm = 500,
                MaxTorqueUpperRpm = 2000,
            }
        );
        builder.OwnsOne(e => e.Battery).HasData(
            new
            {
                CarId = 3,
                Type = "ニッケル水素電池",
                Quantity = 72,
                // Voltage
                // Capacity
            }
        );
        builder.OwnsOne(e => e.TireFront).HasData(
            new
            {
                CarId = 3,
                SectionWidth = 245,
                AspectRatio = 35,
                WheelDiameter = 19,
            }
        );
        builder.OwnsOne(e => e.TireRear).HasData(
            new
            {
                CarId = 3,
                SectionWidth = 305,
                AspectRatio = 30,
                WheelDiameter = 20,
            }
        );
        builder.OwnsOne(e => e.Transmission).HasData(
            new
            {
                CarId = 3,
                Type = TransmissionType.DCT,
                GearRatiosFront = new float[]
                {
                    3.838f,
                    2.433f,
                    1.777f,
                    1.427f,
                    1.211f,
                    1.038f,
                    0.880f,
                    0.747f,
                    0.633f,
                    // Ratio10
                },
                RatioRear = 2.394f,
                ReductionRatioFront = 10.382f,
                ReductionRatioRear = 3.583f,
            }
        );
    }

    private void ConfigureHondaE(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(new Car
        {
            Id = 4,
            MakerName = "ホンダ",
            ModelName = "Honda e",
            GradeName = "Honda e Advance",
            ModelCode = "ZAA-ZC7",
            Price = 4950000,
            Url = "https://www.honda.co.jp/honda-e/",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9e/Honda_e_Advance_%28ZAA-ZC7%29_front.jpg",
            ModelChangeFull = "2020-08-27",
            ModelChangeLast = "2020-08-27",
            PowerTrain = PowerTrain.BEV,
            DriveSystem = DriveSystem.RR,
            Steering = "ラック&ピニオン式",
            SuspensionFront = "マクファーソン式",
            SuspensionRear = "マクファーソン式",
            BrakeFront = "油圧式ベンチレーテッドディスク",
            BrakeRear = "油圧式ディスク",
            FuelEfficiency = new string[] {
                "電動パワーステアリング",
            }
        });
        builder.OwnsOne(e => e.Body).HasData(
            new
            {
                CarId = 4,
                Type = BodyType.HATCHBACK,
                Length = 3895,
                Width = 1750,
                Height = 1510,
                WheelBase = 2530,
                TreadFront = 1510,
                TreadRear = 1505,
                MinRoadClearance = 145,
                Weight = 1540,
                DoorNum = 4,
            }
        );
        builder.OwnsOne(e => e.Interior).HasData(
            new
            {
                CarId = 4,
                Length = 1845,
                Width = 1385,
                Height = 1120,
                // LuggageCap
                RidingCap = 4,
            }
        );
        builder.OwnsOne(e => e.Performance).HasData(
            new
            {
                CarId = 4,
                MinTurningRadius = 4.3f,
                // FcrWltc
                // FcrWltcL
                // FcrWltcM
                // FcrWltcH
                // FcrWltcExh
                // FcrJc08
                MpcWltc = 259f,
                EcrWltc = 138f,
                EcrWltcL = 116f,
                EcrWltcM = 130f,
                EcrWltcH = 149f,
                // EcrWltcExh
                EcrJc08 = 135f,
                MpcJc08 = 274f,
            }
        );
        // Engine: Engine{}
        builder.OwnsOne(e => e.MotorX).HasData(
            new
            {
                CarId = 4,
                Code = "MCF5",
                Type = "交流同期電動機",
                Purpose = "動力後用",
                RatedOutput = 60f,
                MaxOutput = 113f,
                MaxOutputLowerRpm = 3497,
                MaxOutputUpperRpm = 10000,
                MaxTorque = 315f,
                MaxTorqueLowerRpm = 0,
                MaxTorqueUpperRpm = 2000,
            }
        );
        // MotorY: Motor{}
        builder.OwnsOne(e => e.Battery).HasData(
            new
            {
                CarId = 4,
                Type = "リチウムイオン電池",
                Quantity = 193,
                Voltage = 3.7f,
                Capacity = 50.0f,
            }
        );
        builder.OwnsOne(e => e.TireFront).HasData(
            new
            {
                CarId = 4,
                SectionWidth = 205,
                AspectRatio = 45,
                WheelDiameter = 17,
            }
        );
        builder.OwnsOne(e => e.TireRear).HasData(
            new
            {
                CarId = 4,
                SectionWidth = 225,
                AspectRatio = 45,
                WheelDiameter = 17,
            }
        );
        builder.OwnsOne(e => e.Transmission).HasData(
            new
            {
                CarId = 4,
                // 	Type
                // 	GearRatiosFront
                // 	RatioRear
                ReductionRatioFront = 9.545f,
            }
        );
    }

    private void ConfigureNote(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(new Car
        {
            Id = 5,
            MakerName = "日産",
            ModelName = "ノート",
            GradeName = "X FOUR",
            ModelCode = "6AA-SNE13",
            Price = 2445300,
            Url = "https://www3.nissan.co.jp/vehicles/new/note.html",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/0a/Nissan_Note_e-POWER_%28E13%29%2C_2021%2C_front-left.jpg",
            ModelChangeFull = "2020-11-24",
            ModelChangeLast = "2021-11-04",
            PowerTrain = PowerTrain.SerHV,
            DriveSystem = DriveSystem.AWD,
            Steering = "ラック&ピニオン式",
            SuspensionFront = "独立懸架ストラット式",
            SuspensionRear = "トーションビーム式",
            BrakeFront = "ベンチレーテッドディスク式",
            BrakeRear = "リーディングトレーリング式",
            FuelEfficiency = new string[] {
                "ハイブリッドシステム",
                "アイドリングストップ装置",
                "可変バルブタイミング",
                "ミラーサイクル",
                "電動パワーステアリング",
            }
        });
        builder.OwnsOne(e => e.Body).HasData(
            new
            {
                CarId = 5,
                Type = BodyType.HATCHBACK,
                Length = 4045,
                Width = 1695,
                Height = 1520,
                WheelBase = 2580,
                TreadFront = 1490,
                TreadRear = 1490,
                MinRoadClearance = 125,
                Weight = 1340,
                DoorNum = 4,
            }
        );
        builder.OwnsOne(e => e.Interior).HasData(
            new
            {
                CarId = 5,
                Length = 2030,
                Width = 1445,
                Height = 1240,
                // LuggageCap
                RidingCap = 5,
            }
        );
        builder.OwnsOne(e => e.Performance).HasData(
            new
            {
                CarId = 5,
                MinTurningRadius = 4.9f,
                FcrWltc = 23.8f,
                FcrWltcL = 23.1f,
                FcrWltcM = 25.8f,
                FcrWltcH = 22.9f,
                //FcrWltcExh
                FcrJc08 = 28.2f,
                //MpcWltc
                //EcrWltc
                //EcrWltcL
                //EcrWltcM
                //EcrWltcH
                //EcrWltcExh
                //EcrJc08
                //MpcJc08
            }
        );
        builder.OwnsOne(e => e.Engine).HasData(
            new
            {
                CarId = 5,
                Code = "HR12DE",
                Type = "DOHC水冷直列3気筒",
                CylinderNum = 3,
                CylinderLayout = CylinderLayout.I,
                ValveSystem = ValveSystem.DOHC,
                Displacement = 1.198f,
                Bore = 78.0f,
                Stroke = 83.6f,
                CompressionRatio = 12.0f,
                MaxOutput = 60f,
                MaxOutputLowerRpm = 6000,
                MaxOutputUpperRpm = 6000,
                MaxTorque = 103f,
                MaxTorqueLowerRpm = 4800,
                MaxTorqueUpperRpm = 4800,
                FuelSystem = "ニッサンEGI(ECCS)電子制御燃料噴射装置",
                FuelType = FuelType.REGULAR,
                FuelTankCap = 36,
            }
        );
        builder.OwnsOne(e => e.MotorX).HasData(
            new
            {
                CarId = 5,
                Code = "EM47",
                Type = "交流同期電動機",
                Purpose = "発電用",
                //RatedOutput
                MaxOutput = 85f,
                MaxOutputLowerRpm = 2900,
                MaxOutputUpperRpm = 10341,
                MaxTorque = 280f,
                MaxTorqueLowerRpm = 0,
                MaxTorqueUpperRpm = 2900,
            }
        );
        builder.OwnsOne(e => e.MotorY).HasData(
            new
            {
                CarId = 5,
                Code = "MM48",
                Type = "交流同期電動機",
                Purpose = "動力後用",
                // RatedOutput
                MaxOutput = 50f,
                MaxOutputLowerRpm = 4775,
                MaxOutputUpperRpm = 10024,
                MaxTorque = 100f,
                MaxTorqueLowerRpm = 0,
                MaxTorqueUpperRpm = 4775,
            }
        );
        builder.OwnsOne(e => e.Battery).HasData(
            new
            {
                CarId = 5,
                Type = "リチウムイオン電池",
                // Quantity
                // Voltage
                // Capacity
            }
        );
        builder.OwnsOne(e => e.TireFront).HasData(
            new
            {
                CarId = 5,
                SectionWidth = 185,
                AspectRatio = 60,
                WheelDiameter = 16,
            }
        );
        builder.OwnsOne(e => e.TireRear).HasData(
            new
            {
                CarId = 5,
                SectionWidth = 185,
                AspectRatio = 60,
                WheelDiameter = 16,
            }
        );
        builder.OwnsOne(e => e.Transmission).HasData(
            new
            {
                CarId = 5,
                // Type
                // GearRatiosFront
                // RatioRear
                ReductionRatioFront = 7.388f,
                ReductionRatioRear = 7.282f,
            }
        );
    }

    private void ConfigureThree(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(new Car
        {
            Id = 6,
            MakerName = "BMW",
            ModelName = "3シリーズツーリング",
            GradeName = "320d xDriveツーリング Standard",
            ModelCode = "3DA-6L20",
            Price = 6340000,
            Url = "https://www.bmw.co.jp/ja/all-models/3-series/touring/2019/bmw-3-series-touring-inspire.html",
            // ImageUrl
            ModelChangeFull = "2019-09-26",
            ModelChangeLast = "2019-09-26",
            PowerTrain = PowerTrain.ICE,
            DriveSystem = DriveSystem.AWD,
            Steering = "ラック&ピニオン式、単速感応式パワー・ステアリング",
            SuspensionFront = "ダブル・ジョイント・スプリング・ストラット式、コイルスプリング",
            SuspensionRear = "5リンク式、コイル・スプリング",
            BrakeFront = "ベンチレーテッドディスク",
            BrakeRear = "ベンチレーテッドディスク",
            FuelEfficiency = new string[] {
                "筒内直接噴射",
                "電子制御式燃料噴射",
                "高圧噴射(コモンレール・ダイレクト・インジェクション・システム)",
                "過給機(可変ジオメトリー・ターボチャージャー)",
                "充電制御(ブレーキ・エネルギー回生システム)",
                "アイドリング・ストップ装置(エンジン・オート・スタート/ストップ)",
                "電動パワーステアリング",
            }
        });
        builder.OwnsOne(e => e.Body).HasData(
            new
            {
                CarId = 6,
                Type = BodyType.STATION_WAGON,
                Length = 4715,
                Width = 1825,
                Height = 1475,
                WheelBase = 2850,
                TreadFront = 1575,
                TreadRear = 1590,
                MinRoadClearance = 135,
                Weight = 1730,
                DoorNum = 4,
            }
        );
        builder.OwnsOne(e => e.Interior).HasData(
            new
            {
                CarId = 6,
                // Length
                // Width
                // Height
                LuggageCap = 500,
                RidingCap = 5,
            }
        );
        builder.OwnsOne(e => e.Performance).HasData(
            new
            {
                CarId = 6,
                MinTurningRadius = 5.7f,
                FcrWltc = 15.6f,
                FcrWltcL = 12.6f,
                FcrWltcM = 14.9f,
                FcrWltcH = 18.0f,
                //FcrWltcExh
                FcrJc08 = 19.6f,
                //MpcWltc
                //EcrWltc
                //EcrWltcL
                //EcrWltcM
                //EcrWltcH
                //EcrWltcExh
                //EcrJc08
                //MpcJc08
            }
        );
        builder.OwnsOne(e => e.Engine).HasData(
            new
            {
                CarId = 6,
                Code = "B47D20B",
                Type = "直列4気筒DOHCディーゼル",
                CylinderNum = 4,
                CylinderLayout = CylinderLayout.I,
                ValveSystem = ValveSystem.DOHC,
                Displacement = 1.995f,
                // Bore
                // Stroke
                // CompRatio
                MaxOutput = 140f,
                MaxOutputLowerRpm = 4000,
                MaxOutputUpperRpm = 4000,
                MaxTorque = 400f,
                MaxTorqueLowerRpm = 1750,
                MaxTorqueUpperRpm = 2500,
                FuelSystem = "デジタル・ディーゼル・エレクトロニクス(DDE/電子燃料噴射装置)",
                FuelType = FuelType.DIESEL,
                FuelTankCap = 59,
            }
        );
        // MotorX: Motor{},
        // MotorY: Motor{},
        // Battery: Battery{},
        builder.OwnsOne(e => e.TireFront).HasData(
            new
            {
                CarId = 6,
                SectionWidth = 225,
                AspectRatio = 50,
                WheelDiameter = 17,
            }
        );
        builder.OwnsOne(e => e.TireRear).HasData(
            new
            {
                CarId = 6,
                SectionWidth = 225,
                AspectRatio = 50,
                WheelDiameter = 17,
            }
        );
        builder.OwnsOne(e => e.Transmission).HasData(
            new
            {
                CarId = 6,
                Type = TransmissionType.AT,
                GearRatiosFront = new float[]
                {
                    5.250f,
                    3.360f,
                    2.172f,
                    1.720f,
                    1.316f,
                    1.000f,
                    0.822f,
                    0.640f,
                    //Ratio9
                    //Ratio10
                },
                RatioRear = 3.712f,
                ReductionRatioFront = 2.813f,
                // ReductionRatioRear
            }
        );
    }
}
