namespace StoreApp.Data.Entities;

public class Store
{
    public Guid StoreId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}