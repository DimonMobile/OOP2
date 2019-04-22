using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class DBController : IDisposable
    {
        private Model1Container context;

        private PostRepository posts;
        private UserRepository users;

        public void Dispose()
        {
            context.SaveChanges();
        }

        public DBController()
        {
            context = new Model1Container();
        }

        public PostRepository PostRepository()
        {
            if (posts == null)
                posts = new PostRepository(context);
            return posts;
        }

        public UserRepository UserRepository()
        {
            if (users == null)
                users = new UserRepository(context);
            return users;
        }
    }
}
