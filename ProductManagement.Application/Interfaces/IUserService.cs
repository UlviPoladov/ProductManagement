public interface IUserService
{
    Task<UserDto> RegisterAsync(UserDto user);
    Task<string> LoginAsync(string username, string password);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto> UpdateUserAsync(int id, UserDto dto);
    Task<bool> DeleteUserAsync(int id);
}
