using CardFile.BAL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.BAL.Interfaces
{
    public interface IUserService : ICrud<UserDto>
    {
        Task<UserDto> GetByIdWithDetailsAsync(int id);
    }
}
