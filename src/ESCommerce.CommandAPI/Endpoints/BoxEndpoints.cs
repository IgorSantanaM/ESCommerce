using ESCommerce.CommandAPI.Endpoints.Internal;
using ESCommerce.Domain;
using ESCommerce.Domain.Boxes.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ESCommerce.CommandAPI.Endpoints
{
    public class BoxEndpoints : IEndpoints
    {
        public static void DefineEndpoints(WebApplication app)
        {
            var group = app.MapGroup("/api/box/commands");

            group.MapPost("/create", HandleCreateBox);

            group.MapPost("/add-product", HandleAddProduct);

            group.MapPost("/add-shipping-label", HandleAddShippingLabel);
            group.MapPost("/close-box", HandleCloseBox);
            group.MapPost("/send-box", HandleSendBox);
        }

        #region

        public async static Task<IResult> HandleCreateBox([FromBody] CreateBoxCommand command, [FromServices] CommandRouter router)
        {
            await router.HandleCommand(command);

            return Results.Accepted();
        }

        public async static Task<IResult> HandleAddProduct([FromBody] AddProductCommand command, [FromServices] CommandRouter router)
        {
            await router.HandleCommand(command);

            return Results.Accepted();
        }

        public async static Task<IResult> HandleAddShippingLabel([FromBody] AddShippingLabelCommand command, [FromServices] CommandRouter router)
        {
            await router.HandleCommand(command);

            return Results.Accepted();
        }

        public async static Task<IResult> HandleCloseBox([FromBody] CloseBoxCommand command, [FromServices] CommandRouter router)
        {
            await router.HandleCommand(command);

            return Results.Accepted();
        }

        public async static Task<IResult> HandleSendBox([FromBody] SendBoxCommand command, [FromServices] CommandRouter router)
        {
            await router.HandleCommand(command);

            return Results.Accepted();
        }
        #endregion
    }
}
