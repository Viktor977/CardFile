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
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UserProfileService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(UserProfileDto model)
        {
            if(model is null)
            {
                throw new CardFileException();
            }
            var profile = _mapper.Map<UserProfileDto, UserProfile>(model);
            await _uow.UserProfileRepository.AddAsync(profile);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
             await _uow.UserProfileRepository.DeleteByIdAsync(modelId);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<UserProfileDto>> GetAllAsync()
        {
            var profiles = await _uow.UserProfileRepository.GetAllAsync();
            var profilesDto = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileDto>>(profiles);
            return profilesDto;
        }

        public async Task<UserProfileDto> GetByIdAsync(int id)
        {
            var profile = await _uow.UserProfileRepository.GetByIdAsync(id);
            var profileDto = _mapper.Map<UserProfile, UserProfileDto>(profile);
            return profileDto;
        }

        public async Task UpdateAsync(UserProfileDto model)
        {
            var profile = _mapper.Map<UserProfileDto, UserProfile>(model);
            _uow.UserProfileRepository.Update(profile);
            await _uow.SaveAsync();
        }
    }
}
