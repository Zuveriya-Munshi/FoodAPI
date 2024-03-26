using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RestaurantAPI.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options){}
        public DbSet<FoodItem> FoodItems { get; set; }

    }
}
