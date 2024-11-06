using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Services;

namespace StoreApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService = new UserService();

        public IActionResult Index1()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userService.AddUser(user);
            return RedirectToAction("Index1" , "User");
        }
    }
}
