using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.States
{
    using Commands;
    class StandingState : IState
    {
        public StandingState()
        {
            new StandCommand().Execute();
        }

        public void HandleInput(Hero hero, char input)
        {
            if (input == 'd')
                hero.State = new RunningState();
            else if (input == 'w')
                hero.State = new JumpingState();
        }

        public void Update(Hero hero)
        {
            throw new NotImplementedException();
        }
    }
}
