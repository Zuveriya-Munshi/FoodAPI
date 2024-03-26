using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemsController : ControllerBase
    {
        private readonly FoodContext _dbContext;

        public FoodItemsController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetFoodItems() 
        {
            return Ok(await _dbContext.FoodItems.ToListAsync());
        }

        [HttpPost]
     
        public async Task<ActionResult<FoodItem>> AddFoodItem(FoodItem addFoodItem)
        {
            if (string.IsNullOrEmpty(addFoodItem.Name) || string.IsNullOrEmpty(addFoodItem.Description))
            {
                return BadRequest("Name and description are required.");
            }


            await _dbContext.FoodItems.AddAsync(addFoodItem);
            await _dbContext.SaveChangesAsync();

            return Ok(addFoodItem);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<FoodItem>> UpdateFoodItem(int id, FoodItem foodItems)
        {
            if(id != foodItems.Id)
            {
                return BadRequest("Enter correct Id");
            }
            _dbContext.Entry(foodItems).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();    
            return Ok(foodItems);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodItem>> DeleteFoodItem(int id)
        {
            var food = await _dbContext.FoodItems.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            _dbContext.FoodItems.Remove(food);
            await _dbContext.SaveChangesAsync();
            return Ok(food);
        } 
    }
}
