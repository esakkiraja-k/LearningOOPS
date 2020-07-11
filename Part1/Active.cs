using System;
using System.Collections.Generic;
using System.Text;

namespace Part1
{
    class Active : IAccountState
    {
        public Action OnUnfreeze { get; set; }
        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState Freeze() => new Frozen(this.OnUnfreeze);
        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}
