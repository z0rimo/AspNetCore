using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Zolab.AspNetCore.Authentication.Kakao.Authentication;

namespace Zolab.AspNetCore.Authentication.Kakao.Extensions;

/// <summary>
/// Provides extension methods to add Kakao OAuth-based authentication to an ASP.NET Core application.
/// </summary>
public static class KakaoExtensions
{
    /// <summary>
    /// Adds Kakao OAuth-based authentication to the specified <see cref="AuthenticationBuilder"/> using the default scheme.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add Kakao authentication to.</param>
    /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder)
        => builder.AddKakao(KakaoDefaults.AuthenticationScheme, KakaoDefaults.DisplayName, _ => { });

    /// <summary>
    /// Adds Kakao OAuth-based authentication to the specified <see cref="AuthenticationBuilder"/> with a custom authentication scheme.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add Kakao authentication to.</param>
    /// <param name="authenticationScheme">The custom authentication scheme to use.</param>
    /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, string authenticationScheme)
    => builder.AddKakao(authenticationScheme, KakaoDefaults.DisplayName, _ => { });

    /// <summary>
    /// Adds Kakao OAuth-based authentication to the specified <see cref="AuthenticationBuilder"/> with a configuration delegate.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add Kakao authentication to.</param>
    /// <param name="configureOptions">A delegate to configure the <see cref="KakaoOptions"/>.</param>
    /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, Action<KakaoOptions> configureOptions)
        => builder.AddKakao(KakaoDefaults.AuthenticationScheme, KakaoDefaults.DisplayName, configureOptions);

    /// <summary>
    /// Adds Kakao OAuth-based authentication to the specified <see cref="AuthenticationBuilder"/> with custom options.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add Kakao authentication to.</param>
    /// <param name="authenticationScheme">The custom authentication scheme to use.</param>
    /// <param name="displayName">The display name for the authentication scheme.</param>
    /// <param name="configureOptions">A delegate to configure the <see cref="KakaoOptions"/>.</param>
    /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddKakao(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<KakaoOptions> configureOptions)
        => builder.AddOAuth<KakaoOptions, KakaoHandler>(authenticationScheme, displayName, configureOptions);
}
