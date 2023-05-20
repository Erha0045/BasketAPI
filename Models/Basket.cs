namespace Basket.API.Models
{
    public class Basket
    {
        public BasketHeader BasketHeader { get; set; }
        public IEnumerable<BasketDetails> BasketDetails { get; set; }
    }
}