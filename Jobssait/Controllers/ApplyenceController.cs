using Jobssait.Models;
using Jobssait.Models.DTO;
using Jobssait.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Controllers
{
    public class ApplyenceController : Controller
    {

      //  private ApplyenceService applyenceService;this.applyenceService = applyenceService;ApplyenceService applyenceService,
        private UserManager<User> userManager;
        private UserDBContext dbContext;


        public ApplyenceController(UserManager<User> userManager, UserDBContext dbContext)
        {
            
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public IActionResult ApplyIndex()
        {
            List<ApplyenceDTO> applyences = GetAll();

            return View(applyences);
        }

        public List<ApplyenceDTO> GetAll()
        {

            return dbContext.Applyence
                .Include(a => a.User)
                .Select(a => ToDto(a))
                .ToList();
        }

        private static ApplyenceDTO ToDto(Applyence a)
        {
            ApplyenceDTO applyence = new ApplyenceDTO();

            applyence.Id = a.Id;
            applyence.Name = a.Name;
            applyence.Content = a.Content;
            applyence.CreatedBy = $"{a.User.Userusername}";
            applyence.UserEmail = a.User.Email;

            return applyence;
        }

        
        [HttpGet]
        public IActionResult ApplyCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Applyence applyence)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);

            Create(applyence, user);

            return View();
        }

        public void Create(Applyence applyence, User user)
        {
            applyence.User = user;

            dbContext.Applyence.Add(applyence);
            dbContext.SaveChanges();

        }

        /*
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Post post = postService.GetById(id);

            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            postService.Edit(post);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Post post = postService.GetById(id);

            return View(post);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            postService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Preview(int id)
        {
            Post post = postService.GetById(id);

            return View(post);
        }

        public IActionResult Aply(int id)
        {
            postService.Aply(id);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index()
        {
            return View();
        }
*/
    }
}
