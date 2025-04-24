using COMP003B.Assignment5.Models;
namespace COMP003B.Assignment5.Data
{
    public static class FoodStore
    {
        public static List<Food> Foods { get; } = new()
        {
            new Food { Id = 1, Name = "Pasta", Price = 16.00m, ExpiryDate = new DateTime(2025, 04, 28) },
            new Food { Id = 2, Name = "Pizza", Price = 22.00m, ExpiryDate = new DateTime(2025, 05, 02) },
            new Food { Id = 3, Name = "Pie", Price = 14.00m, ExpiryDate = new DateTime(2025, 04, 27) }
        };
    }
}
