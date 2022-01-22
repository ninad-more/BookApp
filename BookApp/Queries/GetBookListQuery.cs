using MediatR;
using BookApp.Models;

namespace BookApp.Queries
{
    public class GetBookListQuery : IRequest<List<BookViewModel>>
    {
        public GetBookListQuery()
        {

        }
    }
}
