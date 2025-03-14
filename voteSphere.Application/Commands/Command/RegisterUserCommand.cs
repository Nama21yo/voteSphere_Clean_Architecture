
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;

namespace voteSphere.Application.Commands.Command
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string Email {get; set;}

        public string Password {get; set;}
        public  string? FullName {get; set;}
        public  DateTime? DateOfBirth {get; set;}

        public string? State {get; set;}

        public string? City {get; set;} // basically ? >> to make it Nullable

        public string? Address {get; set;}

    }
}
