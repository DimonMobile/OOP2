using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    interface IComponent
    {
        string Title { get; set; }
        void Draw();
        IComponent Find(string title);
    }
}
