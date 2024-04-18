using System.Linq.Expressions;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Repositories;

public interface IProfileRepository : IRepository<Profile>
{
    Task<Profile> GetProfile(Expression<Func<Profile, bool>> expression);
    Task<IEnumerable<Profile>> GetAllProfileAsync(Expression<Func<Profile, bool>> expression);
}