using System;
using System.Collections.Generic;

public class Program
{
    // 1. Define what an Item is
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    // 2. Define the Player and their Inventory List
    public class Player
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Inventory = new List<Item>(); // Initializes the empty inventory
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n--- Your Inventory ---");
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Your pockets are empty.");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }
            }
            Console.WriteLine("----------------------\n");
        }
    }

    // 3. The Game Loop
    public static void Main()
    {
        Console.WriteLine("Enter your hero's name:");
        string playerName = Console.ReadLine();
        Player player = new Player(playerName);
		
		Console.WriteLine("You wake up on the ground next to a familiar building. What do you do?");   
		
        bool started = true;
        while (started)
        {
			Console.WriteLine("1. Look around | 2. Check Inventory | 3. Quit | 4. Use item (state its name)");
            string choice = Console.ReadLine();
			if (choice == "1")
            {
                Console.WriteLine("\nYou see a strange object.");
                Item sword = new Item("tool_1", "A tool of some kind.");
                player.Inventory.Add(sword); // Adds the item to the list
            }
            else if (choice == "2")
            {
                player.ShowInventory();
            }
            else if (choice == "3")
            {
                started = false;
                Console.WriteLine("Thanks for playing!");
            }
            else if (choice == "tool" && player.Inventory.Exists(item => item.Name == "tool_1"))
            {
                Console.WriteLine("You try to pick the buildings lock with the tool. Suprisingly, it opens. \nIt is dark and dank. What do you do?");
				 Console.WriteLine("1. Look around | 2. Check Inventory | 3. Quit | 4. Use item (state its name)");
            	 choice = Console.ReadLine();
				started = true;
				
				if (choice == "1")
				{
					Console.WriteLine("Its hard to make out, but theres some sort of drawing on the wall.");
					Console.WriteLine("You look behind it and find another tool. This time its clearly a screwdriver. There is also a toilet in the corner, oddly enough.");
					Item screw = new Item("tool_2", "\"It's not a screwdriver!\", it says on the back. You cant believe its not a screwdriver.");
					player.Inventory.Add(screw);
				}
					else if (choice == "screwdriver" && player.Inventory.Exists(item => item.Name == "screw"))
					{
						Console.WriteLine("You open a candy bar and eat it.");
						Console.WriteLine("The screwdriver? uh...you...unscrew the toilet seat and smash it on your head.\n\n The end.");
					}
					
				
					
            }
			else
			{
				Console.WriteLine("Invalid.");
			}
        }
    }
}
