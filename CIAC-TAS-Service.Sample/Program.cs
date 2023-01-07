using CIAC_TAS_Service.Sdk;
using Refit;

namespace CIAC_TAS_Service.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cachedToken = string.Empty;
            var identityApi = RestService.For<IIdentityApi>("https://localhost:5001");
            var ciacTasServiceApi = RestService.For<ICIACTASServiceApi>("https://localhost:5001",
                new RefitSettings
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
                });

            var registerResponse = await identityApi.RegisterAsync(new Contracts.V1.Requests.UserRegistrationRequest
            {
                Email = "sdkaccount@example.com",
                Password = "Abc12345!"
            });

            var loginResponse = await identityApi.LoginAsync(new Contracts.V1.Requests.UserLoginRequest
            {
                Email = "sdkaccount@example.com",
                Password = "Abc12345!"
            });

            cachedToken = loginResponse.Content.Token;

            var allPosts = await ciacTasServiceApi.GetAllAsync();
            var createdPost = await ciacTasServiceApi.CreateAsync(new Contracts.V1.Requests.CreatePostRequest
            {
                Name = "sdkName",
                Tags = new List<string> { "sdkTag", "sdk2Tag" }
            });
        }
    }
}