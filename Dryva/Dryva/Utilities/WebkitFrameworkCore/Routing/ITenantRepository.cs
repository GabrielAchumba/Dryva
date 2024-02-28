namespace WebKitFrameworkCore.Routing
{
    public interface ITenantRepository
    {
        Tenant GetOrAdd(string tenantName);
    }

}

