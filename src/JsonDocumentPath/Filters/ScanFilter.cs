﻿using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace System.Text.Json
{
    internal class ScanFilter : PathFilter
    {
        internal string? Name;

        public ScanFilter(string? name)
        {
            Name = name;
        }

        public override IEnumerable<JsonElement?> ExecuteFilter(JsonElement root, IEnumerable<JsonElement?> current, bool errorWhenNoMatch)
        {
            foreach (JsonElement c in current)
            {
                foreach (var e in GetNextScanValue(c))
                {
                    if (e.Name == Name)
                    {
                        yield return e.Value;
                    }
                }
            }
        }

        public override IEnumerable<JsonNode?> ExecuteFilter(JsonNode root, IEnumerable<JsonNode?> current, bool errorWhenNoMatch)
        {
            foreach (JsonNode? c in current)
            {
                foreach (var e in GetNextScanValue(c))
                {
                    if (e.Name == Name)
                    {
                        yield return e.Value;
                    }
                }
            }
        }
    }
}