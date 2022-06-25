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
    public class HistoryRepository : IHistoryRepository
    {
        private readonly CardFileDBContext _context;

        public HistoryRepository(CardFileDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(History entity)
        {         
            await _context.Histories.AddRangeAsync(entity);
            await _context.SaveChangesAsync();

        }

        public  void Delete(History entity)
        {
            var history = _context.Histories.Find(entity.Id);
            _context.Histories.RemoveRange(history);
            _context.SaveChanges();
        
        }

        public async Task<IEnumerable<History>> GetAllAsync()
        {
            return await _context.Histories.ToListAsync();
        }
   
        public async  Task<History> GetByIdAsync(int id)
        {
            return await _context.Histories.
                Include(t => t.Material)
                .ThenInclude(t => t.Reactions)
                .SingleAsync(t => t.TextId == id);
        }

        public void Update(History entity)
        {
            _context.Histories.Update(entity);
           
        }   
    }
}
