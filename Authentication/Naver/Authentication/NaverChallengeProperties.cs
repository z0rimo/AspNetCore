using Microsoft.AspNetCore.Authentication.OAuth;

namespace Zolab.AspNetCore.Authentication.Naver.Authentication;

/// <summary>
/// Manages specific parameters used during the Naver authentication challenge.
/// </summary>
public class NaverChallengeProperties : OAuthChallengeProperties
{
    // Constants for parameter keys.
    public const string ScopeParameterKey = "scope";

    /// <summary>
    /// Initializes a new instance of <see cref="NaverChallengeProperties"/>.
    /// </summary>
    public NaverChallengeProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="NaverChallengeProperties"/>.
    /// </summary>
    public NaverChallengeProperties(IDictionary<string, string?> items)
        : base(items) { }

    /// <summary>
    /// Initializes a new instance of <see cref="NaverChallengeProperties"/>.
    /// </summary>
    public NaverChallengeProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters) { }

    /// <summary>
    /// Gets or sets the 'scope' parameter value used during the authentication challenge.
    /// </summary>
    public new string? Scope
    {
        get => GetParameter<string>(ScopeParameterKey);
        set => SetParameter(ScopeParameterKey, value);
    }
}
