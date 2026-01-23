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

            group.MapGet("/", HandleGetAllProducts);

            group.MapGet("/{productId:guid}/sequence/{sequence:int}", HandleGetProductBySequence);
        }

        

        #region Handlers

        private async static Task<IResult> HandleGetProductById([FromRoute] Guid productId, [FromServices] IDocumentStore store)
        {
            await using var session = store.QuerySession();

            var product = await session.Events.AggregateStreamAsync<Product>(productId);
            if(product is null)
                return Results.NotFound(productId);

            return Results.Ok(product);
        }

        private async static Task<IResult> HandleGetAllProducts([FromServices] IDocumentStore store)
        {
            await using var session = store.QuerySession();

            var products = session.Query<Product>();

            return Results.Ok(products);
        }

        private async static Task<IResult> HandleGetProductBySequence([FromRoute] int sequence,[FromRoute] Guid productId, [FromServices] IDocumentStore store)
        {
            await using var session = store.QuerySession();

            var product = session.Events.AggregateStreamAsync<Product>(productId, version: sequence);  
            
            return Results.Ok(product);    
        }

        #endregion
    }
}
