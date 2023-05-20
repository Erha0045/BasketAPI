namespace BasketAPI.Models.Dto
{
    public class BasketDto
    {
        public BasketHeaderDto BasketHeader { get; set; }
        public IEnumerable<BasketDetailsDto> BasketDetails { get; set; }
    }
}