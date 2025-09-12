namespace Integration.Web.Configurations
{
    public class IRASAuthSettings
    {
        public string? AuthEndpoint { get; set; }
        public string? TokenEndpoint { get; set; }
        public string? ClientId { get; set; }
        public string? Secret { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Scope { get; set; }
        public string? GrantType { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
