using Api.Data.Models;
using Api.Dtos;
using AutoMapper;

namespace Api.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Rating, opt => opt.Ignore());

        CreateMap<Product, ProductDto>();
    }
}
