using AutoMapper;
using System.Reflection;

namespace Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFrom(Assembly.GetExecutingAssembly());
        ApplyMappingsTo(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFrom(Assembly assembly)
    {
        ApplyMappings(assembly, typeof(IMapFrom<>), nameof(IMapFrom<object>.MappingFrom));
    }

    private void ApplyMappingsTo(Assembly assembly)
    {
        ApplyMappings(assembly, typeof(IMapTo<>), nameof(IMapTo<object>.MappingTo));
    }

    private void ApplyMappings(Assembly assembly, Type interfaceType, string methodName)
    {
        var types = assembly.GetExportedTypes()
           .Where(t => t.GetInterfaces().Any(i =>
               i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType))
           .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var mappingMethod = type.GetMethod(methodName)
                             ?? type.GetInterface(interfaceType.Name)?.GetMethod(methodName);

            mappingMethod?.Invoke(instance, [this]);
        }
    }
}
