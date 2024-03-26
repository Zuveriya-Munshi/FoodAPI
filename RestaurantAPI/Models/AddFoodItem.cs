﻿namespace RestaurantAPI.Models
{
    public class AddFoodItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        
    }
}
