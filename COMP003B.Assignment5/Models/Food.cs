namespace COMP003B.Assignment5.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
