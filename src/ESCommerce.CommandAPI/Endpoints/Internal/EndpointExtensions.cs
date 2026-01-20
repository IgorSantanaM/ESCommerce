using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace ESCommerce.CommandAPI.Endpoints.Internal
{
    public static class EndpointExtensions
    {
        public static void UseEndpoints<TMarker>(this IApplicationBuilder app) =>
            UseEndpoints(app, typeof(TMarker));

        private static void UseEndpoints(this IApplicationBuilder app, Type serviceType)
        {
            IEnumerable<TypeInfo> endpointType = GetEndpointsTypesFromAssemblyContaining(serviceType);

            foreach (TypeInfo typeInfo in endpointType)
                typeInfo.GetMethod(nameof(IEndpoints.DefineEndpoints))?.Invoke(null, [app]);
        }
        private static IEnumerable<TypeInfo> GetEndpointsTypesFromAssemblyContaining(Type typeMarker) =>
            typeMarker.Assembly.DefinedTypes.Where(x => !x.IsAbstract && !x.IsInterface && typeof(IEndpoints).IsAssignableFrom(x));
    }
}
