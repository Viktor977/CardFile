using CardFile.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace CardFile.DAL.Interfaces
{
    public interface ITextMaterialRepository : IRepository<TextMaterial>
    {
     
        public Task<TextMaterial> GetByDateWithDetailsAsync(DateTime date);
        public Task<TextMaterial> GetByTitleWithDetailsAsync(string title);
        public Task<TextMaterial> GetByAuthorWithDetailsAsync(string author);
    }
}
