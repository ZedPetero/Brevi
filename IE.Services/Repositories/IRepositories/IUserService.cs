using System;
using System.Collections.Generic;
using System.Text;

namespace Brevi.Services.Repositories.IRepositories
{
    public interface IUserService
    {
        List<string> GetAllUsernames();
    }
}
