using task05;
using Xunit;
using Moq;
using Xunit.Sdk;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
namespace task05tests;



public class TestClass
{
    public int PublicField;
    private string _privateField;
    public int Property { get; set; }

    public void Method() { }
}

[Serializable]
public class AttributedClass { }

public class ClassAnalyzerTests
{
    [Fact]
    public void GetPublicMethods_ReturnsCorrectMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methods = analyzer.GetPublicMethods();

        Assert.Contains("Method", methods);
    }

    [Fact]
    public void GetAllFields_IncludesPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var fields = analyzer.GetAllFields();

        Assert.Contains("_privateField", fields);
    }
    [Fact]
    public void GetMethodParams_ReturnCorrectMethodParams()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methodParams = analyzer.GetMethodParams("Method");
        Assert.Contains("Void", methodParams);
    }
    [Fact]
    public void GetProperties_ReturnCorrectProperties()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methodProperties = analyzer.GetProperties();
        Assert.Contains("Property", methodProperties);
    }
    [Fact]
    public void HasAttribute_ReturnTrue()
    {
        var analyzer = new ClassAnalyzer(typeof(AttributedClass));
        var IshasAttribute = analyzer.HasAttribute<SerializableAttribute>();
        Assert.True(IshasAttribute);
    }
}