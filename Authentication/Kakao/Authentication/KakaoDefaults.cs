namespace Zolab.AspNetCore.Authentication.Kakao.Authentication;

/// <summary>
/// Provides default values used by the Kakao OAuth authentication handler.
/// </summary>
public static class KakaoDefaults
{
    /// <summary>
    /// The default authentication scheme used for Kakao OAuth.
    /// </summary>
    public const string AuthenticationScheme = "Kakao";

    /// <summary>
    /// The display name shown to users when selecting the Kakao authentication option.
    /// </summary>
    public const string DisplayName = "Kakao";

    /// <summary>
    /// The endpoint used to initiate the OAuth authorization code flow with Kakao.
    /// </summary>
    public static readonly string AuthorizationEndPoint = "https://kauth.kakao.com/oauth/authorize";

    /// <summary>
    /// The endpoint used to exchange the authorization code for an access token.
    /// </summary>
    public static readonly string TokenEndPoint = "https://kauth.kakao.com/oauth/token";

    /// <summary>
    /// The endpoint used to retrieve user information after authentication.
    /// </summary>
    public static readonly string UserInformationEndPoint = "https://kapi.kakao.com/v2/user/me";
}
