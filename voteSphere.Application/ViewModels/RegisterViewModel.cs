using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace voteSphere.Application.ViewModels
{
    /// <summary>
    /// ViewModel for user registration.
    /// </summary>
    public class RegisterViewModel 
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
        /// Confirm password field.
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Confirm Password must be between 6 and 100 characters.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// User's full name (optional).
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// User's date of birth (optional).
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// User's state (optional).
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// User's city (optional).
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// User's address (optional).
        /// </summary>
        public string? Address { get; set; }
    }
}
