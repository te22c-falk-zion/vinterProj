using vinterProj;
bool mainGame = true;
Hero hero = new();
Stage stage = new();

Console.WriteLine("The Hero begins his journey to rid the world of demons.");


while (mainGame == true)
{
    Console.WriteLine($"Stage: {stage.currentStage}");
    Console.WriteLine("What does the hero wish to do?");
    string menuString = "a";
    int menuInt = 4;
    while(!menuString.All(char.IsDigit) && menuInt >= 4 || menuInt <= 0)
    {
        Console.WriteLine("Type the number corresponidng to your choice.");
        Console.WriteLine("1. Explore\n2. Bag\n3. Retreat(Exit)");
        menuString = Console.ReadLine();
        Console.Clear();
        int.TryParse(menuString,out menuInt);
    }
    if (menuInt == 1)
    {
    stage.CreateStage(hero);
    if(stage.fightStage == true) 
    {
        Demon demon = new();
        stage.initCombat(hero, demon);
    }
    }
    if (menuInt == 2)
    {
        hero.backpack.Display();
    }
    if (menuInt == 3)
    {
        mainGame = false;
    }

}

