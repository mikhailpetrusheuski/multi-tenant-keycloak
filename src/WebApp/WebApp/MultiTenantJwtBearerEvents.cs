using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApp;

public class MultiTenantJwtBearerEvents : JwtBearerEvents
{
    public override Task MessageReceived(MessageReceivedContext context)
    {
        var host = context.Request.Host.Host.ToLower();

        var tenantKey = host.Contains("tenantb") ? "tenantB" : "tenantA";

        if (MultiTenantAuthOptions.TenantSettings.TryGetValue(tenantKey, out var cfg))
        {
            context.Options.Authority = cfg.AuthorityUrl;
            context.Options.TokenValidationParameters.ValidAudience = cfg.ClientId;
        }

        return base.MessageReceived(context);
    }
}