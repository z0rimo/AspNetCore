using Microsoft.AspNetCore.Authentication.OAuth;

namespace Zolab.AspNetCore.Authentication.Kakao.Authentication;

/// <summary>
/// Manages specific parameters used during the Kakao authentication challenge.
/// </summary>
public class KakaoChallengeProperties : OAuthChallengeProperties
{
    // Constants for parameter keys.
    public const string PromptParameterKey = "prompt";
    public const string NonceParameterKey = "nonce";

    /// <summary>
    /// Initializes a new instance of <see cref="KakaoChallengeProperties"/>.
    /// </summary>
    public KakaoChallengeProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="KakaoChallengeProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public KakaoChallengeProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="KakaoChallengeProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public KakaoChallengeProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// Gets or sets the 'prompt' parameter value used during the authentication challenge.
    /// </summary>
    public string? Prompt
    {
        get => GetParameter<string>(PromptParameterKey);
        set => SetParameter(PromptParameterKey, value);
    }

    /// <summary>
    /// Gets or sets the 'nonce' parameter value used during the authentication challenge.
    /// </summary>
    public string? Nonce
    {
        get => GetParameter<string>(NonceParameterKey);
        set => SetParameter(NonceParameterKey, value);
    }
}
