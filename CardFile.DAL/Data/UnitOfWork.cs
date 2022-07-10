using CardFile.DAL.Interfaces;
using CardFile.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace CardFile.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private ITextMaterialRepository _textMaterialRepository;
        private IReactionRepository _reactionRepository;
        private IHistoryRepository _historyRepository;

        private CardFileDBContext _context;
        public UnitOfWork(CardFileDBContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepositiory
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public ITextMaterialRepository TextMaterialRepository
        {
            get
            {
                if (_textMaterialRepository is null)
                    _textMaterialRepository = new TextMaterialRepository(_context);
                return _textMaterialRepository;
            }
        }
        public IReactionRepository ReactionRepository
        {
            get
            {
                if (_reactionRepository is null)
                    _reactionRepository = new ReactionRepository(_context);
                return _reactionRepository;
            }
        }

        public IHistoryRepository HistoryRepository
        {
            get
            {
                if (_historyRepository is null)
                    _historyRepository = new HistoryRepository(_context);
                return _historyRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
