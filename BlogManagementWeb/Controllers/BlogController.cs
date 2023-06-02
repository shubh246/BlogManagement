using BlogManagementWeb.Service;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BlogManagementWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService _blogService)
        {
            blogService = _blogService;
        }


        public async Task<IActionResult> Index()
        {
            var blogs = await blogService.GetblogsAsync();
            return View(blogs);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Blog blog)
        {
            if (ModelState.IsValid)
            {
                var createdBlog = await blogService.CreateBlogAsync(blog);
                TempData["Success"] = "Blog Created Successfully";
                return RedirectToAction(nameof(Index), new { id = createdBlog.Id });
            }

            return View(blog);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var blog = await blogService.GetBlogByIdAsync(id);
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Models.Blog blog)
        {
            if (ModelState.IsValid)
            {
                await blogService.UpdateBlogAsync(id, blog);
                TempData["Success"] = "Blog Updated Successfully";
                return RedirectToAction(nameof(Index), new { id });
            }

            return View(blog);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var blog = await blogService.GetBlogByIdAsync(id);
            return View(blog);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await blogService.DeleteBlogAsync(id);
          TempData["Success"] = "Blog Deletedd Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
