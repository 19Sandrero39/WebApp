using Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class BasketProduct
{
    public int Id { get; set; }

    [Required]
    public int BasketId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Количество должно быть неотрицательным")]
    public int Quantity { get; set; }

    public Basket Basket { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
