using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.HealthChecks;

namespace CIAC_TAS_Service.Installers
{
    public class HealthcheckInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<DataContext>()
                .AddCheck<RedisHealthCheck>("Redis");
        }
    }
}
