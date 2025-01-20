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
            Console.WriteLine($"  - - - - Type: {product.ProductType.Name}");
            Console.WriteLine($"  - - - -Price: {product.Price}");
            string inStock = product.IsAvailable ? "Yes" : "No";
            Console.WriteLine($"  - -In Stock?: {inStock}\n");
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
                var newProduct = new Product(name, price, true, type);
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

    public static void UpdateDetails()
    {
        Console.WriteLine("You chose to update a product's details");
    }
}