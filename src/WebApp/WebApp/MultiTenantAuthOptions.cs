namespace WebApp;

public class TenantConfig
{
    public string RealmName { get; set; } = string.Empty;
    public string AuthorityUrl { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}

public static class MultiTenantAuthOptions
{
    public static Dictionary<string, TenantConfig> TenantSettings { get; } = new()
    {
        ["tenantA"] = new TenantConfig
        {
            RealmName = "tenantA",
            AuthorityUrl = "http://localhost:8080/realms/tenantA",
            ClientId = "admin_portal",
            ClientSecret = "SECRET_A"
        },
        ["tenantB"] = new TenantConfig
        {
            RealmName = "tenantB",
            AuthorityUrl = "http://localhost:8080/realms/tenantB",
            ClientId = "dist_portal",
            ClientSecret = "SECRET_B"
        }
    };
}