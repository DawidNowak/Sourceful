namespace Domain.Exceptions
{
    public sealed class ArtworkNotReservedException : DomainException
    {
        public ArtworkNotReservedException() : base("Artwork is not reserved.")
        {
        }
    }
}
