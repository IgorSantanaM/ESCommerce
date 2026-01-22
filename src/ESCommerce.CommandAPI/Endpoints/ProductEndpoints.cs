using ESCommerce.CommandAPI.Endpoints.Internal;
using ESCommerce.Domain;
using ESCommerce.Domain.Products.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ESCommerce.CommandAPI.Endpoints
{
    public class ProductEndpoints : IEndpoints
    {
        public static void DefineEndpoints(WebApplication app)
        {
            var group = app.MapGroup("/api/products/commands");

            group.MapPost("/create-product", HandleCreateProduct);

            group.MapPost("/add-variation", HandleAddVariationCommand);

            group.MapPost("/attach-image", HandleAttachImage);
        }

        #region Handlers

        private static async Task<IResult> HandleCreateProduct([FromBody] CreateProductCommand command, [FromServices] CommandRouter router)
        {
            await router.HandleCommand(command);

            return Results.Accepted();
        }

        private static async Task<IResult> HandleAddVariationCommand([FromBody] AddVariationCommand command, [FromServices] CommandRouter router)
        {
            await router.HandleCommand(command);

            return Results.Accepted();
        }

        private static async Task<IResult> HandleAttachImage([FromBody] AttachImageCommand command, [FromServices] CommandRouter router)
        {
            await router.HandleCommand(command);

            return Results.Accepted();
        }

        #endregion
    }
}
