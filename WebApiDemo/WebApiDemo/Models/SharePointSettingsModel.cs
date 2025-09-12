namespace SharePoint.Models
{
    public class SharePointSettingsModel
    {
        public string? ClientId { get; set; }
        public string? TenantId { get; set; }
        public string? Secret { get; set; }
        public string? SharePointUrl { get; set; }
        public string? SPUser { get; set; }
        public string? SPPD { get; set; }
        public SPCertificateSetting? Certificate { get; set; }
        public SPAuthType AuthenticationType { get; set; } = SPAuthType.Certificate;
    }

    public class SPCertificateSetting
    {
        public string? PfxBase64 { get; set; }
        public string? Password { get; set; }
    }

    public enum SPAuthType
    {
        Credential = 0,
        Certificate = 1
    }
}
