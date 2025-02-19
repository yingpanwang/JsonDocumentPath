using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace System.Text.Json
{
    internal class QueryFilter : PathFilter
    {
        internal QueryExpression Expression;

        public QueryFilter(QueryExpression expression)
        {
            Expression = expression;
        }

        public override IEnumerable<JsonElement?> ExecuteFilter(JsonElement root, IEnumerable<JsonElement?> current, bool errorWhenNoMatch)
        {
            foreach (JsonElement el in current)
            {
                if (el.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement v in el.EnumerateArray())
                    {
                        if (Expression.IsMatch(root, v))
                        {
                            yield return v;
                        }
                    }
                }
                else if (el.ValueKind == JsonValueKind.Object)
                {
                    foreach (JsonProperty v in el.EnumerateObject())
                    {
                        if (Expression.IsMatch(root, v.Value))
                        {
                            yield return v.Value;
                        }
                    }
                }
            }
        }

        public override IEnumerable<JsonNode?> ExecuteFilter(JsonNode root, IEnumerable<JsonNode?> current, bool errorWhenNoMatch)
        {
            foreach (JsonNode? el in current)
            {
                if (el?.GetSafeJsonValueKind() == JsonValueKind.Array)
                {
                    var elArray = el.AsArray();
                    foreach (JsonNode? v in elArray)
                    {
                        if (Expression.IsMatch(root, v))
                        {
                            yield return v;
                        }
                    }
                }
                else if (el?.GetSafeJsonValueKind() == JsonValueKind.Object)
                {
                    var elObject = el.AsObject();
                    foreach (KeyValuePair<string, JsonNode> v in elObject)
                    {
                        if (Expression.IsMatch(root, v.Value))
                        {
                            yield return v.Value;
                        }
                    }
                }
            }
        }
    }
}