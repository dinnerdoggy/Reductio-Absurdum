namespace Reductio;

public class Product
{
    // Public properties with proper naming conventions
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public ProductType ProductType { get; set; }
    public DateTime DateStocked { get; set; }
    public int DaysOnShelf
    {
        get
        {
            TimeSpan timeOnShelf = DateTime.Now - DateStocked;
            return timeOnShelf.Days;
        }
    }

    // Constructor to initialize the Product object
    public Product(string productName, decimal price, bool isAvailable, ProductType productType, DateTime dateStocked, int daysOnShelf)
    {
        ProductName = productName;
        Price = price;
        IsAvailable = isAvailable;
        ProductType = productType;
        DateStocked = dateStocked;
        // DaysOnShelf = daysOnShelf; -> error (read only)
    }
}