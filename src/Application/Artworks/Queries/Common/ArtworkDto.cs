namespace Application.Artworks.Queries.Common
{
    public class ArtworkDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Creator { get; set; }
        public int? Created { get; set; }
        public bool IsReserved { get; set; }
        public bool IsSold { get; set; }
    }
}
