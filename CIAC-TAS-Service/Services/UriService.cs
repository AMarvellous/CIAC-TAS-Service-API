using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using Microsoft.AspNetCore.WebUtilities;

namespace CIAC_TAS_Service.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllPostUri(PaginationQuery pagination = null)
        {
            var uri = new Uri(_baseUri);

            if (pagination == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(uri.ToString(), "pageNumber", pagination.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pagination.PageSize.ToString());

            return new Uri(modifiedUri);
        }

        public Uri GetPostUri(string postId)
        {
            return new Uri(_baseUri + ApiRoute.Posts.Get.Replace("{postId}", postId));          
        }
    }
}
