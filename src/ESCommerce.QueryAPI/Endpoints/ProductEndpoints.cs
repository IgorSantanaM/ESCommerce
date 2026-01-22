using ESCommerce.Domain.Boxes;
using ESCommerce.Domain.Products;
using ESCommerce.QueryAPI.DTOs;
using ESCommerce.QueryAPI.Endpoints.Internal;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace ESCommerce.QueryAPI.Endpoints
{
    public class ProductEndpoints : IEndpoints
    {
        public static void DefineEndpoints(WebApplication app)
        {
            var group = app.MapGroup("/api/products/query");

            group.MapGet("/{productId:guid}", HandleGetProductById);
        }

        #region Handlers

        private async static Task<IResult> HandleGetProductById([FromRoute] Guid productId, [FromServices] IDocumentStore store)
        {
            await using var session = store.QuerySession();

            var product = await session.Events.AggregateStreamAsync<Product>(productId);
            return Results.Ok(product);
        }
        #endregion
    }
}
