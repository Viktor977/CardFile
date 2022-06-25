using CardFile.BAL.ModelsDto;
using System.Threading.Tasks;

namespace CardFile.BAL.Interfaces
{
    public interface ITextMaterialService : ICrud<TextMaterialDto>
    {      
        public Task<TextMaterialDto>SearchByFilter(FilterSearchDto filter);
     
    }
}
