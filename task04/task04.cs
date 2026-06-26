using System;
namespace task04;

public interface ISpaceship
{
    void MoveForward();      
    void Rotate(int angle);  
    void Fire();           
    int Speed { get; } 
    int FirePower { get; }  
}

public class Cruiser : ISpaceship
{
    
    public int Speed {get;} = 50;
    public int FirePower{get;} = 100;
    public int Angle {get; private set;} = 0;
    public int Ammo{get; private set;} = 50;
    public int DistanceCovered {get; private set;} = 0;
    public void MoveForward()
    {
        DistanceCovered += Speed;
    }
    public void Rotate(int angle)
    {
        Angle += angle;
    }
    public void Fire()
    {
        if (Ammo > 0)
        {
            Ammo--;
        }
    }
}

public class Fighter : ISpaceship
{
    
    public int Speed {get; set;} = 100;
    public int FirePower{get; set;} = 50;
    public int Angle {get; private set;} = 0;
    public int Ammo{get; private set;} = 25;
    public int DistanceCovered {get; private set;} = 0;
    public void MoveForward()
    {
        DistanceCovered += Speed;
    }
    public void Rotate(int angle)
    {
        Angle += angle;
    }
    public void Fire()
    {
        if (Ammo > 0)
        {
            Ammo--;
        }
        
    }
}