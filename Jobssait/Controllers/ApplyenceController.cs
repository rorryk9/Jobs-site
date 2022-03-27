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

        public IActionResult ApplyIndex(int id)
        {
            List<Applyence> applyences = dbContext.Applyence.Where(a => a.PosstID == id).ToList<Applyence>();
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
        public IActionResult Finish()
        {
            return View();
        }
        public IActionResult Finishempl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Applyence applyence, int id)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);

            Post post = postService.GetById(id);
            Applyence newApplyence = new Applyence();

            newApplyence.Name = applyence.Name;
            newApplyence.Content = applyence.Content;

            newApplyence.User = user;

            newApplyence.Post = post;

            newApplyence.PosstID = id;

            dbContext.Applyence.Add(newApplyence);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Finish));
        }

        public void Create(Applyence applyence, User user, Post post, int id)
        {
            applyence.User = user;

            applyence.Post = post;

            applyence.PosstID = id;

            dbContext.Applyence.Add(applyence);
            dbContext.SaveChanges();

        }

        public Applyence GetById(int id)
        {
            return dbContext.Applyence.FirstOrDefault(x => x.Id == id);
        }
        public Applyence GetByPostId(int id)
        {
            return dbContext.Applyence.FirstOrDefault(x => x.PosstID == id);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            Applyence dbpost = GetById(id);
            dbContext.Applyence.Remove(dbpost);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Aply(int id)
        {
            postService.Aply(id);

            Applyence dbpost = GetByPostId(id);
            dbContext.Applyence.Remove(dbpost);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Finishempl));
        }

    }
}
