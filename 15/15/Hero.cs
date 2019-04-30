using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    using States;
    class Hero
    {
        public IState State { get; set; }

        public void HandleInput(char input)
        {
            State.HandleInput(this, input);
        }

        public Hero()
        {
            State = new StandingState();
        }
    }
}
