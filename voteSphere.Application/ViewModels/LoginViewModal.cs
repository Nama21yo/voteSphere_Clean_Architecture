using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace voteSphere.Application.ViewModels
{
    /// <summary>
    /// ViewModel for user login request.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// User's email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// User's password.
        /// </summary>
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        /// <summary>
        /// Indicates whether the user should stay logged in.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
