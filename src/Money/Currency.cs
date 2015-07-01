
namespace Money
{
    using System;

    public struct Currency : IEquatable<Currency>
    {
        #region Currencies

        public static readonly Currency USD = new Currency("USD", 840, 2, "United States Dollar", true);

        public static readonly Currency SEK = new Currency("SEK", 752, 2, "Swedish krona", true);

        #endregion

        public readonly string IsoCode;

        public readonly int IsoNumber;

        public readonly byte SignificantDecimalDigits;

        public readonly string Name;

        public readonly bool IsActive;

        public Currency(string isoCode, int isoNumber, byte significantDecimalDigits, string name, bool isActive)
        {
            IsoCode = isoCode;
            IsoNumber = isoNumber;
            SignificantDecimalDigits = significantDecimalDigits;
            Name = name;
            IsActive = isActive;
        }

        public override bool Equals(object obj)
        {
            return obj is Currency && Equals((Currency)obj);
        }

        public bool Equals(Currency other)
        {
            return this.IsoCode.Equals(other.IsoCode);
        }

        public override int GetHashCode()
        {
            return IsoCode.GetHashCode();
        }

        public static bool operator ==(Currency left, Currency right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Currency left, Currency right)
        {
            return !Equals(left, right);
        }
    }
}