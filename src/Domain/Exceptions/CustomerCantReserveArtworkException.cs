namespace Domain.Exceptions
{
    public sealed class CustomerCantReserveArtworkException : DomainException
    {
        public CustomerCantReserveArtworkException() : base("Only VIP clients can reserve an artwork.")
        {
        }
    }
}
