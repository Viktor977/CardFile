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
    public class ReactionService : IReactionService
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ReactionService(IUnitOfWork uow,IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public  async Task AddAsync(ReactionDto model)
        {
            var reaction = _mapper.Map<ReactionDto, Reaction>(model);
            await _uow.ReactionRepository.AddAsync(reaction);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(ReactionDto model)
        {
            var reaction = _mapper.Map<ReactionDto, Reaction>(model);
             _uow.ReactionRepository.Delete(reaction);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<ReactionDto>> GetAllAsync()
        {
            var reactions = await _uow.ReactionRepository.GetAllAsync();
            var reactionsDto = _mapper.Map<IEnumerable<Reaction>, IEnumerable<ReactionDto>>(reactions);
            return reactionsDto;
        }

        public async Task<ReactionDto> GetByIdAsync(int id)
        {
            var reaction = await _uow.ReactionRepository.GetByIdAsync(id);
            var reactionDto = _mapper.Map<Reaction, ReactionDto>(reaction);
            return reactionDto; 
        }

        public async Task UpdateAsync(ReactionDto model)
        {
            var reactionDto = _mapper.Map<ReactionDto, Reaction>(model);
            _uow.ReactionRepository.Update(reactionDto);
            await _uow.SaveAsync();
        }
    }
}
