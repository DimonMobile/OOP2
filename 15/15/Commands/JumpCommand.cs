using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Commands
{
    class JumpCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("JUMP");
        }
    }
}
