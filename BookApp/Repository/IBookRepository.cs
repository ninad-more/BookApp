using BookApp.Data.Entities;

namespace BookApp.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBook(int id);
        Task<bool> AddNewBook(Book newbook);
        Task<bool> UpdateExistingBook(Book book);
        Task<bool> DeleteExistingBook(int id);
    }
}
