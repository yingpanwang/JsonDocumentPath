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

    public static int GetInt32(this JsonNode node)
    {
        return node.GetValue<int>();
    }

    /// <summary>
    /// 获取安全的 JsonValueKind
    /// </summary>
    /// <remarks>JsonNode 无法表示 JsonValueKind.Null </remarks>
    /// <param name="node"></param>
    /// <returns></returns>
    public static JsonValueKind GetSafeJsonValueKind(this JsonNode? node)
    {
        if (node == null)
            return JsonValueKind.Null;

        return node.GetValueKind();
    }
}