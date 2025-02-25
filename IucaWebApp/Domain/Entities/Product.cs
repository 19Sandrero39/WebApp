using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Имя не может превышать 255 символов")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Цена должна быть неотрицательной")]
        public float Price { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Название бренда не может превышать 100 символов")]
        public string Brand { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Количество на складе должно быть неотрицательным")]
        public int QuantityInStock { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Описание не может превышать 1000 символов")]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(255, ErrorMessage = "Изображение не должно превышать 255 символов")]
        public string Image { get; set; } = null!;

        public IList<BasketProduct> BasketProducts { get; private set; } = new List<BasketProduct>();
    }
}