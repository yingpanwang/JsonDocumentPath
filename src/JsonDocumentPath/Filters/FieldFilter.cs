using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace System.Text.Json
{
    internal partial class FieldFilter : PathFilter
    {
        internal string? Name;

        public FieldFilter(string? name)
        {
            Name = name;
        }

        public override IEnumerable<JsonElement?> ExecuteFilter(JsonElement root, IEnumerable<JsonElement?> current, bool errorWhenNoMatch)
        {
            foreach (JsonElement t in current)
            {
                if (t.ValueKind == JsonValueKind.Object)
                {
                    if (Name != null)
                    {
                        if (t.TryGetProperty(Name, out JsonElement v))
                        {
                            if (v.ValueKind != JsonValueKind.Null)
                            {
                                yield return v;
                            }
                            else if (errorWhenNoMatch)
                            {
                                throw new JsonException($"Property '{Name}' does not exist on JObject.");
                            }
                        }
                    }
                    else
                    {
                        foreach (var p in t.ChildrenTokens())
                        {
                            yield return p;
                        }
                    }
                }
                else
                {
                    if (errorWhenNoMatch)
                    {
                        throw new JsonException($"Property '{Name ?? "*"}' not valid on {t.GetType().Name}.");
                    }
                }
            }
        }

        public override IEnumerable<JsonNode?> ExecuteFilter(JsonNode root, IEnumerable<JsonNode?> current, bool errorWhenNoMatch)
        {
            foreach (JsonNode t in current)
            {
                if (t.GetSafeJsonValueKind() == JsonValueKind.Object)
                {
                    if (Name != null)
                    {
                        var tObject = t.AsObject();
                        if (tObject.TryGetPropertyValue(Name, out JsonNode? v))
                        {
                            if (v?.GetSafeJsonValueKind() != JsonValueKind.Null)
                            {
                                yield return v;
                            }
                            else if (errorWhenNoMatch)
                            {
                                throw new JsonException($"Property '{Name}' does not exist on JObject.");
                            }
                        }
                    }
                    else
                    {
                        foreach (var p in t.ChildrenNodes())
                        {
                            yield return p;
                        }
                    }
                }
                else
                {
                    if (errorWhenNoMatch)
                    {
                        throw new JsonException($"Property '{Name ?? "*"}' not valid on {t.GetType().Name}.");
                    }
                }
            }
        }
    }
}