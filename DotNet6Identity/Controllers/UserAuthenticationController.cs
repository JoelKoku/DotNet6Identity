using DotNet6Identity.Models.DTO;
using DotNet6Identity.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6Identity.Controllers
{
    public class UserAuthentication : Controller
    {
        private readonly IUserAuthenticationService _service;
        public UserAuthentication(IUserAuthenticationService _service)
        {
            this._service = _service;
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if(!ModelState.IsValid)
            return View(model);
            model.Role = "user";
            var result = await _service.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _service.LoginAsync(model);
            if(result.StatusCode == 1)
            {
                return RedirectToAction("Display","Dashboard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
      /*  public async Task<IActionResult> Reg()
        {
           RegistrationModel model = new RegistrationModel
            {
                Username="admin",
                Email="admin@gmail.com",
                FirstName="John",
                LastName="Doe",
                Password="Admin@12345#"
            };
           model.Role = "admin";
           var result = await _service.RegistrationAsync(model);
            return Ok(result);
        }*/
      /*public async Task<IActionResult> Log()
        {
            LoginModel model = new LoginModel()
            {
                Username = "admin",
                Password = "Admin@12345#"
            };
            var result = await _service.LoginAsync(model);
            return Ok(result);
        }
    */
    }
}
