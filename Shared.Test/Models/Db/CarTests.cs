using System;
using System.Collections.Generic;
using HogeBlazor.Shared.Models.Db;
using Xunit;
using System.Text.Json;

namespace HogeBlazor.Shared.Test.Models;

// // ASP.NET5 MVC6 でのModelStateの単体テスト
// // https://blog.beachside.dev/entry/2016/02/02/190000
public class CarTests
{
    [Fact]
    public void Serialize()
    {
        var original = new Car
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
            },
            Body = new Body
            {
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
            },
            // MotorX: Motor{},
            // MotorY: Motor{},
            // Battery: Battery{},
            Interior = new Interior
            {
                Length = 1890,
                Width = 1540,
                Height = 1265,
                // LuggageCap
                RidingCap = 5,
            },
            Performance = new Performance
            {
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
            },
            Engine = new Engine
            {
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
            },
            TireFront = new Tire
            {
                SectionWidth = 225,
                AspectRatio = 55,
                WheelDiameter = 19,
            },
            TireRear = new Tire
            {
                SectionWidth = 225,
                AspectRatio = 55,
                WheelDiameter = 19,
            },
            Transmission = new Transmission
            {
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
        };
        var json = JsonSerializer.Serialize<Car>(original);
        var deserialized = JsonSerializer.Deserialize<Car>(json);
        Assert.NotNull(deserialized);
        if (deserialized == null) return;
        Assert.Equal(original.MakerName, deserialized.MakerName);
        Assert.Equal(original.DeletedAt, deserialized.DeletedAt);
        Assert.Equal(original.ModelChangeFull, deserialized.ModelChangeFull);
        Assert.Equal(original.Body.Length, deserialized.Body.Length);
        Assert.Equal(original.Interior.Length, deserialized.Interior.Length);
        Assert.Equal(original.Performance.MinTurningRadius, deserialized.Performance.MinTurningRadius);
        Assert.Equal(original.Engine.Code, deserialized.Engine.Code);
    }

    //     #region コンストラクタに対するテスト
    //     /// <summary>
    //     /// コンストラクタで指定できるプロパティ値の確認
    //     /// </summary>
    //     [Fact]
    //     public void ConstructorSetPropertyValue()
    //     {
    //         var user = new User() { Id = 1, Name = "ほげ 太郎", Email = "hoge@example.com", PlainPassword = "password", Role = User.RoleType.Admin };
    //         Assert.Equal(1, user.Id);
    //         Assert.Equal("ほげ 太郎", user.Name);
    //         Assert.Equal("hoge@example.com", user.Email);
    //         Assert.Equal("password", user.PlainPassword);
    //         Assert.NotEqual("password", user.HashedPassword);
    //         Assert.Equal(User.RoleType.Admin, user.Role);
    //         Assert.Equal(new DateTime(), user.CreatedAt);
    //         Assert.Equal(new DateTime(), user.UpdatedAt);
    //         Assert.False(user.IsDel);
    //     }

    //     [Fact]
    //     public void ConstructorCreateInstanceSuccessfully()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ太郎", Email = "hoge@example.com", PlainPassword = "password", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.True(validationResult);
    //     }
    //     #endregion

    //     #region Nameプロパティに対するテスト
    //     [Fact]
    //     public void ValidateNameRequired()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "", Email = "hoge@example.com", PlainPassword = "password", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.False(validationResult);
    //         Assert.Contains(result, r => r.MemberNames.Contains("Name"));
    //     }
    //     [Fact]
    //     public void ValidateNameMaxLength()
    //     {
    //         // Arrange
    //         var user = new User() { Name = new string('あ', 100), Email = "hoge@example.com", PlainPassword = "password", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.True(validationResult);
    //     }
    //     [Fact]
    //     public void ValidateNameOverMaxLength()
    //     {
    //         // Arrange
    //         var user = new User() { Name = new string('あ', 101), Email = "hoge@example.com", PlainPassword = "password", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.False(validationResult);
    //         Assert.Contains(result, r => r.MemberNames.Contains("Name"));
    //     }
    //     #endregion

    //     #region Emailプロパティに対するテスト
    //     [Fact]
    //     public void ValidateEmailRequired()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = "", PlainPassword = "password", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.False(validationResult);
    //         Assert.Contains(result, r => r.MemberNames.Contains("Email"));
    //     }
    //     [Fact]
    //     public void ValidateEmailMaxLength()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = (new string('a', 88)) + "@example.com", PlainPassword = "password", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.True(validationResult);
    //     }
    //     [Fact]
    //     public void ValidateEmailOverMaxLength()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = (new string('a', 89)) + "@example.com", PlainPassword = "password", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.False(validationResult);
    //         Assert.Contains(result, r => r.MemberNames.Contains("Email"));
    //     }
    //     [Fact]
    //     public void ValidateEmailFormat()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = "invalid format", PlainPassword = "password", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.False(validationResult);
    //         Assert.Contains(result, r => r.MemberNames.Contains("Email"));
    //     }
    //     #endregion

    //     #region PlainPasswordプロパティに対するテスト
    //     [Fact]
    //     public void ValidatePlainPasswordRequired()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = "admin@example.com", PlainPassword = "", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.False(validationResult);
    //         Assert.Contains(result, r => r.MemberNames.Contains("PlainPassword"));
    //     }
    //     [Fact]
    //     public void ValidatePlainPasswordMaxLength()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = "admin@example.com", PlainPassword = new string('a', 100), Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.True(validationResult);
    //     }
    //     [Fact]
    //     public void ValidatePlainPasswordOverMaxLength()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = "admin@example.com", PlainPassword = new string('a', 101), Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.False(validationResult);
    //         Assert.Contains(result, r => r.MemberNames.Contains("PlainPassword"));
    //     }
    //     [Fact]
    //     public void ValidatePlainPasswordMinLength()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = "admin@example.com", PlainPassword = "12345678", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.True(validationResult);
    //     }
    //     [Fact]
    //     public void ValidatePlainPasswordUnderMinLength()
    //     {
    //         // Arrange
    //         var user = new User() { Name = "ほげ 太郎", Email = "admin@example.com", PlainPassword = "1234567", Role = User.RoleType.Admin };
    //         var context = new ValidationContext(user, null, null);
    //         var result = new List<ValidationResult>();
    //         // Act
    //         var validationResult = Validator.TryValidateObject(user, context, result, true);
    //         // Assert
    //         Assert.False(validationResult);
    //         Assert.Contains(result, r => r.MemberNames.Contains("PlainPassword"));
    //     }
    //     #endregion
}