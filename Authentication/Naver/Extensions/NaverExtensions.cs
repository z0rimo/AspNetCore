using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Zolab.AspNetCore.Authentication.Naver.Authentication;

namespace Zolab.AspNetCore.Authentication.Naver.Extensions;

/// <summary>
/// Provides extension methods to add Naver OAuth-based authentication to an ASP.NET Core application.
/// </summary>
public static class NaverExtensions
{
    /// <summary>
    /// Adds Naver OAuth-based authentication to the specified <see cref="AuthenticationBuilder"/> using the default scheme.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add Naver authentication to.</param>
    /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddNaver(this AuthenticationBuilder builder)
        => builder.AddNaver(NaverDefaults.AuthenticationScheme, NaverDefaults.DisplayName, _ => { });

    /// <summary>
    /// Adds Naver OAuth-based authentication to the specified <see cref="AuthenticationBuilder"/> with a custom authentication scheme.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add Naver authentication to.</param>
    /// <param name="authenticationScheme">The custom authentication scheme to use.</param>
    /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddNaver(this AuthenticationBuilder builder, string authenticationScheme)
        => builder.AddNaver(authenticationScheme, NaverDefaults.DisplayName, _ => { });

    /// <summary>
    /// Adds Naver OAuth-based authentication to the specified <see cref="AuthenticationBuilder"/> with a configuration delegate.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add Naver authentication to.</param>
    /// <param name="configureOptions">A delegate to configure the <see cref="NaverOptions"/>.</param>
    /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddNaver(this AuthenticationBuilder builder, Action<NaverOptions> configureOptions)
        => builder.AddNaver(NaverDefaults.AuthenticationScheme, NaverDefaults.DisplayName, configureOptions);

    /// <summary>
    /// Adds Naver OAuth-based authentication to the specified <see cref="AuthenticationBuilder"/> with custom options.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add Naver authentication to.</param>
    /// <param name="authenticationScheme">The custom authentication scheme to use.</param>
    /// <param name="displayName">The display name for the authentication scheme.</param>
    /// <param name="configureOptions">A delegate to configure the <see cref="NaverOptions"/>.</param>
    /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddNaver(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<NaverOptions> configureOptions)
        => builder.AddOAuth<NaverOptions, NaverHandler>(authenticationScheme, displayName, configureOptions);
}
