using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;

namespace Ecommerce.Implementation.Repositories;

public class CompanyRepository(ApplicationDbContext applicationDbContext) : RepositoryAsync<Company>(applicationDbContext), ICompanyRepository
{
    
}