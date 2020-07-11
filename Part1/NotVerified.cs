using System;
using System.Collections.Generic;
using System.Text;

namespace Part1
{
    class NotVerified:IAccountState
    {
        public NotVerified(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }
        public Action OnUnfreeze { get;  }
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(this.OnUnfreeze);

        public IAccountState Close() => new Closed();
    }
}
