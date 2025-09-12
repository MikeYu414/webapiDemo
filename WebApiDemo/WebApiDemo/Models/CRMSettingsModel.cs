namespace DynamicsCRM.Models
{
    public class CRMSettingsModel
    {
        public string? CRMUrl { get; set; }
        public string? ClientId { get; set; } = "51f81489-12ee-4a9e-aaae-a2591f45987d";
        public string? Secret { get; set; }
        public string? TenantId { get; set; }
        public string? CRMUser { get; set; }
        public string? CRMPD { get; set; }
        public CRMCertificateSetting? Certificate { get; set; }
        public string? RedirectUrl { get; set; } = "app://58145B91-0C36-4500-8554-080854F2AC97";
        public string? AuthenticationType { get; set; }
    }

    public class CRMCertificateSetting
    {
        public string? PfxBase64 { get; set; }
        public string? Password { get; set; }
    }
}
