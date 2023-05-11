using AutoMapper;
using ShortURL.BLL.Interfaces;
using ShortURL.BLL.Models;
using ShortURL.DAL.Interfaces;
using ShortURL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> LoginAsync(User request)
        {
            return (await _unitOfWork.Users.FindAsync(userAtList => userAtList.Username == request.Username && request.Password == userAtList.Password)).FirstOrDefault() != null;
        }
        public async Task<User> GetAsync(User request)
        {
            var requestentity = (await _unitOfWork.Users.FindAsync(userAtList => userAtList.Username == request.Username && request.Password == userAtList.Password)).First();

            return _mapper.Map<UserEntity,User>(requestentity);
        }

        public async Task<int> RegisterAsync(User request)
        {
            if (((await _unitOfWork.Users.FindAsync(userAtList => userAtList.Username == request.Username)).Count != 0))
            {
                return -1;
            }

            var requestEntity = _mapper.Map<User, UserEntity>(request);

            var result = (await _unitOfWork.Users.CreateAsync(requestEntity)).Id;

            return result;
        }
    }
}
