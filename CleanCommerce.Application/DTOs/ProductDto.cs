namespace CleanCommerce.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
}