
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;

namespace voteSphere.Application.Commands.Command
{
    public class LoginUserCommand : IRequest<bool>
    {
        public string Email {get; set;}

        public string Password {get; set;}
        public  bool RememberMe {get; set;}

    }
}
