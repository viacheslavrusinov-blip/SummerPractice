using System;
using System.Reflection;
using Microsoft.VisualBasic;
namespace task07;
[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class DisplayNameAttribute : System.Attribute
{
    public string DisplayName;
    public DisplayNameAttribute(string DisplayName)
    {
        this.DisplayName = DisplayName;
    }
    
    
    
}

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class  VersionAttribute : System.Attribute
{
    public VersionAttribute(int Major, int Minor)
    {
        this.Major = Major;
        this.Minor = Minor;
    }
    public int Major;
    public int Minor;

}
[Version(1, 0)]
[DisplayName("Пример класса")]
public class SampleClass
{   [DisplayName("Тестовый метод")]
    public void TestMethod()
    {
        
    }
    [DisplayName("Числовое свойство")]
    public int Number {get; set;}

}

public static class ReflectionHelper
{
    public static void PrintTypeInfo(Type _type)
    {
        if (_type == null)
        {
            return;
        }
        var classDisplay = _type.GetCustomAttribute<DisplayNameAttribute>();
        if (classDisplay != null)
        {
            Console.WriteLine($"Display Name Class: {classDisplay.DisplayName}");
        }
        var classVersion = _type.GetCustomAttribute<VersionAttribute>();
        if (classVersion != null)
        {
            Console.WriteLine($"Class version: {$"{classVersion.Major}.{classVersion.Minor}"}");
        }

        var properties = _type.GetProperties();
        if (properties != null)
        {
            foreach (var prop in properties)
            {
                var attribute = prop.GetCustomAttribute<DisplayNameAttribute>();
                if (attribute != null)
                {
                    Console.Write($"{attribute.DisplayName} - {prop.Name}");
                }
            }
        }

        var methods = _type.GetMethods();
        if (methods != null)
        {
            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<DisplayNameAttribute>();
                if (attribute != null)
                {
                    Console.Write($"{attribute.DisplayName} - {method.Name}");
                }
            }
        }
    }
}

