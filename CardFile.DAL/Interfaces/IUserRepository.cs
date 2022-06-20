using CardFile.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByIdWithDetailsAsync(int id);
        public Task<bool> ChekUser(User entity);
    }
}
