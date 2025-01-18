namespace Reductio;

public class Options
{
    public static void ViewProducts(List<Product> products)
    {
        foreach (Product product in products)
        {
            Console.WriteLine(product.ProductName);
        }
    }

    public static void AddProduct()
    {
        Console.WriteLine("You chose to add a product.");
    }

    public static void DeleteProduct()
    {
        Console.WriteLine("You chose to delete a product");
    }

    public static void UpdateDetails()
    {
        Console.WriteLine("You chose to update a product's details");
    }
}