using MediatR;
using BookApp.Queries;
using BookApp.Services.Interfaces;

namespace BookApp.Handlers
{
    public class AddBookHandler : IRequestHandler<AddBookQuery, bool>
    {
        private readonly IBookService _service;

        public AddBookHandler(IBookService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(AddBookQuery request, CancellationToken cancellationToken)
        {
            return await _service.Add(request.Model);
        }
    }
}
