using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AddAsync(TextMaterial entity)
        {
            await _context.Materials.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
           
        }

        public  void Delete(TextMaterial entity)
        {
            var text = _context.Materials.Find(entity.Id);
            _context.Materials.RemoveRange(text);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TextMaterial>> GetAllAsync()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<TextMaterial> GetByAuthorWithDetailsAsync(string author)
        {
            var text = await _context.Materials
                .Include(t => t.Reactions)
                .SingleAsync(t => t.Author == author);
            return text;
        }

        public async Task<TextMaterial> GetByDateWithDetailsAsync(DateTime date)
        {
            var text = await _context.Materials
                .Include(t => t.Reactions)
                .SingleAsync(t => t.DatePublish == date);
            return text;
        }

        public async Task<TextMaterial> GetByIdAsync(int id)
        {
            return await _context.Materials.FindAsync(id);
        }

        public async Task<TextMaterial> GetByTitleWithDetailsAsync(string title)
        {
            var text = await _context.Materials
                .Include(t => t.Reactions)
                .SingleAsync(t => t.Title == title);
            return text;
        }

        public  void Update(TextMaterial entity)
        {
            _context.Materials.Update(entity);
           
        }
    }
}
