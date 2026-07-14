using System.ComponentModel.DataAnnotations.Schema;

namespace DockerDemo.Models
{
    public class ProductDetails
    {
        public int ProductDetailId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
