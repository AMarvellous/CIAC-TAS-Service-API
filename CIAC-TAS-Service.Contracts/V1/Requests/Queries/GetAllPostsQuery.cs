using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests.Queries
{
    public class GetAllPostsQuery
    {
        //[FromQuery(Name = "userId")]
        public string UserId { get; set; }
    }
}
