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
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var user =await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
       public async Task<User>GetByIdWithDetailsAsync(int id)
        {
            var user = await _context.Users
                .Include(t => t.Profile)
                .SingleAsync(t => t.Id == id);
            return user;
        }
     
        public  void Update(User entity)
        {
            _context.Users.Update(entity);
           
        }
    }
}
