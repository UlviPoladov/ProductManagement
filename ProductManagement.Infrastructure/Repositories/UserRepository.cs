using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }
}
