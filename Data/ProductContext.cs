using System.ComponentModel.DataAnnotations.Schema;
using BasketAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Wine> WineProducts { get; set; }
        public DbSet<BasketHeader> BasketHeaders { get; set; }
        public DbSet<BasketDetails> BasketDetails { get; set; }

    
    }
}
