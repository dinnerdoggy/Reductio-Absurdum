﻿using Reductio;

// Product types
ProductType apparel = new ProductType { Name = "Apparel", id = 1 };
ProductType potions = new ProductType { Name = "Potions", id = 2 };
ProductType enchanted = new ProductType { Name = "Enchanted Objects", id = 3 };
ProductType wands = new ProductType { Name = "Wands", id = 4 };

// Products
Product product1 = new Product("Orb", 10.00m, true, enchanted);
Product product2 = new Product("Fire Wand", 5.00m, false, wands);
Product product3 = new Product("Blue Robe", 40.00m, true, apparel);
Product product4 = new Product("Health Pot", 1.00m, false, potions);
Product product5 = new Product("Straw Mage Hat", 30.00m, true, apparel);

var products = new List<Product> { product1, product2, product3, product4, product5 };

bool exit = false;

while (!exit)
{
    // Display the menu
    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("========== Main Menu ==========");
        Console.WriteLine("a. Display Products");
        Console.WriteLine("b. Add a Product");
        Console.WriteLine("c. Delete a Product");
        Console.WriteLine("d. Update a Product's Details");
        Console.WriteLine("e. ...");
        Console.WriteLine("f. ...");
        Console.WriteLine("g. ...");
        Console.WriteLine("h. Exit");
        Console.WriteLine("===============================");
        Console.Write("Enter your choice (a-h): ");
    }

    DisplayMenu();

    // Read user input
    string choice = Console.ReadLine();

    // Handle user input with a switch statement
    switch (choice)
    {
        case "a":
            Console.Clear();
            Options.ViewProducts(products);
            break;

        case "b":
            Console.Clear();
            Options.AddProduct();
            break;

        case "c":
            Console.Clear();
            Options.DeleteProduct();
            break;

        case "d":
            Console.Clear();
            Options.UpdateDetails();
            break;

        case "e":
            Console.Clear();
            Console.WriteLine("Under construction...");
            break;

        case "f":
            Console.Clear();
            Console.WriteLine("Under construction...");
            break;

        case "g":
            Console.Clear();
            Console.WriteLine("Under construction...");
            break;

        case "h":
            Console.Clear();
            Console.WriteLine("So long my friend ♥");
            Console.ReadLine();
            Console.Clear();
            exit = true;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    // Pause before redisplaying the menu
    if (!exit)
    {
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}