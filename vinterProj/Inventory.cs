using System;

namespace vinterProj;

public class Inventory
{
    public List<Item> Items = [];

    public void Display()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"{i+1} {Items[i].name}");
            
        }
    }
    

}
