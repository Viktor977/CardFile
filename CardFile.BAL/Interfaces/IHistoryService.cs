using CardFile.BAL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.BAL.Interfaces
{
   public interface IHistoryService : ICrud<HistoryDto>
    {
        //public Task<HistoryDto> GetByIdWithDetailsAsync(int id);
        //public Task<HistoryDto> GetByTitleWithDetailsAsync(string title);
        //public Task<HistoryDto> GetByAuthorWithDetailsAsync(string author);
        //public Task<HistoryDto> GetByDateWithDetailsAsync(DateTime date);
    }
}
