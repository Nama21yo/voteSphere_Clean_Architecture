using voteSphere.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using voteSphere.Domain.UseCases;
using voteSphere.Infrastructure.Database;

namespace voteSphere.Infrastructure.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly VotingContext _context;

        public UnitOfWork(VotingContext context) 
        {
            _context = context;
            Users = new UserRepository(_context);
            Votes = new VoteRepository(_context);
            VoteGroups = new VoteGroupRepository(_context);
        }

        // Repositories initialized on demand;
        public IUserRepository Users {get; private set;}

        public IVoteRepository Votes {get; private set;}

        public IVoteGroupRepository VoteGroups {get; private set;} 

        // Save changes to the database
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Dispose of the context when done
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
