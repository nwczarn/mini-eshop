namespace Storefront.Endpoints;

public static class StorefrontEndpoints
{
    public static void MapStorefrontEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Storefront works");
    }
}