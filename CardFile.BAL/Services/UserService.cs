using AutoMapper;
using CardFile.BAL.Interfaces;
using CardFile.BAL.ModelsDto;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddAsync(UserDto model)
        {
            var user = _mapper.Map<UserDto, User>(model);
            await _uow.UserRepositiory.AddAsync(user);
        }

        public Task DeleteAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _uow.UserRepositiory.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public Task<UserDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDto model)
        {
            throw new NotImplementedException();
        }
    }
}
