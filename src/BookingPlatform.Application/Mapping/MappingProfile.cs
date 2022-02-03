using AutoMapper;
using System.Reflection;

namespace BookingPlatform.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMap<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var mapFromMethodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMap`1").GetMethod("MapFromEntity");

                mapFromMethodInfo?.Invoke(instance, new object[] { this });

                var mapToMethodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMap`1").GetMethod("MapToEntity");

                mapToMethodInfo?.Invoke(instance, new object[] { this });
            }

        }
    }
}
