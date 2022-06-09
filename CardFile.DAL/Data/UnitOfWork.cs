using CardFile.DAL.Interfaces;
using CardFile.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IUserProfileRepository UserProfileRepository => throw new NotImplementedException();

        public ITextMaterialRepository TextMaterialRepository => throw new NotImplementedException();

        public IReactionRepository ReactionRepository => throw new NotImplementedException();

        public IHistoryRepository HistoryRepository => throw new NotImplementedException();
    }
}
