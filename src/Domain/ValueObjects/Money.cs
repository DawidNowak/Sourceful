using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public readonly decimal Amount;
        [Required]
        public readonly Currency Currency;

        //EF ctor
        private Money()
        { }

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

        public override string ToString() => $"{Amount} {Currency.Symbol}";
    }
}
