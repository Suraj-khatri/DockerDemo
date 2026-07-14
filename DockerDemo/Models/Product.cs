namespace DockerDemo.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ProductDetails> ProductDetails { get; set; } = new List<ProductDetails>();

    }
}
