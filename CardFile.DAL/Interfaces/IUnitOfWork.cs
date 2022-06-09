using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepositiory { get; }
        IUserProfileRepository UserProfileRepository { get; }
        ITextMaterialRepository TextMaterialRepository { get; }
        IReactionRepository ReactionRepository { get; }
        IHistoryRepository HistoryRepository { get; }
        Task SaveAsync();
    }
}
