using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    using States;
    class Memento
    {
        private IState m_state;
        public Memento(IState state)
        {
            m_state = state;
        }
        public IState State
        {
            get { return m_state; }
            set { m_state = value; }
        }
    }
}
