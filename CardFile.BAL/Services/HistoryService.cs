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
    public class HistoryService : IHistoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public HistoryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddAsync(HistoryDto model)
        {
            if(model is null)
            {
                throw new CardFileException();
            }
            var history = _mapper.Map<HistoryDto,History>(model);
            await _uow.HistoryRepository.AddAsync(history);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _uow.HistoryRepository.DeleteByIdAsync(modelId);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<HistoryDto>> GetAllAsync()
        {
            var histories = await _uow.HistoryRepository.GetAllAsync();
            var historiesDto = _mapper.Map<IEnumerable<History>,IEnumerable<HistoryDto>>(histories);
            return historiesDto;

        }

        public async Task<HistoryDto> GetByIdAsync(int id)
        {
            var history = await _uow.HistoryRepository.GetByIdAsync(id);
            var historyDto = _mapper.Map<History, HistoryDto>(history);
            return historyDto;
        }

       

        public async Task UpdateAsync(HistoryDto model)
        {
            var history = _mapper.Map<HistoryDto, History>(model);
            _uow.HistoryRepository.Update(history);
            await _uow.SaveAsync();
        }
    }
}
