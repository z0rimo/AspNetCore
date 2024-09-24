using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System.Security.Claims;
using System.Text.Json;

namespace Zolab.AspNetCore.Authentication.OAuth.Actions;

public class NestedJsonClaimAction : JsonSubKeyClaimAction
{
    /// <summary>
    /// Creates a new NestedJsonClaimAction.
    /// </summary>
    /// <param name="claimType">The value to use for Claim.Type when creating a Claim.</param>
    /// <param name="valueType">The value to use for Claim.ValueType when creating a Claim.</param>
    /// <param name="jsonKey">The top level key to look for in the json user data.</param>
    /// <param name="subKey">The second level key to look for in the json user data.</param>
    /// <param name="thirdKey">The third level key to look for in the json user data.</param>
    public NestedJsonClaimAction(string claimType, string valueType, string jsonKey, string subKey, string thirdKey)
        : base(claimType, valueType, jsonKey, subKey)
    {
        ThirdKey = thirdKey;
    }

    /// <inheritdoc />
    public override void Run(JsonElement userData, ClaimsIdentity identity, string issuer)
    {
        var value = GetValue(userData, JsonKey, SubKey, ThirdKey);
        if (!string.IsNullOrEmpty(value))
        {
            identity.AddClaim(new Claim(ClaimType, value, ValueType, issuer));
        }
    }

    // Get the given thirdProperty from a property.
    private static string? GetValue(JsonElement userData, string jsonKey, string subKey, string thirdKey)
    {
        if (userData.TryGetProperty(jsonKey, out JsonElement jsonElement) &&
            jsonElement.TryGetProperty(subKey, out JsonElement subElement) &&
            subElement.TryGetProperty(thirdKey, out JsonElement thirdElement))
        {
            return thirdElement.GetString();
        }

        return null;
    }

    /// <summary>
    /// The third level key to look for in the json user data.
    /// </summary>
    public string ThirdKey { get; }
}
