namespace Zolab.AspNetCore.Authentication.Naver.Authentication;

public class NaverDefaults
{
    /// <summary>
    /// The default authentication scheme used for Naver OAuth.
    /// </summary>
    public const string AuthenticationScheme = "Naver";

    /// <summary>
    /// The display name shown to users when selecting the Naver authentication option.
    /// </summary>
    public const string DisplayName = "Naver";

    /// <summary>
    /// The endpoint used to initiate the OAuth authorization code flow with Naver.
    /// </summary>
    public static readonly string AuthorizationEndPoint = "https://nid.naver.com/oauth2.0/authorize";

    /// <summary>
    /// The endpoint used to exchange the authorization code for an access token.
    /// </summary>
    public static readonly string TokenEndPoint = "https://nid.naver.com/oauth2.0/token";

    /// <summary>
    /// The endpoint used to retrieve user information after authentication.
    /// </summary>
    public static readonly string UserInformationEndPoint = "https://openapi.naver.com/v1/nid/me";
}
