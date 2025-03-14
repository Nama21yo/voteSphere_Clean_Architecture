using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Application.ViewModels;
using voteSphere.Application.Commands.Command;

namespace voteSphere.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Displays the registration page.
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Handles user registration.
        /// </summary>
        /// <param name="vm">The RegisterViewModel containing user registration details.</param>
        /// <returns>An IActionResult indicating success or failure.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm); // Return view with validation errors
            }
            var command = new RegisterUserCommand
            {
                    Email = vm.Email,
                    Password = vm.Password,
                    FullName = vm.FullName,
                    Address = vm.Address,
                    DateOfBirth = vm.DateOfBirth,
                    State = vm.State,
                    City = vm.City
            };

            var result = await _mediator.Send(command); // Send request to MediatR handler

            if (result) // Check if registration was successful
            {
                return RedirectToAction("Index", "Home"); // Redirect to Home page
            }

            ModelState.AddModelError("", "Registration failed. Please try again.");
            return View(vm);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl=null) {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl=null)
        {
            if (!ModelState.IsValid)
            {
                return View(vm); // Return view with validation errors
            }
            var command = new LoginUserCommand
            {
                    Email = vm.Email,
                    Password = vm.Password,
                    RememberMe = vm.RememberMe
            };

            var result = await _mediator.Send(command); // Send request to MediatR handler

            if (result) // Check if login was successful
            {
                return RedirectToLocal(returnUrl); // Redirect to Home page
            }

            ModelState.AddModelError("", "Login failed. Please try again.");
            return View(vm);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if(Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            } else {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logout() {
            var command = new LogOutUserCommand();
            await _mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }
    }
}
