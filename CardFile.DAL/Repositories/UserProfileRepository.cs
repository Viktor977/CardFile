using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardFile.DAL.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly CardFileDBContext _context;
        public UserProfileRepository(CardFileDBContext context)
        {
            _context = context;
        }
        public async  Task AddAsync(UserProfile entity)
        {
            await _context.UserProfiles.AddAsync(entity);
        }

        public void Delete(UserProfile entity)
        {
            _context.UserProfiles.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var profile = await _context.UserProfiles.FindAsync(id);
            _context.UserProfiles.Remove(profile);
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public  void Update(UserProfile entity)
        {
            _context.UserProfiles.Update(entity);
           
        }
    }
}
