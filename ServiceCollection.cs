using Ecommerce.DbContextFolder;
using Ecommerce.FileStorages;
using Ecommerce.Implementation.Repositories;
using Ecommerce.Implementation.Services;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce;

public  static class ServiceCollection
{
    public static IServiceCollection AddDataBase(this IServiceCollection service, string connectionString)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        return service;
    }

    public static IServiceCollection AddRepository
        (this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ICartRepository, CartRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<ICompanyRepository, CompanyRepository>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IPaymentHistoryRepository, PaymentHistoryRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProfileRepository, ProfileRepository>()
            .AddScoped<IWalletRepository, WalletRepository>();
        return services;

    }


    public static IServiceCollection AddServices
        (this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>()
            .AddScoped<ICompanyService, CompanyService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<ICustomerService, CustomerService>()
            .AddScoped<IFileStorage, FileStorage>();
        
        
            
        return services;

    }
}