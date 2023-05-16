namespace MrBooks.Web.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
