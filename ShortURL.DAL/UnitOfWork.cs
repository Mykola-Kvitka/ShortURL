using ShortURL.DAL.Interfaces;
using ShortURL.DAL.Models;
using ShortURL.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataAccsess _appData;

        private GenericRepository<URLEntity> _urls;
        private GenericRepository<UserEntity> _users;

        public UnitOfWork(DataAccsess appData)
        {
            _appData = appData;
        }

        public IGenericRepository<URLEntity> URLs => _urls ??= new GenericRepository<URLEntity>(_appData);
        public IGenericRepository<UserEntity> Users => _users ??= new GenericRepository<UserEntity>(_appData);
    }
}
