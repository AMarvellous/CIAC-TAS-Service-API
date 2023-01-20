using System.ComponentModel.DataAnnotations;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class UserRegistrationRequest
    {
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
