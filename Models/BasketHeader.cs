using System.ComponentModel.DataAnnotations;

namespace BasketAPI.Models
{
    public class BasketHeader
    {
        [Key]
        public int BasketHeaderId { get; set; }

        public string UserId { get; set; }

    }
}