using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money
{
    public static class DecimalExtensions
    {
        public static Money ToMoney(this decimal d, Currency currency)
        {
            return new Money(d, currency);
        }

        public static Money USD(this decimal d)
        {
            return d.ToMoney(Currency.USD);
        }

        public static Money SEK(this decimal d)
        {
            return d.ToMoney(Currency.SEK);
        }
    } 
}
