using Jobssait.Models;
using Jobssait.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Jobssait.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            List<Post> posts = postService.GetAll();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string content)
        {
            postService.Create(content);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Post post = postService.GetById(id);

            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(int id, string content)
        {
            postService.Edit(id, content);

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
    }
}