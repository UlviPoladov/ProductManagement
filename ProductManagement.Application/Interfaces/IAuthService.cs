using ProductManagement.Domain.Entities;

public interface IAuthService
{
    string GenerateToken(User user);
}
