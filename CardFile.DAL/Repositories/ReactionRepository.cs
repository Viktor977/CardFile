using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(Reaction entity)
        {
            await _context.Reactions.AddAsync(entity);
        }

        public void Delete(Reaction entity)
        {
            _context.Reactions.Remove(entity);
        }

        public async  Task DeleteByIdAsync(int id)
        {
            var reaction = await _context.Reactions.FindAsync(id);
            _context.Reactions.Remove(reaction);
        }

        public async Task<IEnumerable<Reaction>> GetAllAsync()
        {
            return await _context.Reactions.ToListAsync();
        }

        public async Task<Reaction> GetByIdAsync(int id)
        {
            return await _context.Reactions.FindAsync(id);
        }

        public void Update(Reaction entity)
        {
            _context.Reactions.Update(entity);
        }
    }
}
