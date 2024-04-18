using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;

namespace Ecommerce.Implementation.Repositories;

public class CategoryRepository(ApplicationDbContext applicationDbContext) : RepositoryAsync<Category>(applicationDbContext), ICategoryRepository
{
    
}