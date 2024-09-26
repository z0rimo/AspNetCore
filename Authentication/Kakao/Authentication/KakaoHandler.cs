using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using Zolab.AspNetCore.Authentication.OAuth.Helpers;

namespace Zolab.AspNetCore.Authentication.Kakao.Authentication;

/// <inheritdoc />
public class KakaoHandler : OAuthHandler<KakaoOptions>
{
    public KakaoHandler(IOptionsMonitor<KakaoOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    { }

    protected override async Task<AuthenticationTicket> CreateTicketAsync(
        ClaimsIdentity identity,
        AuthenticationProperties properties,
        OAuthTokenResponse tokens)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

        var response = await Backchannel.SendAsync(request, Context.RequestAborted);
        if (!response.IsSuccessStatusCode)
        {
            // Log the error with details.
            Logger.LogError("Failed to retrieve Kakao user information. Status code: {StatusCode}. Reason: {ReasonPhrase}", response.StatusCode, response.ReasonPhrase);

            // Provide a user-friendly error message.
            throw new HttpRequestException("An error occurred while retrieving Kakao user information. Please check your connection and try again.");
        }

        using var payload = JsonDocument.Parse(await response.Content.ReadAsStringAsync(Context.RequestAborted));

        // Create the context and run claim actions to map the claims from the Kakao response.
        var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, Context, Scheme, Options, Backchannel, tokens, payload.RootElement);
        context.RunClaimActions();

        // Allow additional custom processing via event hooks.
        await Events.CreatingTicket(context);

        return new AuthenticationTicket(context.Principal!, context.Properties, Scheme.Name);
    }

    /// <inheritdoc />
    protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
    {
        var queryStrings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "response_type", "code" },
            { "client_id", Options.ClientId },
            { "redirect_uri", redirectUri }
        };

        // Add additional query strings like prompt and nonce if they exist.
        QueryStringHelper.AddQueryString(queryStrings, properties, KakaoChallengeProperties.PromptParameterKey);
        QueryStringHelper.AddQueryString(queryStrings, properties, KakaoChallengeProperties.NonceParameterKey);

        // Protect the state to ensure it is not tampered with.
        var state = Options.StateDataFormat.Protect(properties);
        queryStrings.Add("state", state);

        // Construct the full authorization endpoint URL with query parameters
        var authrizationEndpoint = QueryHelpers.AddQueryString(Options.AuthorizationEndpoint, queryStrings!);
        return authrizationEndpoint;
    }
}
