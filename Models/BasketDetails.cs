using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.API.Models
{
    public class BasketDetails
    {
      
        public int BasketDetailsId { get; set; }

        public int BasketHeaderId { get; set; }
        [ForeignKey("BasketHeaderId")]
        public virtual BasketHeader BasketHeader { get; set; }

        public int WineId { get; set; }
        [ForeignKey("WineId")]

        public virtual Wine Wine { get; set; }

        public int Amount { get; set; }
    }
}