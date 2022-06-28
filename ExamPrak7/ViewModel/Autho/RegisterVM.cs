using System.ComponentModel.DataAnnotations;

namespace ExamPrak7.Areas.Admin.ViewModel.Autho
{
    public class RegisterVM
    {
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required,MaxLength(50)]
        public string LastName { get; set; }
        [Required,MaxLength(50)]
        public string UserName { get; set; }
        [Required,DataType(DataType.EmailAddress)] 
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]

        public string Password { get; set; }
        [Required, DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get;set; }
    }
}
