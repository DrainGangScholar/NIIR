using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("BasketItems")]
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Basket Basket { get; set; }
    }
}