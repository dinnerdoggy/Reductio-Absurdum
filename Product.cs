namespace Reductio;

public class Product
{
    // Public properties with proper naming conventions
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    ProductType ProductType { get; set; }

    // Constructor to initialize the Product object
    public Product(string productName, decimal price, bool isAvailable, ProductType productType)
    {
        ProductName = productName;
        Price = price;
        IsAvailable = isAvailable;
        ProductType = productType;
    }
}