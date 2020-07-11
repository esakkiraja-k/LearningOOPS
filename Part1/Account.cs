using System;
using System.Collections.Generic;
using System.Text;

namespace Part1
{
    class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        public bool IsClosed { get; set; }


        public IFreezable Freezable { get; set; }

        public Account(Action onunFreeze)
        {
            this.Freezable = new Active(onunFreeze);
        }

        public void deposit(decimal amount)
        {
            if (this.IsClosed)
                return;

            this.Freezable = this.Freezable.Deposit();
            this.Balance += amount;
        }
        public void WithDraw(decimal amount)
        {
            if (!this.IsVerified)
                return;

            if (this.IsClosed)
                return;
            this.Freezable = this.Freezable.Deposit();
            this.Balance -= amount;

        }

   
        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)//act shd not be closed
                return;
            if (!this.IsVerified)//act must be verified
                return;
            this.Freezable = this.Freezable.Freeze();
        }
    }
}
