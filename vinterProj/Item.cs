using System;

namespace vinterProj;

public class Item
{
    public string name = "";





    public virtual void Use(Hero target)
    {
        Console.WriteLine($"This is a {name}, it doesnt do anything.");
        Console.ReadLine();
    }

}
