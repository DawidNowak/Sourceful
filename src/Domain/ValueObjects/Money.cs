using Domain.Common;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public readonly decimal Amount;
        public readonly Currency Currency;

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        public override string ToString() => $"{Amount}, {Currency.Symbol}";
    }
}
