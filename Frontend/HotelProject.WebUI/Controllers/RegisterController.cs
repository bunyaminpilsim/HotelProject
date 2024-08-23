using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.RegisterDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDTO createNewUserDTO)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUserDTO.Name,
                Surname = createNewUserDTO.Surname,
                UserName = createNewUserDTO.Username,
                Email = createNewUserDTO.Mail,
                City = "İstanbul",
                Country="Türkiye",
                
                
            };
            var result= await _userManager.CreateAsync(appUser,createNewUserDTO.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
