using Microsoft.AspNetCore.Identity;
using voteSphere.Domain.Entities;
using voteSphere.Application.Commands.Command;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace voteSphere.Application.Commands.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private  UserManager<ApplicationUser> _userManager;
        private  SignInManager<ApplicationUser> _signInManager;

        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Find user by email
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null || !user.IsAuthorized )
            {
                return false; // User not found
            }


            // Attempt to sign in with the given password
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, request.RememberMe, lockoutOnFailure: false);

            return result.Succeeded; // Return true if login was successful, false otherwise
        }
    }
}
