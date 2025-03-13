
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

    public List<Item> Lootpool = new List<Item>
    {
        new Consumable ("Lesser Potion", 20),
        new Consumable ("Potion", 35),
        new Consumable ("Greater Potion", 50)
    };

    public void GetRandomItem(Hero player)
    {
        Random random = new Random();
        Item RandomLoot = Lootpool[random.Next(Lootpool.Count)];
        Console.WriteLine($"The Hero found {RandomLoot.name}");
        Console.WriteLine($"{RandomLoot.name} is being added to bag...");
        Console.ReadLine();
        player.backpack.Items.Add(RandomLoot);        
        if (player.backpack.Items.Count > 9)
        {
            bool bagLoop = true;
            while (bagLoop == true)
            {
            string bagString = "a";
            int bagInt = 20;
            while(!bagString.All(char.IsDigit) && bagInt > player.backpack.Items.Count || bagInt < 0)
            {
                Console.Clear();
                player.backpack.Display();
                Console.WriteLine($"The Hero is carrying too much, decide on what to drop");
                bagString = Console.ReadLine();
                int.TryParse(bagString,out bagInt);
            }
            player.backpack.Items.RemoveAt(bagInt-1);
            bagLoop = false;
        }
        }
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
