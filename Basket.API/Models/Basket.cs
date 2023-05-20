namespace Basket.API.Models
{
    //remove this comment
    public class Basket
    {
        public BasketHeader BasketHeader { get; set; }
        public IEnumerable<BasketDetails> BasketDetails { get; set; }
    }
}