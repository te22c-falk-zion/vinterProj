using System;
using System.Xml;

namespace vinterProj;

public class Stage
{
    public bool fightStage;
    public int currentStage;

    public void CreateStage()
    {
        currentStage++;
        if (Random.Shared.Next(1,3) == 1) {fightStage = true;}
        else {fightStage = false;}

        if (!fightStage)
        {
            Console.WriteLine($"Stage {currentStage}");
            Console.WriteLine("The Hero enters a land worthy of exploration and loots it.");
            Console.ReadLine();
            
        }
        if (fightStage)
        {
            Console.WriteLine($"Stage {currentStage}");
            Console.WriteLine("The Hero encounters a firece enemy.");
            Console.ReadLine();
        }
    }

    public void initCombat(Hero player, Demon enemy)
    {
        bool combatLoop = true;
        while (combatLoop == true)
        {
        string menuString = "a";
        int menuInt = 4;
        while(!menuString.All(char.IsDigit) && menuInt >= 4 || menuInt <= 0)
        {
            Console.WriteLine("What does the hero do?");
            Console.WriteLine("1. Fight\n2. Bag\n3. Retreat(Exit)");
            menuString = Console.ReadLine();
            int.TryParse(menuString,out menuInt);
        }
        if (menuInt == 1)
        {
            player.Attack(enemy);
            enemy.demonAttack(player);
        }
        if (menuInt == 2)
        {
            useBag(player);
        }
        if (menuInt == 3)
        {
            if (Random.Shared.Next(1,3) == 1)
            {
                Console.WriteLine("You succesfully escaped");
                combatLoop = false;
            }
        }
        if (enemy.health <= 0)
        {
            Console.WriteLine($"The demon is felled by the hero");
            Console.ReadLine();
            player.GainXp(player);
            Console.ReadLine();
            combatLoop = false;
        }
        if (player.health <= 0)
        {
            Console.WriteLine($"The hero has fallen.");
            Console.ReadLine();
            Console.ReadLine();
            combatLoop = false;
        }
        }
    }

    public void ExploreStage(Hero player)
    {
        string[] maps = { "Forest", "Desert", "Tundra", "Dungeon" };
        string mapString = maps[Random.Shared.Next(maps.Length)];
        string[] situations = {
            "The Hero trips over something, he flips his body over mid air landing perfectly on his feet. He turns around to find a chest poking through the ground and opens it.", 
            "The Hero comes across a corpse. It's rotten beyond recognition, the only things left of them is what's on them. Better you having it than them.",
            "The Hero finds a secret compartment and walks inside. The walls are covered in moss and the air is stale. Whilst there he picks up a useful item.",
            "The Hero just picked this shit up."
            };
        string situString = maps[Random.Shared.Next(situations.Length)];


        Console.WriteLine($"The Hero stumbles on a {mapString}");
        Console.WriteLine($"{situString}");
        
    }

    public void useBag(Hero player)
    {
        bool bagLoop = true;
        while (bagLoop == true)
        {
        string bagString = "a";
        int bagInt = 20;
        while(!bagString.All(char.IsDigit) && bagInt >= player.backpack.Items.Count || bagInt < 0)
        {
            Console.Clear();
            player.backpack.Display();
            Console.WriteLine($"Select what item to use. Use 0 to leave");
            bagString = Console.ReadLine();
            int.TryParse(bagString,out bagInt);
        }
        player.backpack.Items[bagInt-1].Use(player);
        if (bagInt == 0)
        {
            Console.WriteLine("Quitting bag...");
            bagLoop = false;
        }
        bagLoop = false;
        }
        

    }
}
