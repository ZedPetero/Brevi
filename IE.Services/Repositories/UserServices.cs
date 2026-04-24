using Brevi.Domain.Models;
using Brevi.Services.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly UserManager<Teacher> _userManager;

    public UserService(UserManager<Teacher> userManager)
    {
        _userManager = userManager;
    }

    public List<string> GetAllUsernames()
    {
        return _userManager.Users
            .Select(u => u.UserName)
            .Where(u => !string.IsNullOrEmpty(u))
            .ToList()!;
    }
}