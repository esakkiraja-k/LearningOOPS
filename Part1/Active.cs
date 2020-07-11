using System;
using System.Collections.Generic;
using System.Text;

namespace Part1
{
    class Active : IFreezable
    {
        public Active()
        {

        }
        public Action OnUnfreeze { get; set; }
        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit() => this;

        public IFreezable Freeze() => new Frozen(this.OnUnfreeze);

        public IFreezable Withdraw() => this;
    }
}
