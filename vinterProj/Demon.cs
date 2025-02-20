using System;

namespace vinterProj;

public class Demon
{
    List<string> names = [];
    public string name;
    public int health = 20;
    public int damage;
    public int level;

    public void demonAttack(Hero target)
    {
        
        target.health  -= Random.Shared.Next(damage);
        Console.WriteLine($"The demon attacks and deals {damage} dmg to the hero");
        Console.ReadLine();
    }

}
