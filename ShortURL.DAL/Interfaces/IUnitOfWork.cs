using ShortURL.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<URLEntity> URLs { get; }
        IGenericRepository<UserEntity> Users { get; }
    }
}
