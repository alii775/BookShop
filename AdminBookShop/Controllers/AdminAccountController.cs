using AdminBookShop.Models;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminBookShop.Controllers
{
    public class AdminAccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AdminAccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }
       
        [HttpPost]


        public async Task<IActionResult> Register(RegisterDto register) 
        {
            if (ModelState.IsValid)
            {
                var user = new User { Email = register.Email, UserName = register.Email };
                var res=  await _userManager.CreateAsync(user,register.Password);
                if (res.Succeeded) 
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Books");
                
                
                
                }
            }
           return View(register);
        
        
        }
        public IActionResult Login() 
        {
            return View();
      
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var user=await _signInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe,false);

                if (user.Succeeded) 
                {
                    return RedirectToAction("Index", "Books");
                
                
                }
            
            }
            return View(model);
        
        
        
        }
    }
}
