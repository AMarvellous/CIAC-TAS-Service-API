using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Post, PostResponse>()
                .ForMember(dest => dest.Tags,
                opt => opt.MapFrom(
                    src => src.Tags.Select(x => new TagResponse
                    {
                        Name = x.Name
                    }))
                );

            CreateMap<Tag, TagResponse>();
        }
    }
}
