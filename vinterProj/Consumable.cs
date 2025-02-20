using System;

namespace vinterProj;

public class Consumable : Item
{
    public int healing {get; set;}
    int usesMax = 1;
    int usesCurrent = 0;
    
    public Consumable(string name, int healing)
    {
        
    }
    public override void Use(Hero target)
    {
        if (usesCurrent <= usesMax)
        {
            target.health += healing;
            usesCurrent++;
            Console.WriteLine($"The hero used {name}");
            Console.ReadLine();
            Console.Clear();
        }
    }



}
