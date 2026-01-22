
using System.Reflection;

namespace ESCommerce.CommandAPI.Endpoints.Internal
{
    public static class EndpointsExtensions
    {
        public static void UseEndpoints<TMarker>(this WebApplication app)
        {
            UseEndpoints(app, typeof(TMarker));
        }

        private static void UseEndpoints(WebApplication app, Type type)
        {
            IEnumerable<TypeInfo> endpointTypes = GetEndpointsFromAssemblyContaining(type);

            foreach(TypeInfo typeInfo in endpointTypes)
            {
                typeInfo.GetMethod(nameof(IEndpoints.DefineEndpoints))?.Invoke(null, [app]);
            }
        }

        private static IEnumerable<TypeInfo> GetEndpointsFromAssemblyContaining(Type typeMarker)
            => typeMarker.Assembly.DefinedTypes.Where(x => !x.IsAbstract && !x.IsInterface && typeof(IEndpoints).IsAssignableFrom(x));
    }
}
