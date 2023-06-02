using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagementWeb.Controllers
{
    [ApiController]
    [Route("/api/Admin")]
    public class AdminController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        public AdminController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;

        }
        [HttpGet]
        public IActionResult GetAllNoActionTakenBlogs()
        {
            IEnumerable<Models.Blog> blog = _blogRepository.GetAll(b => b.IsApproved == false && b.IsRejected == false);
            if (blog == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(blog);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult ApprovedBlog(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }

            Models.Blog blog = _blogRepository.Get(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();

            }
            blog.IsApproved = true;
            _blogRepository.Save();
            return Ok(blog);
        }
        [HttpPut("{id}")]
        public IActionResult RejectBlog(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }

           Models. Blog blog = _blogRepository.Get(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();

            }
            blog.IsRejected = true;
            _blogRepository.Save();
            return Ok(blog);
        }
    }
}
