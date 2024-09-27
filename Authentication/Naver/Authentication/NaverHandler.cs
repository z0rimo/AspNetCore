using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Zolab.AspNetCore.Authentication.Naver.Authentication;

/// <inheritdoc />
public class NaverHandler : OAuthHandler<NaverOptions>
{
    public NaverHandler(IOptionsMonitor<NaverOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    { }

    /// <inheritdoc />
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
            Logger.LogError("Failed to retrieve Naver user information. Status code: {StatusCode}. Reason: {ReasonPhrase}", response.StatusCode, response.ReasonPhrase);

            // Provide a user-friendly error message.
            throw new HttpRequestException("An error occurred while retrieving Naver user information. Please check your connection and try again.");
        }

        using var payload = JsonDocument.Parse(await response.Content.ReadAsStringAsync(Context.RequestAborted));

        // Create the context and run claim actions to map the claims from the Naver response.
        var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, Context, Scheme, Options, Backchannel, tokens, payload.RootElement);
        context.RunClaimActions();

        // Allow additional custom processing via event hooks.
        await Events.CreatingTicket(context);

        return new AuthenticationTicket(context.Principal!, context.Properties, Scheme.Name);
    }
}
