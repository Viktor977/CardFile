using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.DAL.Repositories
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly CardFileDBContext _context;
        public ReactionRepository(CardFileDBContext context)
        {
            _context = context;
        }
        public Task AddAsync(Reaction entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Reaction entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reaction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reaction> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
