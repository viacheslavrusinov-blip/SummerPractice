namespace task04tests;

using task04;
using Xunit;
using Moq;

public class SpaceshipTests
{
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        ISpaceship cruiser = new Cruiser();
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
    }

    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.Speed > cruiser.Speed);
    }

    [Fact]
    public void Fighter_ShouldHaveCorrectStats()
    {
        ISpaceship fighter = new Fighter();
        Assert.Equal(100, fighter.Speed);
        Assert.Equal(50, fighter.FirePower);
    }

    [Fact]
    public void Cruiser_ShouldHaveMoreFirePowerThanFighter()
    {
        var cruiser = new Cruiser();
        var fighter = new Fighter();
        Assert.True(cruiser.FirePower > fighter.FirePower);
    }

    [Fact]
    public void Cruiser_MoveForward_ShouldIncreaseDistance()
    {
        var cruiser = new Cruiser();
        int expectedDistance = cruiser.Speed; 
        cruiser.MoveForward();
        Assert.Equal(expectedDistance, cruiser.DistanceCovered);
    }

    [Fact]
    public void Cruiser_Rotate_ShouldChangeAngleCorrectly()
    {
        var cruiser = new Cruiser();
        int rotateAngle = 90;
        cruiser.Rotate(rotateAngle);
        Assert.Equal(rotateAngle, cruiser.Angle);
    }

    [Fact]
    public void Cruiser_Fire_ShouldDecreaseAmmo()
    {
        var cruiser = new Cruiser();
        int expectedAmmo = cruiser.Ammo - 1;
        cruiser.Fire();
        Assert.Equal(expectedAmmo, cruiser.Ammo);
    }

    [Fact]
    public void Fighter_MoveForward_ShouldIncreaseDistance()
    {
        var fighter = new Fighter();
        int expectedDistance = fighter.Speed; 
        fighter.MoveForward();
        Assert.Equal(expectedDistance, fighter.DistanceCovered);
    }

    [Fact]
    public void Fighter_Rotate_ShouldChangeAngleCorrectly()
    {
        var fighter = new Fighter();
        int rotateAngle = 90; 
        fighter.Rotate(rotateAngle);
        Assert.Equal(rotateAngle, fighter.Angle);
    }

    [Fact]
    public void Fighter_Fire_ShouldDecreaseAmmo()
    {
        var fighter = new Fighter();
        int expectedAmmo = fighter.Ammo - 1;
        fighter.Fire();
        Assert.Equal(expectedAmmo, fighter.Ammo);
    }
}