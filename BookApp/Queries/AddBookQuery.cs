using MediatR;
using BookApp.Models;

namespace BookApp.Queries
{
    public class AddBookQuery : IRequest<bool>
    {
        public BookViewModel Model { get; set; }

        public AddBookQuery(BookViewModel model)
        {
            Model = model;
        }
    }
}
