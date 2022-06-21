using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardFile.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CardFileDBContext _context;
        public UserRepository(CardFileDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async void Delete(User entity)
        {
            _context.Users.RemoveRange(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> ChekUser(string email,string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(t => t.Email == email
                && t.Password == password);
            if (user is null) return null;
            return user;
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
           
        public async void Update(User entity)
        {
            _context.Users.Update(entity);      
            await _context.SaveChangesAsync();
           
        }
    }
}
