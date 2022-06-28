using ExamPrak7.Areas.Admin.ViewModel.Autho;
using ExamPrak7.Models;
using ExamPrak7.ViewModel.Autho;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamPrak7.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        public readonly UserManager<Appuser> _usermanager;
        public readonly SignInManager<Appuser> _signInManager;
        public AuthController(UserManager<Appuser> usermanager,SignInManager<Appuser> signInManager)
        {
            _usermanager = usermanager;
            _signInManager = signInManager; 
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            Appuser newUser = new Appuser()
            {
                FisrtName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                 UserName = register.UserName
            };
            IdentityResult result = await _usermanager.CreateAsync(newUser,register.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM Login)
        {
            Appuser user;
            if (Login.UserNameOrEmail.Contains("@"))
                user = await _usermanager.FindByEmailAsync(Login.UserNameOrEmail);
            else
                user = await _usermanager.FindByNameAsync(Login.UserNameOrEmail);
            if (user == null)
            {
                ModelState.AddModelError("", "Login and user Wrong");
                return View(Login);
            }
            var result = await _signInManager.PasswordSignInAsync(user, Login.Password, Login.RememberMe, true);
            if (result.Succeeded)
            {
                ModelState.AddModelError("", "Nese YAnlisdir ");  
            }


            return RedirectToAction("Index", "Dashboard");
        }

    }
}
