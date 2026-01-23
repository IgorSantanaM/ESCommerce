using ESCommerce.QueryAPI.Endpoints.Internal;
using Marten;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ESCommerce.QueryAPI.Endpoints
{
    public class BoxEndpoints : IEndpoints
    {
        public static void DefineEndpoints(WebApplication app)
        {
            var group = app.MapGroup("/api/boxes/query");

        }

        #region Handlers

        //private async Task<IResult> HandleGetBoxById([FromRoute] Guid boxId, [FromServices] IDocumentStore store)
        //{

        //}

        #endregion
    }
}
