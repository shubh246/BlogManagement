using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BlogRepository : Repository<Models.Blog>, IBlogRepository
    {
        private readonly ApplicationDbContext dbContext;
        public BlogRepository(ApplicationDbContext _dbContext):base(_dbContext)
        {
            dbContext = _dbContext;
        }
        public void Update(Models.Blog blog)
        {
            dbContext.Blogs.Update(blog);
        }
    }
}
