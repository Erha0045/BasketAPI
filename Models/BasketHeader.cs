using System.ComponentModel.DataAnnotations;

namespace Basket.API.Models
{
    public class BasketHeader
    {
        [Key]
        public int BasketHeaderId { get; set; }

        public string UserId { get; set; }

    }
}