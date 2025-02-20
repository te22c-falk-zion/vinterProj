using System;

namespace vinterProj;

public class Item
{
    public string name = "";

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

    public virtual void Use(Hero target)
    {
        Console.WriteLine($"This is a {name}, it doesnt do anything.");
        Console.ReadLine();
    }

}
