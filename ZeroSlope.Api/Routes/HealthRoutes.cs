using ZeroSlope.Infrastructure.Exceptions;

namespace ZeroSlope.Api.Routes
{
    public static class HealthRoutes
    {
        private const string Tag = "Health";
        public static void useHealthRoutes(this WebApplication app)
        {

            app
                .MapGet("/api/health", [AllowAnonymous] () => {
                    return Results.NoContent();
                })
                .WithTags(Tag)
                .Produces(204)
                .Produces<HandledResponseModel>(500);
        }
    }
}
