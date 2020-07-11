using System;
using System.Collections.Generic;
using System.Text;

namespace Part1
{
    class Frozen : IFreezable
    {
        private Action onUnFreeze { get; }
        public Frozen(Action onUnfreeze)
        {
            this.onUnFreeze = onUnFreeze;
        }
        public IFreezable Deposit()
        {
            this.onUnFreeze();
            return new Active();
        }

        public IFreezable Freeze() => this;
      
        public IFreezable Withdraw()
        {
            this.onUnFreeze();
            return new Active();
        }
    }
}
