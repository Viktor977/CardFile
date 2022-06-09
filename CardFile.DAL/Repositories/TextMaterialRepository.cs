using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.DAL.Repositories
{
    public class TextMaterialRepository : ITextMaterialRepository
    {
        private readonly CardFileDBContext _context;
        public TextMaterialRepository(CardFileDBContext context)
        {
            _context = context;
        }
        public Task AddAsync(TextMaterial entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TextMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TextMaterial>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TextMaterial> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TextMaterial entity)
        {
            throw new NotImplementedException();
        }
    }
}
