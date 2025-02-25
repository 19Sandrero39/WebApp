namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public string Brand { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
