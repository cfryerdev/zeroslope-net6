using ZeroSlope.Domain.Services;
using ZeroSlope.Infrastructure.Exceptions;
using ZeroSlope.Models.Sample.Requests;
using ZeroSlope.Models.Sample.Responses;

namespace ZeroSlope.Api.Routes
{
    public static class SampleRoutes
    {
        private const string Tag = "Sample";

        public static void useSampleRoutes(this WebApplication app)
        {
            app.MapGet("/api/sample/", (SampleService service) =>
            {
                return Results.Ok(service.List());
            })
            .WithTags(Tag)
            .Produces<List<SampleResponse>>(200)
            .Produces<HandledResponseModel>(400)
            .Produces<HandledResponseModel>(500);

            app.MapGet("/api/sample/{id}", (int id, SampleService service) =>
            {
                return Results.Ok(service.Read(id));
            })
            .WithTags(Tag)
            .Produces<SampleResponse>(200)
            .Produces<HandledResponseModel>(400)
            .Produces<HandledResponseModel>(500);

            app.MapPost("/api/sample/", (SampleRequest request, SampleService service) =>
            {
                return Results.Ok(service.Save(request));
            })
            .WithTags(Tag)
            .Produces<SampleResponse>(200)
            .Produces<HandledResponseModel>(400)
            .Produces<HandledResponseModel>(500);

            app.MapDelete("/api/sample/{id}", (int id, SampleService service) =>
            {
                service.Delete(id);
                return Results.NoContent();
            })
            .WithTags(Tag)
            .Produces(204)
            .Produces<HandledResponseModel>(400)
            .Produces<HandledResponseModel>(500);
        }
    }
}
