using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Basket
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Количество должно быть неотрицательным")]
    public int Quantity { get; set; }

    public Product Product { get; set; } = null!;
}
