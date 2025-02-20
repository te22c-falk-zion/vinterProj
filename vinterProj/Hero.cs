
using System;

namespace vinterProj;

public class Hero
{
    public string name;
    public int health;
    public int damage;
    public Inventory backpack;
    public int level;
    public int experience;
    public int maxExperience;

    public void GainXp(Hero player)
    {
        experience += Random.Shared.Next(maxExperience/4, maxExperience/2);
        Console.WriteLine($"The Hero gained {experience} XP");
        if (experience >= maxExperience)
        {
            experience -= maxExperience;
            player.LevelUp();
        }
    }

    public void LevelUp()
    {
        Console.WriteLine("The hero levels up and his stands is increased!");        
        Console.WriteLine($"Level:{level}-->{level += 1}");
        Console.WriteLine($"Healht:{health}-->{health += 20}");
        Console.WriteLine($"Req Xp:{maxExperience}-->{maxExperience += 50}");
        Console.ReadLine();
    }
    public void Attack(Demon target)
    {
        target.health -= Random.Shared.Next(damage);
        Console.WriteLine($"The Hero slashes at the demon and deals {damage} damage");
        Console.ReadLine();
    }


    public Hero()
    {
        name = "";
        health = 100;
        damage = 20;
        
        level = 1;
        experience = 0;
        maxExperience = 100;

        backpack = new();

        Weapon hs = new() {name ="Hero's Sword"};

        backpack.Items.Add(hs);
    }
}
