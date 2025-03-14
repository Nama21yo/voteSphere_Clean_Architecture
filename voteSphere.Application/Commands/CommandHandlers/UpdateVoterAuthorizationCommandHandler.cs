using Microsoft.AspNetCore.Identity;
using voteSphere.Application.Commands.Command;
using voteSphere.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace voteSphere.Application.Commands.CommandHandlers
{
    public class UpdateVoterAuthorizationCommandHandler : IRequestHandler<UpdateVoterAuthorizationCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        public UpdateVoterAuthorizationCommandHandler(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }
        public async Task<bool> Handle(UpdateVoterAuthorizationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null) {
                return false;
            }
            user.IsAuthorized = request.IsAuthorized;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
