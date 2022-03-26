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
        private PostService postService;
        private UserDBContext dbContext;


        public ApplyenceController(UserManager<User> userManager, PostService postService, UserDBContext dbContext)
        {
            
            this.userManager = userManager;
            this.postService = postService;
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
            applyence.PosstID = a.PosstID;

            return applyence;
        }

        
        [HttpGet]
        public IActionResult ApplyCreate(int id)
        {
            Post post = postService.GetById(id);

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Applyence applyence, int id)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);

            Post post = postService.GetById(id);

            applyence.User = user;

           // applyence.Post = post;

            applyence.PosstID = id;

            dbContext.Applyence.Add(applyence);
            dbContext.SaveChanges();

            return View();
        }

        public void Create(Applyence applyence, User user, Post post, int id)
        {
            applyence.User = user;

            applyence.Post = post;

            applyence.PosstID = id;

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
