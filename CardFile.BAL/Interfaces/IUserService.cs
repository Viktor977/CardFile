using CardFile.BAL.ModelsDto;
using System.Threading.Tasks;

namespace CardFile.BAL.Interfaces
{
    public interface IUserService : ICrud<UserDto>
    {     
        Task<UserDto> CheckUser(string email,string password);
    }
}
