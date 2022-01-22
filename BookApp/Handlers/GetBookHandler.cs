using MediatR;
using BookApp.Models;
using BookApp.Queries;
using BookApp.Services.Interfaces;

namespace BookApp.Handlers
{
    public class GetBookHandler : IRequestHandler<GetBookByIdQuery, BookViewModel>
    {
        private readonly IBookService _service;
        public GetBookHandler(IBookService service)
        {
            _service = service;
        }

        public async Task<BookViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.Get(request.Id);
        }
    }
}
