using MediatR;
using BookApp.Models;
using BookApp.Queries;
using BookApp.Services.Interfaces;

namespace BookApp.Handlers
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, List<BookViewModel>>
    {
        private readonly IBookService _service;

        public GetBookListHandler(IBookService service)
        {
            _service = service;
        }

        public async Task<List<BookViewModel>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            return await _service.Get();
        }
    }
}
