using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //library for annotations

namespace MyProject.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage ="The email needs to have at least {1} characters", MinimumLength =1)]
        [Display(Name ="Email: ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password: ")]
        public string Password { get; set; }


        [Display(Name = "Confirm password: ")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The passwords are not the same")]
        public string ConfirmPwd { get; set; } 
    }
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "The email needs to have at least {1} characters", MinimumLength = 1)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }


        [Display(Name = "Confirm password: ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords are not the same")]
        public string ConfirmPwd { get; set; }
    }
}