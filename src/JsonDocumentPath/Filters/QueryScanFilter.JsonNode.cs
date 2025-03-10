#if NET6_0_OR_GREATER

using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace System.Text.Json
{
    internal partial class QueryScanFilter
    {
        public override IEnumerable<JsonNode?> ExecuteFilter(JsonNode root, IEnumerable<JsonNode?> current, bool errorWhenNoMatch)
        {
            foreach (JsonNode? t in current)
            {
                foreach (var (_, Value) in GetNextScanValue(t))
                {
                    if (Expression.IsMatch(root, Value))
                    {
                        yield return Value;
                    }
                }
            }
        }
    }
}

#endif