using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Infrastructure.Data;

namespace Eencyclopedia.Infrastructure.Repositories;

public class UserRepository(EencyclopediaDbContext context)
    : BaseRepository<User>(context), IUserRepository
{

}