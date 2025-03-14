
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;

namespace voteSphere.Application.Commands.Command
{ 
    public class UpdateVoterAuthorizationCommand : IRequest<bool>
    {
        public string UserId {get; set; }
        public bool IsAuthorized {get; set; }
    }
}
