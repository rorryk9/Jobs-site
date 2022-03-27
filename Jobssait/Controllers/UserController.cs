using Jobssait.Models;
using Jobssait.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Data()
        {
            User user = await userManager.GetUserAsync(User);

            UserDTO userDTO = new UserDTO();
            userDTO.Email = user.Email;
            userDTO.Id = user.Id;
            userDTO.Userusername = user.Userusername;

            return View(userDTO);
        }
    }
}
