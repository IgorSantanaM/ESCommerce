using ESCommerce.Domain.Boxes;
using ESCommerce.Domain.Boxes.Projections;
using ESCommerce.QueryAPI.Endpoints.Internal;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace ESCommerce.QueryAPI.Endpoints
{
    public class BoxEndpoints : IEndpoints
    {
        public static void DefineEndpoints(WebApplication app)
        {
            var group = app.MapGroup("/api/boxes/query");

            group.MapGet("/{boxId:guid}", HandleGetBoxById);

            group.MapGet("/", HandleGetAllBoxes);

            group.MapGet("/{boxId:guid}/version/{version:int}", HandleGetBoxByVersion);

            group.MapGet("/unsent/{boxId:guid}", HandleGetUnsentBoxById);

            group.MapGet("/open/{boxId:guid}", HandleGetOpenBoxById);
        }

        #region Handlers

        private static async Task<IResult> HandleGetBoxById([FromRoute] Guid boxId, [FromServices] IDocumentStore store)
        {
            await using var session = store.QuerySession();

            var box = session.Events.AggregateStreamAsync<Box>(boxId);

            if (box is null)
                return Results.NotFound();

            return Results.Ok(box);
        }


        private static async Task<IResult> HandleGetAllBoxes([FromServices] IDocumentStore store)
        {
            await using var session = store.QuerySession();

            var boxes = session.Query<Box>();

            return Results.Ok(boxes);
        }

        private static async Task<IResult> HandleGetBoxByVersion([FromRoute] Guid boxId, [FromRoute] int version, [FromServices] IDocumentStore store)
        {
            if (version <= 0)
                return Results.BadRequest();

            await using var session = store.QuerySession();

            var box = session.Events.AggregateStreamAsync<Box>(boxId, version: version);

            if (box is null)
                return Results.NotFound();

            return Results.Ok(box);
        }

        private static async Task<IResult> HandleGetUnsentBoxById([FromRoute] Guid boxId, [FromServices] IDocumentStore store)
        {
            await using var session = store.QuerySession();

            var unsentBox = session.Events.AggregateStreamAsync<UnSentBox>(boxId);

            if(unsentBox is null)
                return Results.NotFound();

            return Results.Ok(unsentBox);
        }

        private static async Task<IResult> HandleGetOpenBoxById([FromRoute] Guid boxId, [FromServices] IDocumentStore store)
        {
            await using var session = store.QuerySession();

            var openBox = session.Events.AggregateStreamAsync<OpenBox>(boxId);

            return Results.Ok(openBox);
        }
        #endregion
    }
}
