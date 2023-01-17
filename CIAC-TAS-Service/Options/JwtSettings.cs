namespace CIAC_TAS_Service.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int TokenDaysLifetime { get; set; }
    }
}
