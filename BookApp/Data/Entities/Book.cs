namespace BookApp.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public string Type { get; set; }
    }
}
