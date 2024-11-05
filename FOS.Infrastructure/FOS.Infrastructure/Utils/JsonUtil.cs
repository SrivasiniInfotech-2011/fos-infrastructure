using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;

namespace FOS.Infrastructure.Services.Utils;

/// <summary>
/// Utility methods for JSON operations.
/// </summary>
public static class JsonUtil
{
    /// <summary>
    /// Validates a JSON string against a given JSON schema.
    /// </summary>
    /// <param name="json">The JSON string to validate.</param>
    /// <param name="schema">The JSON schema to validate against.</param>
    /// <param name="messages">The validation error messages, if any.</param>
    /// <returns>True if the JSON is valid according to the schema; otherwise, false.</returns>
    public static bool IsValidSchema(string json, string schema, out IList<string>? messages)
    {
        var jSchema = JSchema.Parse(schema);

        var data = JToken.Parse(json);

        return data.IsValid(jSchema, out messages);
    }

    /// <summary>
    /// Validates a JSON string against a given JSON schema.
    /// </summary>
    /// <param name="json">The JSON string to validate.</param>
    /// <param name="schema">The JSON schema to validate against.</param>
    /// <param name="messages">The validation error messages, if any.</param>
    /// <returns>True if the JSON is valid according to the schema; otherwise, false.</returns>
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(
        obj,
        Formatting.Indented,
        new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
        );
    }
}