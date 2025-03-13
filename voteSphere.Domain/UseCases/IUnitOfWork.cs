using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace voteSphere.Domain.UseCases {
    // wrapper to commbine all repositories
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users {get;}
        IVoteRepository Votes {get;}
        IVoteGroupRepository VoteGroups {get;}

        Task<int> CompleteAsync();
    }
}
