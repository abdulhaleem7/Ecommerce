using System.Linq.Expressions;
using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Implementation.Repositories;

public class ProfileRepository(ApplicationDbContext applicationDbContext)
    : RepositoryAsync<Profile>(applicationDbContext), IProfileRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<Profile> GetProfile(Expression<Func<Profile, bool>> expression)
    {
        var entity = _applicationDbContext.Profiles.Include(x => x.User).FirstOrDefaultAsync(expression);
        return await entity;
    }

    public async Task<IEnumerable<Profile>> GetAllProfileAsync(Expression<Func<Profile, bool>> expression)
    {
        var entities = _applicationDbContext.Profiles.Include(x => x.User).Where(expression);
        return await entities.ToListAsync();
    }
}