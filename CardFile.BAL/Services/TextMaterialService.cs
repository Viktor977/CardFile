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
    class TextMaterialService : ITextMaterialService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TextMaterialService(IUnitOfWork work,IMapper mapper)
        {
            _uow = work;
            _mapper = mapper;
        }
        public Task AddAsync(TextMaterialDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TextMaterialDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TextMaterialDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TextMaterialDto> GetByTitle(string title)
        {
            var text = await _uow.TextMaterialRepository.GetByTitle(title);
            var textDto = _mapper.Map<TextMaterial, TextMaterialDto>(text);
            return textDto;
        }

        public Task UpdateAsync(TextMaterialDto model)
        {
            throw new NotImplementedException();
        }
    }
}
