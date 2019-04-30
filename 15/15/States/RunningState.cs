using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.States
{
    using Commands;
    class RunningState : IState
    {
        public RunningState()
        {
            new RunCommand().Execute();
        }

        public void HandleInput(Hero hero, char input)
        {
            if (input == 'a')
                hero.State = new StandingState();
            else if (input == 'w')
                hero.State = new JumpingState();
        }

        public void Update(Hero hero)
        {
            throw new NotImplementedException();
        }
    }
}
