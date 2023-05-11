using ShortURL.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.BLL.Interfaces
{
    public interface IURLService
    {
        Task CreateAsync(URL request);
        Task<IEnumerable<URL>> GetAllAsync();
        Task DeleteAsync(int id);
        Task DeleteAllAsync();
        Task<URL> GetAsync(int id);
    }
}
