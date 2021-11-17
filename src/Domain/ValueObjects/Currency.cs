using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class Currency : ValueObject
    {
        private readonly CurrencyRepository _repo = new();

        public readonly string IsoCode;
        public readonly string Symbol;

        private Currency(string isoCode, string symbol)
        {
            IsoCode = isoCode;
            Symbol = symbol;
        }

        public Currency(string isoCode)
        {
            var curr = _repo.Get(isoCode);
            if (curr.Equals(Empty))
            {
                throw new ArgumentException("Invalid ISO Currency Code");
            }

            IsoCode = curr.IsoCode;
            Symbol = curr.Symbol;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IsoCode;
            yield return Symbol;
        }

        public static Currency Empty => new(string.Empty, string.Empty);

        internal class CurrencyRepository
        {
            private static readonly Dictionary<string, Currency> Currencies = new()
            {
                { "PLN", new("PLN", "zł") },
                { "USD", new("USD", "$") },
                { "EUR", new("EUR", "€") }
            };

            public Currency Get(string isoCode)
            {
                return string.IsNullOrWhiteSpace(isoCode) == false
                    && Currencies.TryGetValue(isoCode, out var curr) ? curr : Empty;
            }
        }
    }


}
