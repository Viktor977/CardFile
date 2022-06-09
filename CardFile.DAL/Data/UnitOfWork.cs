using CardFile.DAL.Interfaces;
using CardFile.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CardFileDBContext _context;
        public UnitOfWork(CardFileDBContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepositiory
        {
            get
            {
                return new UserRepository(_context);
            }
        }

        public IUserProfileRepository UserProfileRepository
        {
            get
            {
                return new UserProfileRepository(_context);
            }
        }

        public ITextMaterialRepository TextMaterialRepository
        {
            get
            {
                return new TextMaterialRepository(_context);
            }
        }
        public IReactionRepository ReactionRepository
        {
            get
            {
                return new ReactionRepository(_context);
            }
        }

        public IHistoryRepository HistoryRepository
        {
            get
            {
                return new HistoryRepository(_context);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
