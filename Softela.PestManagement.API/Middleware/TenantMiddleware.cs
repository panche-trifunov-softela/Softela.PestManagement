using System.Security.Claims;

namespace Softela.PestManagement.API.Middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, TenantContext tenantContext)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var tenantIdClaim = context.User.FindFirst("tenant_id")?.Value;
            if (int.TryParse(tenantIdClaim, out var tenantId))
            {
                tenantContext.TenantId = tenantId;
            }
            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Missing tenant_id claim");
                return;
            }

            var subClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? context.User.FindFirst("sub")?.Value;
            if (Guid.TryParse(subClaim, out var userId))
            {
                tenantContext.UserId = userId;
            }
        }

        await _next(context);
    }
}
