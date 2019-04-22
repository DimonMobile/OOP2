using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class UserRepository : IRepository<Users>
    {
        Model1Container context;

        public UserRepository(Model1Container context)
        {
            this.context = context;
        }

        public void Add(Users entity)
        {
            context.Users.Add(entity);
        }

        public List<Users> Get(Func<Users, bool> where)
        {
            return context.Users.Select(p => p).Where(where).ToList();
        }

        public List<Users> GetAll()
        {
            return context.Users.Select(p => p).ToList();
        }

        public void Remove(Users entity)
        {
            context.Users.Remove(entity);
        }
    }
}
