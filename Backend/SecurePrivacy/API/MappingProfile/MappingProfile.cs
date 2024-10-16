using API.DTO;
using AutoMapper;
using Model.Models;

namespace API.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<ProductDto, Product>();
        }
    }
}
