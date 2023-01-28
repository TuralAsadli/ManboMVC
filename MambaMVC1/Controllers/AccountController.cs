using AutoMapper;
using MambaMVC1.Models;
using MambaMVC1.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MambaMVC1.Controllers
{
    public class AccountController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) { return View(registerVM); }


            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<RegisterVM, User>()
               );
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(registerVM);

            var res = await _userManager.CreateAsync(user, registerVM.Password);
            if (!res.Succeeded)
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                await _signInManager.SignInAsync(user, isPersistent: true);

                return View(registerVM);
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) { return View(loginVM); }

            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<LoginVM, User>()
               );
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(loginVM);

            var res = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, true);
            
            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Wrong Username or Password");
                return View(loginVM);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult SingOut()
        {
            _signInManager.SignOutAsync();
            return View();
        }
    }
}
