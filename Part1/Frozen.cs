using System;
using System.Collections.Generic;
using System.Text;

namespace Part1
{
    class Frozen : IAccountState
    {
        private Action onUnFreeze { get; }
        public Frozen(Action onUnfreeze)
        {
            this.onUnFreeze = onUnFreeze;
        }
        public IAccountState Deposit(Action addToBalance)
        {
            this.onUnFreeze();
            addToBalance();
            return new Active(this.onUnFreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.onUnFreeze();
            subtractFromBalance();
            return new Active(this.onUnFreeze);
        }

        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}
