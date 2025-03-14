using Microsoft.AspNetCore.Identity;
using voteSphere.Application.Commands.Command;
using voteSphere.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace voteSphere.Application.Commands.CommandHandlers
{ 
    public class LogOutUserCommandHandler : IRequestHandler<LogOutUserCommand, Unit>
    {
        private SignInManager<ApplicationUser> _signInManager;

        public LogOutUserCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogOutUserCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Unit.Value; // Logout is always successful
        }
    }
}
