using CIAC_TAS_Service.Contracts.V1.Requests.Queries;

namespace CIAC_TAS_Service.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);

        Uri GetAllPostUri(PaginationQuery pagination = null);
    }
}
