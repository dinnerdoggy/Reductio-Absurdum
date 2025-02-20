namespace Reductio;

public class Options
{
    public static void ViewProducts(List<Product> products, List<ProductType> producttypes)
    {
        Console.WriteLine("All products");
        Console.WriteLine("==================================\n");
        int listNumber = 0;
        foreach (Product product in products)
        {
            listNumber++;
            Console.WriteLine($"{listNumber}. \t{product.ProductName}");
            Console.WriteLine($" - - - - - Type: {product.ProductType.Name}");
            Console.WriteLine($" - - - - -Price: {product.Price}");
            string inStock = product.IsAvailable ? "Yes" : "No";
            Console.WriteLine($" - - -In Stock?: {inStock}");
            Console.WriteLine($" -Days on shelf: {(product.IsAvailable ? product.DaysOnShelf : "Out of stock")}\n");
        }
        Console.WriteLine("\n==================================");
    }

    public static void AddProduct(List<ProductType> productTypes, List<Product> products)
    {
        Console.Write("Enter your product's name: ");
        string name = Console.ReadLine();

        Console.Write("\nEnter your asking price: ");
        decimal price = int.Parse(Console.ReadLine());

        Console.WriteLine("\nWhat category does your product fall under?");
        int count = 0;
        foreach (var productType in productTypes)
        {
            count++;
            Console.WriteLine($"{count}. {productType.Name}");
        }

        int typeId = 0;
        int numberChoice = int.Parse(Console.ReadLine()) - 1;
        foreach (var productType in productTypes)
        {
            typeId++;
            if (typeId == numberChoice)
            {
                var type = productType;
                var newProduct = new Product(name, price, true, type, DateTime.Now, 0);
                products.Add(newProduct);
            }
        }

        ViewProducts(products, productTypes);
    }

    public static void DeleteProduct(List<Product> products, List<ProductType> productTypes)
    {
        Options.ViewProducts(products, productTypes);
        Console.Write("Enter the number of the product you would like to DELETE: ");
        var choice = int.Parse(Console.ReadLine()) - 1;
        var deletedProduct = products[choice].ProductName;
        products.RemoveAt(choice);
        Console.Clear();
        Options.ViewProducts(products, productTypes);
        Console.WriteLine($"{deletedProduct} removed from the store!");
    }

    public static void UpdateDetails(List<Product> products, List<ProductType> productTypes)
    {
        // Get users choice
        Console.Clear();
        Options.ViewProducts(products, productTypes);
        Console.Write("Enter the number of the product you would like to update: ");
        var choice = int.Parse(Console.ReadLine()) - 1;
        Console.Clear();

        // Isolate users choice and show details
        Console.WriteLine($"1. \t{products[choice].ProductName}");
        Console.WriteLine($"2. - - - - Type: {products[choice].ProductType.Name}");
        Console.WriteLine($"3. - - - -Price: {products[choice].Price}");
        string inStock = products[choice].IsAvailable ? "Yes" : "No";
        Console.WriteLine($"4. - -In Stock?: {inStock}\n");

        Console.WriteLine("Which attribute would you like to update (1-4)?");
        int updateChoice = int.Parse(Console.ReadLine());

        try
        {
            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("Enter a new product name:");
                    string newName = Console.ReadLine();
                    products[choice].ProductName = newName;
                    Options.ViewProducts(products, productTypes);
                    Console.WriteLine("Your product's name has been updated!");
                    break;
                case 2:
                    Console.WriteLine("Select the product type you wish to place this item under:");
                    var list = 0;
                    foreach (var productType in productTypes)
                    {
                        list++;
                        Console.WriteLine($"{list}. {productType.Name}");
                    }
                    var typeChoice = int.Parse(Console.ReadLine()) - 1;
                    products[choice].ProductType = productTypes[typeChoice];
                    Options.ViewProducts(products, productTypes);
                    Console.WriteLine("Your product's type has been updated!");
                    break;
                case 3:
                    Console.WriteLine("Enter a new price:");
                    var newPrice = decimal.Parse(Console.ReadLine());
                    products[choice].Price = newPrice;
                    Options.ViewProducts(products, productTypes);
                    Console.WriteLine("Your product's price has been updated!");
                    break;
                case 4:
                    Console.WriteLine("Update availability... Is this still available (y/n)?");
                    var newAvailable = Console.ReadLine().Trim().ToLower();
                    if (newAvailable == "y")
                    {
                        products[choice].IsAvailable = true;
                        Console.Clear();
                        Console.WriteLine($"{products[choice].ProductName}\nAvailable?: {(products[choice].IsAvailable ? "Yes" : "No")}\n\n You have updated your products Availability!");
                    }
                    if (newAvailable == "n")
                    {
                        products[choice].IsAvailable = false;
                        Console.Clear();
                        Console.WriteLine($"{products[choice].ProductName}\nAvailable?: {(products[choice].IsAvailable ? "Yes" : "No")}\n\n You have updated your products Availability!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter 'y' 'n'");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input, try again");
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public static void SearchByType(List<Product> products, List<ProductType> productTypes)
    {
        var list = 0;
        foreach (ProductType productType in productTypes)
        {
            list++;
            Console.WriteLine($"{list}. {productType.Name}");
        }

        // Choosing product type to search
        Console.WriteLine("\nEnter the number for the category you would like to see: \n");
        int choice = int.Parse(Console.ReadLine()) - 1;
        Console.Clear();

        foreach (Product product in products)
        {
            if (product.ProductType == productTypes[choice])
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }

    public static void ShowAvailable(List<Product> products)
    {
        List<Product> unsoldProducts = products.Where(p => p.IsAvailable).ToList();
        foreach (Product product in unsoldProducts)
        {
            Console.WriteLine(product.ProductName);
        }
    }
}