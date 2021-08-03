using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.ProductService.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
