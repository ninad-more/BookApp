using Microsoft.EntityFrameworkCore;
using BookApp.Data;
using BookApp.Data.Entities;

namespace BookApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookAppDbContext _context;
        public BookRepository(BookAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewBook(Book newbook)
        {
            try
            {
                _context.Books.Add(newbook);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteExistingBook(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var book = await _context.Books.FindAsync(Id);

                    if (book != null)
                    {
                        _context.Books.Remove(book);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public async Task<Book> GetBook(int id)
        {
            try
            {
                var books = await _context.Books.ToListAsync();

                if (books?.Any() ?? false)
                {
                    return books.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception)
            {
                return new Book();
            }

            return new Book();
        }

        public async Task<bool> UpdateExistingBook(Book book)
        {
            try
            {
                if (book != null)
                {
                    var editBook = await _context.Books.FindAsync(book.Id);

                    if (editBook != null)
                    {
                        editBook.Name = book.Name;
                        editBook.Price = book.Price;
                        editBook.Pages = book.Pages;
                        editBook.Type = book.Type;
                        await _context.SaveChangesAsync();

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
