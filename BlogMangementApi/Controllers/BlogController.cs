using Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.Data;

namespace BlogMangementApi.Controllers
{
    [ApiController]
    [Route("/api/Blog")]
    public class BlogController : ControllerBase
    {
       


        private readonly IBlogRepository blogRepo;

        public BlogController(IBlogRepository _blogRepo)
        {
            blogRepo= _blogRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Blog> blog = blogRepo.GetAll().ToList();
            return Ok(blog);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            var blog = blogRepo.Get(u => u.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Blog blog)
        {
            blogRepo.Add(blog);
            blogRepo.Save();
            return CreatedAtAction(nameof(GetById), new { id = blog.Id }, blog);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Blog blog)
        {
            // Blog blog = _blogRepository.Get(u => u.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            // Perform update logic, e.g., update existingUser properties based on updatedUser
            // Blog model = _mapper.Map<Blog>(blogDTO);
            blogRepo.Update(blog);
            blogRepo.Save();
            return Ok(blog);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            Blog blog = blogRepo.Get(u => u.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            blogRepo.Remove(blog);
            blogRepo.Save();

            return NoContent();
        }
    }
}
    
