using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.States
{
    using Commands;
    class JumpingState : IState
    {
        public JumpingState()
        {
            new JumpCommand().Execute();
        }

        public void HandleInput(Hero hero, char input)
        {
            if (input == 's')
                hero.State = new StandingState();
        }

        public void Update(Hero hero)
        {
            throw new NotImplementedException();
        }
    }
}
