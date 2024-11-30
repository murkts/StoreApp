namespace StoreApp.Data.Entities;

public class StoreProduct
{
    public Guid StoreId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}