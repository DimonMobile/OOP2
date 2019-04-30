using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.States
{
    interface IState
    {
        void HandleInput(Hero hero, char input);
        void Update(Hero hero);
    }
}
