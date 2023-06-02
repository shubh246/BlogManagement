using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IBlogRepository:IRepository<Models.Blog>
    {
      void Update(Models.Blog blog);   
    }
}
