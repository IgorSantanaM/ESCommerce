
using System.Reflection;

namespace ESCommerce.QueryAPI.Endpoints.Internal
{
    public static class EndpointsExtensions
    {
        public static void UseEndpoints<TMarker>(this IApplicationBuilder app)
        {
            UseEndpoints(app, typeof(TMarker));
        }

        private static void UseEndpoints(IApplicationBuilder app, Type type)
        {
            IEnumerable<TypeInfo> endpointTypes = GetEndpointTypesByAssemblyContaining(type);

            foreach (TypeInfo typeInfo in endpointTypes)
            {
                typeInfo.GetMethod(nameof(IEndpoints.DefineEndpoints))?.Invoke(null, [app]);
            }
        }

        private static IEnumerable<TypeInfo> GetEndpointTypesByAssemblyContaining(Type typeMarker)
            => typeMarker.Assembly.DefinedTypes.Where(x => !x.IsAbstract && !x.IsInterface && typeof(IEndpoints).IsAssignableFrom(x));
    }
}
