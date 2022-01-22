using MediatR;
using BookApp.Repository;
using BookApp.Services;
using BookApp.Services.Interfaces;

namespace BookApp.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(IBookRepository).Assembly);
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
