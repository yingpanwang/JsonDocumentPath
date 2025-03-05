# JsonDocumentPath
JsonDocumentPath is a class library to extract values from JSON (System.Text.Json.JsonDocument) with single line expressions

The JsonPath parser is based on the [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

[NuGet Package](https://www.nuget.org/packages/JsonDocumentPath)

### How to use it

```csharp
  string json = @"{
    ""persons"": [
      {
        ""name""  : ""John"",
        ""age"": ""26""
      },
      {
        ""name""  : ""Jane"",
        ""age"": ""2""
      }
    ]
  }";

var models = JsonDocument.Parse(json);

var results = models.SelectElements("$.persons[?(@.age > 3)]").ToList();
```

### Implementation
Because JsonDocumentPath is using the same Json.net strategic for parsing and evaluation the following is a list of pieces were already implemented:

#### Filters:
- [x] ArrayIndexFilter
- [x] ArrayMultipleIndexFilter
- [x] ArraySliceFilter
- [x] FieldFilter
- [x] FieldMultipleFilter
- [x] QueryFilter
- [x] QueryScanFilter
- [x] RootFilter
- [x] ScanFilter
- [x] ScanMultipleFilter

#### Unit Test:
- [x] JPathParseTests
- [x] QueryExpressionTests
- [x] JPathExecuteTests
- [x] JsonNodeParseTests
- [x] JsonNodePathExecuteTests
- [x] JsonNodeQueryExpressionTests
- [x] JsonNodeRefTests

