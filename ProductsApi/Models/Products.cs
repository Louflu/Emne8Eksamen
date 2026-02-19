using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("brand")]
        public string Brand { get; set; } = string.Empty;
        [Column("price")]
        public decimal Price { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
    }
}
