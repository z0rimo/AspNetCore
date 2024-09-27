using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Zolab.AspNetCore.Authentication.Naver.Authentication;

public class NaverOptions : OAuthOptions
{
    /// <summary>
    /// Provides the configuration options needed to set up Naver OAuth authentication in an ASP.NET Core application.
    /// </summary>
    public NaverOptions()
    {
        // Sets the callback path where the application will receive the authorization code after the user is authenticated.
        CallbackPath = new PathString("/signin-naver");

        // Sets the URL where users will be redirected to begin the OAuth authorization process with Kakao.
        AuthorizationEndpoint = NaverDefaults.AuthorizationEndPoint;

        // Sets the URL used to exchange the authorization code for an access token.
        TokenEndpoint = NaverDefaults.TokenEndPoint;

        // Sets the URL used to retrieve the authenticated user's information from Kakao.
        UserInformationEndpoint = NaverDefaults.UserInformationEndPoint; ;

        // Maps the "id" field from the nested "response" JSON object in the Naver user information response 
        // to the NameIdentifier claim. This will be used as the unique identifier for the authenticated user.
        ClaimActions.MapJsonSubKey(ClaimTypes.NameIdentifier, "response", "id");

        // Maps the "name" field from the nested "response" JSON object in the Naver user information response 
        // to the Name claim. This represents the user's name in the application.
        ClaimActions.MapJsonSubKey(ClaimTypes.Name, "response", "name");

        // Maps the "email" field from the nested "response" JSON object in the Naver user information response 
        // to the Email claim. This will store the user's email address in the application.
        ClaimActions.MapJsonSubKey(ClaimTypes.Email, "response", "email");
    }
}
