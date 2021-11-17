namespace Domain.Exceptions
{
    public sealed class ArtworkReservedByOtherCustomerException : DomainException
    {
        public ArtworkReservedByOtherCustomerException() : base("Artwork is reserved by other customer.")
        {
        }
    }
}
