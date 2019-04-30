using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    public sealed class Settings
    {
        public static readonly Settings instance = new Settings();
        static Settings() { }
        private Settings() { }
        public int GetDefaultWidth()
        {
            return 100;
        }
        public int GetDefaultHeight()
        {
            return 100;
        }
        public static Settings Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
