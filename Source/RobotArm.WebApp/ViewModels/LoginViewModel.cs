﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RobotArm.WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Username")]
        public string Login { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }              
    }
}