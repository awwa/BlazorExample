using System;
using Xunit;
using HogeBlazor.Shared.Models.Dto;

namespace HogeBlazor.Shared.Test.Models.Dto;

public class CarDtoTests
{
    /// <summary>
    /// Getのテスト
    /// </summary>
    [Fact]
    public void GetValidLevel1()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            MakerName = "マツダ"
        };
        // Act
        object? actual = dto.Get("MakerName");
        // Assert
        Assert.Equal("マツダ", actual as string);
    }

    [Fact]
    public void GetValidLevel2()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            ModelChange = new ModelChange { Full = "2019-02-03" },
        };
        // Act
        object? actual = dto.Get("ModelChange_Full");
        // Assert
        Assert.Equal("2019-02-03", actual as string);
    }

    [Fact]
    public void GetValidLevel3()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            Engine = new Engine { MaxOutputRpm = new MaxOutputRpm { Lower = 6000 } },
        };
        // Act
        object? actual = dto.Get("Engine_MaxOutputRpm_Lower");
        // Assert
        Assert.Equal(6000, dto.Engine.MaxOutputRpm.Lower);
    }

    [Fact]
    public void GetValidFloat()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            Ecr = new Ecr { Wltc = 13.4f },
        };
        // Act
        object? actual = dto.Get("Ecr_Wltc");
        // Assert
        Assert.Equal(13.4f, dto.Ecr.Wltc);
    }

    [Fact]
    public void GetValidNumberSet()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            Transmission = new Transmission { GearRatio = new GearRatio { Front = new[] { 12.3f, 23.4f } } },
        };
        // Act
        object? actual = dto.Get("Transmission_GearRatio_Front");
        // Assert
        Assert.Equal(new[] { 12.3f, 23.4f }, dto.Transmission.GearRatio.Front);
    }

    [Fact]
    public void GetValidStringSet()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            FuelEfficiency = new[] { "テスト1", "テスト2" },
        };
        // Act
        object? actual = dto.Get("FuelEfficiency");
        // Assert
        Assert.Equal(new[] { "テスト1", "テスト2" }, dto.FuelEfficiency);
    }

    [Fact]
    public void GetInvalidLevel1()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            MakerName = "マツダ"
        };
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() => dto.Get("Invalid"));
        Assert.Equal($"Invalid property name specified: 'Invalid'", actual.Message);
    }

    [Fact]
    public void GetInvalidLevel2()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            ModelChange = new ModelChange { Full = "2019-02-03" },
        };
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() => dto.Get("ModelChange_Invalid"));
        Assert.Equal("Invalid property name specified: 'Invalid'", actual.Message);
    }

    [Fact]
    public void GetInvalidLevel3()
    {
        // Arrange
        var dto = new CarDto("car_1")
        {
            Engine = new Engine { MaxOutputRpm = new MaxOutputRpm { Lower = 6000 } },
        };
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() => dto.Get("Engine_MaxOutputRpm_Invalid"));
        Assert.Equal("Invalid property name specified: 'Invalid'", actual.Message);
    }

    /// <summary>
    /// Setのテスト
    /// </summary>
    [Fact]
    public void SetValidLevel1()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        dto.Set("MakerName", "マツダ");
        // Assert
        Assert.Equal("マツダ", dto.MakerName);
    }

    [Fact]
    public void SetValidLevel2()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        dto.Set("ModelChange_Full", "2019-02-03");
        // Assert
        Assert.Equal("2019-02-03", dto.ModelChange.Full);
    }

    [Fact]
    public void SetValidLevel3()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        dto.Set("Engine_MaxOutputRpm_Lower", 6000);
        // Assert
        Assert.Equal(6000, dto.Engine.MaxOutputRpm.Lower);
    }

    [Fact]
    public void SetValidFloat()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        dto.Set("Ecr_Wltc", 13.4f);
        // Assert
        Assert.Equal(13.4f, dto.Ecr.Wltc);
    }

    [Fact]
    public void SetValidNumberSet()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        dto.Set("Transmission_GearRatio_Front", new[] { 12.3f, 23.4f });
        // Assert
        Assert.Equal(new[] { 12.3f, 23.4f }, dto.Transmission.GearRatio.Front);
    }

    [Fact]
    public void SetValidStringSet()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        dto.Set("FuelEfficiency", new[] { "テスト1", "テスト2" });
        // Assert
        Assert.Equal(new[] { "テスト1", "テスト2" }, dto.FuelEfficiency);
    }

    [Fact]
    public void SetInvalidLevel1()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() => dto.Set("Invalid", "マツダ"));
        Assert.Equal("Invalid property name specified: 'Invalid'", actual.Message);
    }

    [Fact]
    public void SetInvalidLevel2()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() => dto.Set("ModelChange_Invalid", "2019-02-03"));
        Assert.Equal("Invalid property name specified: 'Invalid'", actual.Message);
    }

    [Fact]
    public void SetInvalidLevel3()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        var actual = Assert.Throws<ArgumentException>(() => dto.Set("Engine_MaxOutputRpm_Invalid", 6000));
        // Assert
        Assert.Equal("Invalid property name specified: 'Invalid'", actual.Message);
    }

    [Fact]
    public void SetInvalidTypeString()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() => dto.Set("Ecr_Wltc", "stringvalue"));
        Assert.Equal("Object of type 'System.String' cannot be converted to type 'System.Nullable`1[System.Single]'.", actual.Message);
    }

    [Fact]
    public void SetInvalidTypeFloat()
    {
        // Arrange
        var dto = new CarDto("car_1");
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() => dto.Set("Transmission_GearRatio_Front", 13.4f));
        Assert.Equal("Object of type 'System.Single' cannot be converted to type 'System.Single[]'.", actual.Message);
    }
}