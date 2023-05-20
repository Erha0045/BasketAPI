namespace BasketAPI.Models.Dto
{
    public class BasketDetailsDto
    {
      
        public int BasketDetailsId { get; set; }

        public int BasketHeaderId { get; set; }
        public virtual BasketHeaderDto BasketHeader { get; set; }

        public int WineId { get; set; }

        public virtual WineDto Wine { get; set; }

        public int Amount { get; set; }
    }
}