using MediatR;
using BookApp.Models;

namespace BookApp.Queries
{
    public class GetBookByIdQuery : IRequest<BookViewModel>
    {
        public int Id { get; set; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
