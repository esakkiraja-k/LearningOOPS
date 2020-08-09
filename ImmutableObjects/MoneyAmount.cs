using System;

namespace ImmutableObjects
{
   sealed class MoneyAmount :IEquatable<MoneyAmount>
    {
        public MoneyAmount(decimal amount, string currencySymbol)
        {
            this.Amount = amount;
            this.CurrencySymbol = currencySymbol;

        }
        public decimal Amount { get;  }
        public string CurrencySymbol { get; }

        public MoneyAmount Scale(decimal factor) =>
            new MoneyAmount(this.Amount * factor, "USD");
        public override string ToString()
        {
            return $"{this.Amount} {this.CurrencySymbol}";
        }

        public override bool Equals(object obj) => this.Equals(obj as MoneyAmount);

        public override int GetHashCode() => this.Amount.GetHashCode() ^ this.CurrencySymbol.GetHashCode();
        public bool Equals(MoneyAmount other) =>
            other != null &&
            this.Amount == other.Amount &&
            this.CurrencySymbol == other.CurrencySymbol;

        public static bool operator ==(MoneyAmount a, MoneyAmount b) =>
            (Object.ReferenceEquals(a,null) && Object.ReferenceEquals(b,null)) || 
            (!Object.ReferenceEquals(a,null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b) => !(a == b);


        public static MoneyAmount operator *(MoneyAmount amount, decimal factor) => amount.Scale(factor);
    }
}
