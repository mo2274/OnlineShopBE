using AutoMapper;
using OnlineSystem.Core.Entities;
using OnlineSystem.Core.Requests;

namespace OnlineSystem.Core.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductPayload, Product>()
            .ForMember(x => x.Name, 
                op => op.MapFrom(y => y.Name))
            .ForMember(x => x.NameAr, 
                op => op.MapFrom(y => y.NameAr))
            .ForMember(x => x.Description, 
                op => op.MapFrom(y => y.Description))
            .ForMember(x => x.Price, op => 
                op.MapFrom(y => y.Price))
            .ForMember(x => x.HasAvailableStock, 
                op => op.MapFrom(y => y.HasAvailableStock))
            .ForMember(x => x.Categories, 
                op => op.Ignore())
            .ForMember(x => x.ImageUrl, 
                op => op.Ignore())
            .ReverseMap();
        
    }
}