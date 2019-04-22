using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class PostRepository : IRepository<Posts>
    {
        Model1Container context;

        public PostRepository(Model1Container context)
        {
            this.context = context;
        }

        public void Add(Posts entity)
        {
            context.Posts.Add(entity);
        }

        public List<Posts> Get(Func<Posts, bool> where)
        {
            return context.Posts.Select(p => p).Where(where).ToList();
        }

        public List<Posts> GetAll()
        {
            return context.Posts.Select(p => p).ToList();
        }

        public void Remove(Posts entity)
        {
            context.Posts.Remove(entity);
        }
    }
}
