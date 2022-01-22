using BookApp.Models;

namespace BookApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookViewModel>> Get();
        Task<BookViewModel> Get(int id);
        Task<bool> Add(BookViewModel bookViewModel);
        Task<bool> Update(BookViewModel bookViewModel);
        Task<bool> Delete(int id);
    }
}
