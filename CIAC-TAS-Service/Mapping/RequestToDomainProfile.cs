using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Mapping
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<GetAllPostsQuery, GetAllPostsFilter>();
        }
    }
}
