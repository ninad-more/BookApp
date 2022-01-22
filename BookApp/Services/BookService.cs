using BookApp.Data.Entities;
using BookApp.Models;
using AutoMapper;
using BookApp.Services.Interfaces;
using BookApp.Repository;

namespace BookApp.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BookViewModel>> Get()
        {
            var books = await _repository.GetAllBooks();
            var result = _mapper.Map<List<BookViewModel>>(books);
            return result;
        }

        public async Task<BookViewModel> Get(int id)
        {
            var book = await _repository.GetBook(id);
            return _mapper.Map<BookViewModel>(book);
        }

        public async Task<bool> Add(BookViewModel bookViewModel)
        {
            if (bookViewModel == null) return false;

            var book = _mapper.Map<Book>(bookViewModel);

            return await _repository.AddNewBook(book);
        }

        public async Task<bool> Update(BookViewModel bookViewModel)
        {
            if (bookViewModel == null) return false;

            var book = _mapper.Map<Book>(bookViewModel);

            return await _repository.UpdateExistingBook(book);
        }

        public async Task<bool> Delete(int id)
        {
            if (id < 1) return false;

            return await _repository.DeleteExistingBook(id);
        }
    }
}
