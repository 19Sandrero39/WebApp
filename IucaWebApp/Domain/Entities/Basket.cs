using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Basket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Статус не может превышать 50 символов")]
        public string Status { get; set; } = null!;

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Итоговая цена должна быть неотрицательной")]
        public float TotalPrice { get; set; }

        public IList<BasketProduct> BasketProducts { get; private set; } = new List<BasketProduct>();
    }
}