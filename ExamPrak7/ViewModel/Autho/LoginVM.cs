﻿using System.ComponentModel.DataAnnotations;

namespace ExamPrak7.ViewModel.Autho
{
    public class LoginVM
    {
        [Required]
        public string UserNameOrEmail { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
