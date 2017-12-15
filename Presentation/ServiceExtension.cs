using Business;
using Data.Domain.Interfeces;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation
{
    public static class ServicesExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReceiptRepository, ReceiptRepository>();
        }
    }
}
