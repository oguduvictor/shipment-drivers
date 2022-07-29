using System.Reflection;
using System.Text.Json;
namespace Protium.Digital.Shared.Extensions;

public static class ObjectExtensions
{
    public static T Cast<T>(this object obj)
    {
        var jsonString = JsonSerializer.Serialize(obj);

        return JsonSerializer.Deserialize<T>(jsonString);
    }

    public static void CopyFromSourceToTarget<T, U>(this T target, U source, params string[] ignoreProperties)
    {
        if (target == null || source == null)
        {
            return;
        }

        // Dictionary<(Type, Type), Dictionary<PropertyInfo, PropertyInfo>> typeMatchCache = new();
        var sourceType = source.GetType();
        var targetType = target.GetType();

        // if (!typeMatchCache.TryGetValue((sourceType, targetType), out var sameProperties))
        // {
        var sourceProps = sourceType.GetProperties();
        var targetProps = targetType.GetProperties();

        var sameProperties = sourceProps.Where(x => targetProps.Select(a => a.Name).Contains(x.Name))
            .ToDictionary(x => x, x => targetProps.First(p => p.Name == x.Name));

        //     typeMatchCache.Add((sourceType, targetType), sameProperties);
        // }

        foreach (var (sourceProp, targetProp) in sameProperties)
        {
            if (ignoreProperties != null && ignoreProperties.Contains(targetProp.Name))
            {
                continue;
            }

            var sourceValue = sourceProp.GetValue(source);

            if (sourceValue != null)
            {
                targetProp.SetValue(target, sourceValue);
            }
        }
    }
}