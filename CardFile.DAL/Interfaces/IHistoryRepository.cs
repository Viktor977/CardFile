using CardFile.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace CardFile.DAL.Interfaces
{
    public interface IHistoryRepository : IRepository<History>
    {
        public Task<History> GetByIdWithDetailsAsync(int id);
        public Task<History> GetByTitleWithDetailsAsync(string title);
        public Task<History> GetByAuthorWithDetailsAsync(string author);
        public Task<History> GetByDateWithDetailsAsync(DateTime date);
    }
}
