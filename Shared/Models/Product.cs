using System.ComponentModel.DataAnnotations;

namespace HogeBlazor.Shared.Models;
public class Product
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name is required field")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Supplier is required field")]
    public string Supplier { get; set; }
    [Range(1, double.MaxValue, ErrorMessage = "Value ofr the Price can't be lower than 1")]
    public double Price { get; set; }
    public string ImageUrl { get; set; }
}