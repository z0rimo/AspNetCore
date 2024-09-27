using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Zolab.AspNetCore.Authentication.OAuth.Extensions;

namespace Zolab.AspNetCore.Authentication.Kakao.Authentication;

/// <summary>
/// Provides the configuration options needed to set up Kakao OAuth authentication in an ASP.NET Core application.
/// </summary>
public class KakaoOptions : OAuthOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KakaoOptions"/> class with default settings specific to Kakao's OAuth flow.
    /// </summary>
    public KakaoOptions()
    {
        // Sets the callback path where the application will receive the authorization code after the user is authenticated.
        CallbackPath = new PathString("/signin-kakao");

        // Sets the URL where users will be redirected to begin the OAuth authorization process with Kakao.
        AuthorizationEndpoint = KakaoDefaults.AuthorizationEndPoint;

        // Sets the URL used to exchange the authorization code for an access token.
        TokenEndpoint = KakaoDefaults.TokenEndPoint;

        // Sets the URL used to retrieve the authenticated user's information from Kakao.
        UserInformationEndpoint = KakaoDefaults.UserInformationEndPoint;

        // Maps the "id" field from the Kakao user information response to the NameIdentifier claim.
        ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");

        // Maps the "email" field from a nested JSON structure in the Kakao user information response to the Email claim.
        ClaimActions.MapJsonThirdKey(ClaimTypes.Email, "property_keys", "kakao_account", "email");
    }
}
