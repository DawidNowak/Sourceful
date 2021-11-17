namespace Domain.Exceptions
{
    public sealed class ArtworkAlreadyReservedByCustomerException : DomainException
    {
        public ArtworkAlreadyReservedByCustomerException() : base("Artwork is already reserved by you.")
        {
        }
    }
}
