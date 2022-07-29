namespace Protium.Digital.Shared.Helpers;

public static class StringHelpers
{
    public static string GenerateEntityId() => Guid.NewGuid().ToString().Replace("-", "");
    
    public static string ToSnakeCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }
        
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()))
            .ToLower();
    }
}