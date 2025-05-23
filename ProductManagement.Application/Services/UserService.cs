using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public UserService(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<UserDto> RegisterAsync(UserDto userDto)
    {
        var user = new User { Username = userDto.Username, Email = userDto.Email, Password = userDto.Password };
        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.CompleteAsync();
        return userDto;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user == null) return null;
        return _authService.GenerateToken(user);
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return users.Select(u => new UserDto
        {
            Username = u.Username,
            Email = u.Email,
            Password = u.Password
        }).ToList();
    }

    public async Task<UserDto> UpdateUserAsync(int id, UserDto userDto)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return null;

        user.Username = userDto.Username;
        user.Email = userDto.Email;
        user.Password = userDto.Password;

        _unitOfWork.Users.Update(user);
        await _unitOfWork.CompleteAsync();
        return userDto;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return false;

        _unitOfWork.Users.Delete(user);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
