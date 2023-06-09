using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketAPI.Models
{
    public class Wine
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public Guid ProductGuid { get; set; }

        public string Name { get; set; }
     
        public string Description { get; set; }
       
        public decimal Price { get; set; }
       
        public string Origin { get; set; }
       
        public float AlcoholPercentage { get; set; }
        
        public int Year { get; set; }
       
        public string Image { get; set; }
      
        public string Size { get; set; }
    }
}
