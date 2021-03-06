using CardFile.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> ChekUser(string email,string password);
    }
}
