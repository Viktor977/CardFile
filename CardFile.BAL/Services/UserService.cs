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

        public async Task DeleteAsync(int modelId)
        {
           await _uow.UserRepositiory.DeleteByIdAsync(modelId);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _uow.UserRepositiory.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _uow.UserRepositiory.GetByIdAsync(id);
            return _mapper.Map<User, UserDto>(user);
        }
        public async Task<UserDto>GetByIdWithDetailsAsync(int id)
        {
            var userProfile = await _uow.UserRepositiory.GetByIdWithDetailsAsync(id);
            var profileDto = _mapper.Map<UserProfile, UserProfileDto>(userProfile.Profile);
            var res = _mapper.Map<User, UserDto>(userProfile);
            res.UserProfileDto = profileDto;
            return res;

        }

        public async Task UpdateAsync(UserDto model)
        {
            var user = _mapper.Map<UserDto, User>(model);
            _uow.UserRepositiory.Update(user);
            await _uow.SaveAsync();
        }
    }
}
