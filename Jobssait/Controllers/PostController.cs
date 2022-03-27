using Jobssait.Models;
using Jobssait.Models.DTO;
using Jobssait.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Controllers
{
    public class PostController : Controller
    {
        private PostService postService;
        private UserManager<User> userManager;
        private UserDBContext dbContext;

        public PostController(PostService postService, UserManager<User> userManager, UserDBContext dbContext)
        {
            this.postService = postService;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<PostDTO> posts = postService.GetAll();

            return View(posts);
        }
        public IActionResult UserPosts(int id)
        {
            List<Post> post = dbContext.Posts.Where(p => p.UseerId == id).ToList<Post>();

            return View(post);
        }
      
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Post post)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
        
            postService.Create(post, user);

            return RedirectToAction(nameof(Index));
        }

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
      
    }
}
