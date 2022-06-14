using CardFile.DAL.Entities;
using System.Threading.Tasks;

namespace CardFile.DAL.Interfaces
{
    public interface ITextMaterialRepository : IRepository<TextMaterial>
    {
       public Task<TextMaterial> GetByTitle(string title);
    }
}
