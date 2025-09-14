// SmartConfigurationBinder.cs
using System.Text.Json;
using Microsoft.Extensions.Configuration;

public static class SmartConfigurationBinder
{
    public static T GetSmartValue<T>(this IConfiguration configuration, string key, T defaultValue = default)
    {
        return GetSmartValue(configuration, key, null, defaultValue);
    }

    public static T GetSmartValue<T>(this IConfiguration configuration, string key, JsonSerializerOptions options, T defaultValue = default)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        if (string.IsNullOrEmpty(key))
            return defaultValue;

        try
        {
            var stringValue = configuration.GetValue<string>(key);

            if (!string.IsNullOrEmpty(stringValue) && IsJsonString(stringValue))
            {
                try
                {
                    var result = JsonSerializer.Deserialize<T>(stringValue, options);
                    if (result != null)
                        return result;
                }
                catch (JsonException)
                {
                    
                }
            }

            var section = configuration.GetSection(key);
            if (section.Exists() && section.GetChildren().Any())
            {
                var sectionValue = section.Get<T>();
                if (sectionValue != null)
                    return sectionValue;
            }

            var directValue = configuration.GetValue<T>(key);
            if (directValue != null)
                return directValue;

            return defaultValue;
        }
        catch
        {
            return defaultValue;
        }
    }

    public static bool TryGetSmartValue<T>(this IConfiguration configuration, string key, out T result, T defaultValue = default)
    {
        try
        {
            result = configuration.GetSmartValue(key, defaultValue);
            return true;
        }
        catch
        {
            result = defaultValue;
            return false;
        }
    }

    private static bool IsJsonString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        value = value.Trim();

        try
        {
            if ((value.StartsWith('{') && value.EndsWith('}')) ||
                (value.StartsWith('[') && value.EndsWith(']')))
            {
                using var doc = JsonDocument.Parse(value);
                return true;
            }
        }
        catch
        {
        }

        return false;
    }
}