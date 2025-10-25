using System.ComponentModel.DataAnnotations;

namespace BeatPass.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Festival Festival { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
