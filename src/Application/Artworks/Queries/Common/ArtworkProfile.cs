using AutoMapper;
using Domain.Entities;

namespace Application.Artworks.Queries.Common
{
    public class ArtworkProfile : Profile
    {
        public ArtworkProfile()
        {
            CreateMap<Artwork, ArtworkDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.ToString()))
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.IsReserved, opt => opt.MapFrom(src => src.ReservationCustomerId != null))
                .ForMember(dest => dest.IsSold, opt => opt.MapFrom(src => src.BoughtByCustomerId != null));
        }
    }
}
