using Xunit;
using System.Reflection;
using task07;
using Microsoft.VisualBasic;
public class AttributeReflectionTests
{
    [Fact]
    public void Class_HasDisplayNameAttribute()
    {
        var type = typeof(SampleClass);
        var attribute = type.GetCustomAttribute<DisplayNameAttribute>();
        Assert.NotNull(attribute);
        Assert.Equal("Пример класса", attribute.DisplayName);
    }

    [Fact]
    public void Method_HasDisplayNameAttribute()
    {
        var method = typeof(SampleClass).GetMethod("TestMethod");
        var attribute = method.GetCustomAttribute<DisplayNameAttribute>();
        Assert.NotNull(attribute);
        Assert.Equal("Тестовый метод", attribute.DisplayName);
    }

    [Fact]
    public void Property_HasDisplayNameAttribute()
    {
        var prop = typeof(SampleClass).GetProperty("Number");
        var attribute = prop.GetCustomAttribute<DisplayNameAttribute>();
        Assert.NotNull(attribute);
        Assert.Equal("Числовое свойство", attribute.DisplayName);
    }

    [Fact]
    public void Class_HasVersionAttribute()
    {
        var type = typeof(SampleClass);
        var attribute = type.GetCustomAttribute<VersionAttribute>();
        Assert.NotNull(attribute);
        Assert.Equal(1, attribute.Major);
        Assert.Equal(0, attribute.Minor);
    }

    [Fact]
    public void PrintTypeInfo_PrintRightInfo()
    {
        var type = typeof(SampleClass);
        var output = new StringWriter();
        Console.SetOut(output);
        var expectedValue = "Display Name Class: Пример класса";
        ReflectionHelper.PrintTypeInfo(type);
        string output_string = output.ToString();
        Assert.Contains(expectedValue, output_string);
        Assert.Contains("Class version: 1.0", output_string);
        Assert.Contains("Числовое свойство - Number", output_string);
        Assert.Contains("Тестовый метод - TestMethod", output_string);
        
    }
}