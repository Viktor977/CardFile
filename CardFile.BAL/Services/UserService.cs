using AutoMapper;
using CardFile.BAL.Interfaces;
using CardFile.BAL.ModelsDto;
using CardFile.BAL.Validation;
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
            if(model is null)
            {
                throw new CardFileException();
            }
            var user = _mapper.Map<UserDto, User>(model);
            await _uow.UserRepositiory.AddAsync(user) ;
            await _uow.SaveAsync();
        }

      

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _uow.UserRepositiory.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }
        public async Task<UserDto>CheckUser(string email,string password)
        {        
            var user = await _uow.UserRepositiory.ChekUser(email,password);
            if (user is null) return null;
            if(user is null)
            {
                return null;
            }

            var userDto = _mapper.Map<User, UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _uow.UserRepositiory.GetByIdAsync(id);
            return _mapper.Map<User, UserDto>(user);
        }
        

        public async Task  UpdateAsync(UserDto model)
        {
            var user = _mapper.Map<UserDto, User>(model);
            _uow.UserRepositiory.Update(user);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(UserDto model)
        {
            var user = _mapper.Map<UserDto, User>(model);
            _uow.UserRepositiory.Delete(user);
            await _uow.SaveAsync();
        }
       
    }
}
