namespace Domain.Exceptions
{
    public sealed class ArtworkAlreadyReservedException : DomainException
    {
        public ArtworkAlreadyReservedException() : base("Artwork already reserved.")
        {
        }
    }
}
