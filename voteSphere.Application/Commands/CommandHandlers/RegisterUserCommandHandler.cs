using Microsoft.AspNetCore.Identity;
using voteSphere.Application.Commands.Command;
using voteSphere.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace voteSphere.Application.Commands.CommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private  UserManager<ApplicationUser> _userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Create new application user
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName, // Ensure FullName is a property in ApplicationUser
                DateOfBirth = request.DateOfBirth,
                State = request.State,
                City  = request.City,
                Address = request.Address,
                IsAuthorized = false,
                HasVoted = false
            };

            // Attempt to create the user with the given password
            var result = await _userManager.CreateAsync(user, request.Password);

            // Return true if registration was successful, otherwise false
            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, "Voter");
            }
            return result.Succeeded;
        }
    }
}
