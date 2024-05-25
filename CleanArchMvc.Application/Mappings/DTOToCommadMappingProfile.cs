using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOToCommadMappingProfile : Profile
    {
        public DTOToCommadMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
        }
    }
}
