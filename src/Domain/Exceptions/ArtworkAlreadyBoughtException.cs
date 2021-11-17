namespace Domain.Exceptions
{
    public sealed class ArtworkAlreadyBoughtException : DomainException
    {
        public ArtworkAlreadyBoughtException() : base("Artwork is already sold.") { }
    }
}
