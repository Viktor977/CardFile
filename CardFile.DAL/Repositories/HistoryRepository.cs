using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.DAL.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly CardFileDBContext _context;

        public HistoryRepository(CardFileDBContext context)
        {
            _context = context;
        }
        public Task AddAsync(History entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(History entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<History>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<History> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(History entity)
        {
            throw new NotImplementedException();
        }
    }
}
