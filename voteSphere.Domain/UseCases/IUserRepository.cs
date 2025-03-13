using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using voteSphere.Domain.Entities;

namespace voteSphere.Domain.UseCases {
    public interface IUserRepository : IRepository<ApplicationUser>
    {

    }
}
