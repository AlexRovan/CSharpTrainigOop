using System.Collections.Generic;

namespace JsonTask
{
    public class CurrencyComparer : IEqualityComparer<Currency>
    {
        public bool Equals(Currency currency1, Currency currency2)
        {
            return Equals(currency2.Code, currency1.Code) && Equals(currency1.Name, currency2.Name);
        }

        public int GetHashCode(Currency currency)
        {
            const int prime = 37;
            var hash = 1;

            hash = prime * hash + (currency.Name == null ? 0 : currency.Name.GetHashCode());
            hash = prime * hash + (currency.Code == null ? 0 : currency.Code.GetHashCode());
            hash = prime * hash + (currency.Symbol == null ? 0 : currency.Symbol.GetHashCode());

            return hash;
        }
    }
}