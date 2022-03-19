﻿//using Jobssait.Models.DTOs;
//using Jobssait.Models.Entities;
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
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
      //  private SignInManager<User> signInManager;
     
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
          //  this.signInManager = signInManager;
        }
     
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
    //        signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            User user = new User();
            user.Email = userDTO.Email;
            user.UserName = userDTO.Email;
            user.Userusername = userDTO.Userusername;
            
            IdentityResult result = await userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
          /*
            List<IdentityError> errors = new List<IdentityError>(result.Errors);
            ViewData["errors"] = errors;
         */

            return View();
        }



/*
        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewData["errorMessage"] = "Username or password is incorrect!";

            return View();
        }
*/
        

    }
}
