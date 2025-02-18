using System.Text.Json.Nodes;

namespace System.Text.Json;

internal static class JsonNodeExtensions
{
    public static string GetString(this JsonNode node)
    {
        return node.GetValue<string>();
    }

    public static bool GetBoolean(this JsonNode node)
    {
        return node.GetValue<bool>();
    }

    public static double GetDouble(this JsonNode node)
    {
        return node.GetValue<double>();
    }
}