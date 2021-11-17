namespace Domain.Exceptions
{
    public sealed class ArtworkAlreadyBoughtByCustomerException : DomainException
    {
        public ArtworkAlreadyBoughtByCustomerException() : base("Artwork already bought by you.")
        {
        }
    }
}
