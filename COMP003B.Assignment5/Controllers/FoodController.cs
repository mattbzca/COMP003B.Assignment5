using COMP003B.Assignment5.Data;
using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Food>> GetFoods()
        {
            return Ok(FoodStore.Foods);
        }

        [HttpGet("{id}")]
        public ActionResult<Food> GetFood(int id)
        {
            var food = FoodStore.Foods.FirstOrDefault(p => p.Id == id);

            if (food is null)
                return NotFound();

            return Ok(food);
        }

        [HttpPost]
        public ActionResult<Food> CreateProduct(Food food)
        {
            food.Id = FoodStore.Foods.Max(p => p.Id) + 1;

            FoodStore.Foods.Add(food);

            return CreatedAtAction(nameof(GetFood), new { id = food.Id }, food);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateFood(int id, Food updatedFood)
        {
            var existingFood = FoodStore.Foods.FirstOrDefault(p => p.Id == id);

            if (existingFood is null)
                return NotFound();

            existingFood.Name = updatedFood.Name;
            existingFood.Price = updatedFood.Price;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFood(int id)
        {
            var food = FoodStore.Foods.FirstOrDefault(p => p.Id == id);

            if (food is null)
                return NotFound();

            FoodStore.Foods.Remove(food);

            return NoContent();
        }
        [HttpGet("filter")]
        public ActionResult<List<Food>> FilterFoods(decimal price)
        {
            var filteredFoods = FoodStore.Foods
                .Where(p => p.Price <= price)
                .OrderBy(p => p.Price)
                .ToList();
            return Ok(filteredFoods);
        }
        [HttpGet("names")]
        public ActionResult<List<string>> GetFoodNames()
        {
            var foodNames = FoodStore.Foods
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToList();

            return Ok(foodNames);
        }
    }
}
