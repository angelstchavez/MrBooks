using MrBooks.Web.Models;

namespace MrBooks.Web.Interface
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        bool Save(Book book);
        bool Update(Book book);
        bool Delete(int id);
        Book GetById(int id);
    }
}
