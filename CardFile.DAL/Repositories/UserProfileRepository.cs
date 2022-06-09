using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
        public Task AddAsync(UserProfile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserProfile entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserProfile entity)
        {
            throw new NotImplementedException();
        }
    }
}
