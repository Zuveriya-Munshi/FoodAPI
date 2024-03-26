using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace RestaurantAPI.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public double Rating { get; set; }
        public string Cuisine { get; set; }
        public ICollection<FoodItem> FoodItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
