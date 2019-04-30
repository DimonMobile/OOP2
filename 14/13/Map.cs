using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    class Map : IComponent
    {
        public string Title { get; set; }
        private readonly List<IComponent> m_map = new List<IComponent>();

        public void Draw()
        {
            Console.WriteLine("Draw");
        }

        public IComponent Find(string title)
        {
            foreach (var component in m_map)
                if (component.Title == title)
                    return component;
            return null;
        }
    }
}
