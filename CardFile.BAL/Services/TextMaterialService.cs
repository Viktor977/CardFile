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
    class TextMaterialService : ITextMaterialService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TextMaterialService(IUnitOfWork work,IMapper mapper)
        {
            _uow = work;
            _mapper = mapper;
        }
        public async Task AddAsync(TextMaterialDto model)
        {
            var text = _mapper.Map<TextMaterialDto, TextMaterial>(model);
            await _uow.TextMaterialRepository.AddAsync(text);
        }

        public async Task DeleteAsync(int modelId)
        {
            await _uow.TextMaterialRepository.DeleteByIdAsync(modelId);
        }

        public async Task<IEnumerable<TextMaterialDto>> GetAllAsync()
        {
            var text = await _uow.TextMaterialRepository.GetAllAsync();
            var textDto = _mapper.Map<IEnumerable<TextMaterial>, IEnumerable<TextMaterialDto>>(text);       
            return textDto;
        }
    
        public async Task<TextMaterialDto> GetByIdAsync(int id)
        {
            var text = await _uow.TextMaterialRepository.GetByIdAsync(id);
            var textDto = _mapper.Map<TextMaterial, TextMaterialDto>(text);
            return textDto;
        }
        
        //TODO
        public async Task<TextMaterialDto> SearchByFilter(FilterSearchDto filter)
        {
            if(filter is null)
            {
                throw new CardFileException() ;
            }
            if (!string.IsNullOrWhiteSpace(filter.TitleText))
            {
                var text = await _uow.TextMaterialRepository.GetByTitleWithDetailsAsync(filter.TitleText);
                var textDto = _mapper.Map<TextMaterial, TextMaterialDto>(text);
                return textDto;
            }
            if (!string.IsNullOrWhiteSpace(filter.Author)){
                var text = await _uow.TextMaterialRepository.GetByAuthorWithDetailsAsync(filter.Author);
                var textDto = _mapper.Map<TextMaterial, TextMaterialDto>(text);
                return textDto;
            }
            var textDate = await _uow.TextMaterialRepository.GetByDateWithDetailsAsync(filter.DataPublication);
            var textDateDto = _mapper.Map<TextMaterial, TextMaterialDto>(textDate);
            return textDateDto;

            return null;
        }

        public async Task UpdateAsync(TextMaterialDto model)
        {
            var text = _mapper.Map<TextMaterialDto, TextMaterial>(model);
            _uow.TextMaterialRepository.Update(text);
            await _uow.SaveAsync();

        }
    }
}
