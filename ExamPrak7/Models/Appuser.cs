using Microsoft.AspNetCore.Identity;

namespace ExamPrak7.Models
{
    public class Appuser:IdentityUser
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
    }
}
