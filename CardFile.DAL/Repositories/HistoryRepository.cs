﻿using CardFile.DAL.Data;
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
            await _context.Histories.AddAsync(entity);

        }

        public void Delete(History entity)
        {
            _context.Histories.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
          var history=  await _context.Histories.FindAsync(id);
            _context.Histories.Remove(history);
        }

        public async Task<IEnumerable<History>> GetAllAsync()
        {
            return await _context.Histories.ToListAsync();
        }

        public async Task<History> GetByAuthorWithDetailsAsync(string author)
        {
            var card = await _context.Histories
                .Include(t => t.Material)
                .ThenInclude(t => t.Reactions)
                .SingleAsync(t => t.Material.Author == author);

            return card;
        }

        public async Task<History> GetByDateWithDetailsAsync(DateTime date)
        {
            var card = await _context.Histories
                .Include(t => t.Material)
                .ThenInclude(t => t.Reactions)
                .SingleAsync(t => t.Material.DatePublish == date);

            return card;

        }

        public async  Task<History> GetByIdAsync(int id)
        {
            return await _context.Histories.FindAsync(id);
        }

        public async Task<History> GetByIdWithDetailsAsync(int id)
        {
            var card = await _context.Histories
               
                .Include(t => t.Material)
                
                .SingleAsync(t => t.TextId==id);

            return card;
        }

        public async Task<History> GetByTitleWithDetailsAsync(string title)
        {
            var card = await _context.Histories.Include(t=>t.User)
                .Include(t => t.Material)
                .ThenInclude(t => t.Reactions)
                .SingleAsync(t => t.Material.Title == title);

            return card;
        }

        public void Update(History entity)
        {
            _context.Histories.Update(entity);
        }
    }
}
