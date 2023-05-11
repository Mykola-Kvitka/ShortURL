using ShortURL.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> LoginAsync(User request);
        Task<User> GetAsync(User request);
        Task<int> RegisterAsync(User request);
    }
}
