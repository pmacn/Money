using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money
{
    public struct Money : IEquatable<Money>, IComparable<Money>
    {
        public readonly decimal Amount;

        public readonly Currency Currency;

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Amount.GetHashCode() * 72073 + Currency.GetHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Money && this.Equals((Money)obj);
        }

        public bool Equals(Money other)
        {
            return this == other;
        }

        public int CompareTo(Money other)
        {
            ThrowIfCurrencyMismatch(this, other);
            return this.Amount.CompareTo(other.Amount);
        }

        public Money Add(Money that)
        {
            ThrowIfCurrencyMismatch(this, that);
            return new Money(Amount + that.Amount, Currency);
        }

        public Money Subtract(Money that)
        {
            ThrowIfCurrencyMismatch(this, that);
            return new Money(Amount - that.Amount, Currency);
        }

        public Money Multiply(decimal multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public Money Divide(decimal denominator)
        {
            return new Money(Amount / denominator, Currency);
        }

        private static void ThrowIfCurrencyMismatch(Money source, Money target)
        {
            if (source.Currency != target.Currency)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Currency mismatch; Expected {0}; Actual: {1}",
                        source.Currency,
                        target.Currency));
            }
                
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Amount == b.Amount && a.Currency == b.Currency;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public static Money operator +(Money left, Money right)
        {
            return left.Add(right);
        }

        public static Money operator -(Money left, Money right)
        {
            return left.Subtract(right);
        }

        public static Money operator *(Money money, decimal multiplier)
        {
            return money.Multiply(multiplier);
        }

        public static Money operator /(Money money, decimal denominator)
        {
            return money.Divide(denominator);
        }
    }
}