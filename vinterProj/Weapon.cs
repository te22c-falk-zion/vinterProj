using System;

namespace vinterProj;

public class Weapon : Item
{
    public virtual void Use(Hero target)
    {
        Console.WriteLine($"{name}:\nA sword made to fell the demon king. It grows stronger with The Hero's strenght.");
        // Console.WriteLine($"Currently deals on average {hero.damage}");
    }

}
