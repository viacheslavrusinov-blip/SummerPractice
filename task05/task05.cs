using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
namespace task05;
public class ClassAnalyzer
{
    private Type _type;

    public ClassAnalyzer(Type type)
    {
        _type = type;

    }
    public IEnumerable<string> GetPublicMethods()
    {
        var listPublicMethods = _type.GetMethods();
        return from method in listPublicMethods 
        select method.Name;

    }
    public IEnumerable<string> GetMethodParams(string methodname)
    {

        var method = _type.GetMethod(methodname);
        if (method!= null){
            var listMethodParams = from parametrs in method.GetParameters()
            select parametrs.Name;
            string[] TypeReturn = new string[] {method.ReturnType.Name};
            return TypeReturn.Concat(listMethodParams);
        }
        else
        {
            return [];
        }
    }
    public IEnumerable<string> GetAllFields()
    {
        var fields = _type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        return from field in fields 
        select field.Name;
    }
    public IEnumerable<string> GetProperties()
    {
        var properties = _type.GetProperties();
        return from property in properties
           select property.Name;
    }
    public bool HasAttribute<T>() where T : Attribute
    {
        return _type.IsDefined(typeof(T), false);
    }
}